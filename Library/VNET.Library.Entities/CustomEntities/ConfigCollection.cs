using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.Custom.Entities;

namespace VNET.Library.Entities.CrmEntities
{
    public class ConfigCollection : DataCollection<string, string>
    {
        public ConfigCollection()
        {

        }

        public ConfigCollection(List<KeyValuePair<string, string>> configData)
        {
            base.AddRange(configData);
        }
    }
}
