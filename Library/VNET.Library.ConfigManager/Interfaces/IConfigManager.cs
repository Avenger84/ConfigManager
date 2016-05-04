using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.ConfigManager.Interfaces
{
    public interface IConfigManager
    {
        string GetKeyValue(string key);

        string this[string key] { get; }

        //void FillConfigValues();
    }
}
