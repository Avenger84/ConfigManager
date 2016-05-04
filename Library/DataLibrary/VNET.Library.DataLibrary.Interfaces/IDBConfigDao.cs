using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.DataLibrary.Interfaces
{
    public interface IDBConfigDao
    {
        ConfigCollection GetConfigVaribales(string server);
    }
}
