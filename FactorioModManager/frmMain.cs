using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactorioModManager
{
    public partial class frmMain : Form
    {
        // ╲⎝⧹Flayer⧸⎠╱
        //http://mods.factorio.com/api/mods?page_size=max&namelist=aai-programmable-structures
        Modlist modList;
        WebClient webClient = new WebClient();
        
        string defaultModHost = "http://mods.factorio.com";
        string defaultUsername = "Flayer1993";
        string defaultToken = "a5945b790ad7a91265610b2247c743";
        string defaultOnlyEnabled = "false";
        string settingModHost = "modHost";
        string settingUsername = "username";
        string settingToken = "token";
        string settingOnlyEnabled = "onlyEnabled";
        string tempDownloadName = "download";

        string modListFilename = "mod-list.json";

        Mod currentMod;
        string currentModUrl;
        string currentModFilename;
        string currentModOwner;
        int currentModIndex;
        bool updateInProgress = false;

        public frmMain()
        {
            InitializeComponent();
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            LogWriteLine(" done.");
            InstallDownloadedMod();
            currentModIndex++;
            ProcessNextModUpdate();
        }
        private void InstallDownloadedMod()
        {
            LogWriteLine("Installing " + currentModFilename);
            File.Move(tempDownloadName, Path.Combine(txtbModsDirectory.Text,currentModFilename));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtbModHost.Text = ConfigurationManager.AppSettings[settingModHost] ?? defaultModHost;
            txtbUsername.Text = ConfigurationManager.AppSettings[settingUsername] ?? defaultUsername;
            txtbToken.Text = ConfigurationManager.AppSettings[settingToken] ?? defaultToken;
            cbUpdateOnlyEnabled.Checked = bool.Parse(ConfigurationManager.AppSettings[settingOnlyEnabled] ?? defaultOnlyEnabled);
        }

        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            txtbModHost.Text = defaultModHost;
            txtbUsername.Text = defaultUsername;
            txtbToken.Text = defaultToken;
            cbUpdateOnlyEnabled.Checked = bool.Parse(defaultOnlyEnabled);
        }

        private void btnModsDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtbModsDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }
        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void txtbModHost_TextChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings(settingModHost, txtbModHost.Text);
            webClient.BaseAddress = txtbModHost.Text;
        }

        private void txtbUsername_TextChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings(settingUsername, txtbUsername.Text);
        }

        private void txtbToken_TextChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings(settingToken, txtbToken.Text);
        }

        private void cbUpdateOnlyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings(settingOnlyEnabled, cbUpdateOnlyEnabled.Checked.ToString());
        }

        private void txtbModsDirectory_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(txtbModsDirectory.Text);
            txtbActionLog.Clear();
            //btnUpdateMods.Enabled = true;
            LoadModList();
        }
        
        private void LoadModList()
        {
            string modListPath = txtbModsDirectory.Text + Path.DirectorySeparatorChar + modListFilename;
            if (File.Exists(modListPath))
            {
                LogWriteLine("Loading: " + modListPath);
                modList = JsonConvert.DeserializeObject<Modlist>(File.ReadAllText(modListPath));
                LogWriteLine((modList.mods.Count - 1) + " Mods found.");
                clbModList.Items.Clear();
                foreach (var mod in modList.mods)
                {
                    var insertedIndex = clbModList.Items.Add(mod);
                    clbModList.SetItemChecked(insertedIndex, mod.enabled);
                }
                var files = Directory.GetFiles(txtbModsDirectory.Text);
                Console.WriteLine(String.Join(", ", files));
            }
        }

        private void clbModList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Mod m = ((Mod)clbModList.Items[e.Index]);
            if (m.name == "base")
            {
                e.NewValue = CheckState.Checked;
            }
            else
            {
                m.enabled = (e.NewValue == CheckState.Checked);
                WriteModListJson();
            }
        }

        private void WriteModListJson()
        {
            string modListPath = txtbModsDirectory.Text + Path.DirectorySeparatorChar + modListFilename;

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(modListPath))
                using(JsonWriter writer = new JsonTextWriter(sw))
                    serializer.Serialize(writer, modList);
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            foreach (var mod in modList.mods)
            {
                Console.WriteLine("{0} {1}",mod.name, mod.enabled);
            }
        }*/

        /*private void button2_Click(object sender, EventArgs e)
        {
            string[] fileList = Directory.GetFiles(txtbModsDirectory.Text);
            Mod m = ((Mod)clbModList.SelectedItem);
            Console.WriteLine(txtbModHost.Text);
            //Console.WriteLine(webClient.DownloadString("/api/mods?page_size=max&namelist=" + m.name));
            string modData = webClient.DownloadString("/api/mods?q=" + m.name);
            dynamic modjsonData = JObject.Parse(modData);
            Console.WriteLine(modjsonData.results[0].releases[0]);
            JObject jModData = JObject.Parse(modData);
            JObject res = (JObject)jModData["results"][0];
            JArray release = (JArray)res["releases"];
            Console.WriteLine(res["owner"].ToString());
            string download = release[0]["download_url"].ToString();
            string file = release[0]["file_name"].ToString();
            webClient.DownloadFileAsync(new Uri(txtbModHost.Text + download + "?username="+txtbUsername.Text+"&token="+txtbToken.Text),file);
        }*/

        private void BeginModDownload(string d,string f)
        {
            Uri fileUri = new Uri(txtbModHost.Text + d + "?username=" + txtbUsername.Text + "&token=" + txtbToken.Text);
            webClient.DownloadFileAsync(fileUri, f);
        }

        private void btnUpdateMods_Click(object sender, EventArgs e)
        {
            if (!updateInProgress)
            {
                updateInProgress = true;
                currentModIndex = 0;
                txtbActionLog.Clear();
                //btnUpdateMods.Enabled = false;
                int enabledCount = 0;
                foreach (var m in modList.mods)
                    if (m.enabled)
                        enabledCount++;
                if (cbUpdateOnlyEnabled.Checked)
                {
                    LogWriteLine("Updating ENABLED (" + (enabledCount - 1) + ") mods.");
                }
                else
                {
                    LogWriteLine("Updating ALL (" + (modList.mods.Count - 1) + ") mods.");
                }
                ProcessNextModUpdate();
            }
        }

        private void ProcessNextModUpdate()
        {
            if (currentModIndex < modList.mods.Count)
            {
                currentMod = modList.mods[currentModIndex];
                if (currentMod.name == "base")
                {
                    SkipModUpdate();
                    return;
                }
                if (cbUpdateOnlyEnabled.Checked && !currentMod.enabled)
                {
                    SkipModUpdate();
                    return;
                }
                SearchForModInfo();
                return;
            }
            if (currentModIndex == modList.mods.Count)
            {
                LogWriteLine("Updating COMPLETED.");
                //btnUpdateMods.Enabled = true;
                updateInProgress = false;
            }
        }

        private void SkipModUpdate()
        {
            currentModIndex++;
            ProcessNextModUpdate();
        }

        private void SearchForModInfo()
        {
            LogWrite("Fetching info on " + currentMod.name + "...");
            string modData = webClient.DownloadString("/api/mods?namelist=" + currentMod.name);
            dynamic searchDataJson = JObject.Parse(modData);
            foreach (var item in searchDataJson.results)
            {
                if (item.name.ToString() == currentMod.name)
                {
                    JArray releases = item.releases;
                    dynamic latestRelease = releases[releases.Count-1];
                    currentModOwner = item.owner.ToString();
                    currentModFilename = latestRelease.file_name.ToString();
                    currentModUrl = latestRelease.download_url.ToString();
                    LogWriteLine(" done.");
                    CheckCurrentModFileVersion();
                    return;
                }
            }
            LogWriteLine(" not found - skipping");
            SkipModUpdate();
        }

        private void CheckCurrentModFileVersion()
        {
            bool installed = false;
            bool updateRequired = false;
            string[] fileList = Directory.GetFiles(txtbModsDirectory.Text);
            string pattern = String.Format(@"^{0}_[\.\d]+\.zip$", Regex.Escape(currentMod.name));
            Regex rgx = new Regex(pattern);
            foreach (var f in fileList)
            {
                string fn = Path.GetFileName(f);
                if (rgx.IsMatch(fn))
                {
                    installed = true;
                    LogWrite("Installed: " + fn + " Latest: " + currentModFilename + " ...");
                    if (fn != currentModFilename)
                    {
                        updateRequired = true;
                        File.Delete(f);
                    }
                    break;
                }
            }
            if (!installed)
            {
                LogWrite("Not Installed. Latest: " + currentModFilename + " ...");
                updateRequired = true;
            }
            if (updateRequired)
            {
                LogWriteLine(" download required.");
                BeginModDownload();
            } else
            {
                LogWriteLine(" latest.");
                SkipModUpdate();
            }
        }

        private void BeginModDownload()
        {
            LogWrite("Downloading " + currentModFilename + "...");
            Uri fileUri = new Uri(txtbModHost.Text + currentModUrl + "?username=" + txtbUsername.Text + "&token=" + txtbToken.Text);
            webClient.DownloadFileAsync(fileUri, tempDownloadName);
        }

        private void LogWrite(string text)
        {
            txtbActionLog.AppendText(text);
        }

        private void LogWriteLine(string text)
        {
            txtbActionLog.AppendText(text + "\r\n");
        }

        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            foreach (var m in modList.mods)
                m.enabled = true;
            WriteModListJson();
            txtbActionLog.Clear();
            LoadModList();

        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
            foreach (var m in modList.mods)
            {
                if (m.name != "base")
                    m.enabled = false;
            }
            WriteModListJson();
            txtbActionLog.Clear();
            LoadModList();

        }
    }
}
