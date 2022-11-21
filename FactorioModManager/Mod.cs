using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioModManager
{
    class Mod
    {
        public string name;
        public bool enabled;

        public override string ToString()
        {
            return name;
        }
    }
}
