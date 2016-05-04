using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.DataLibrary.Interfaces
{
    public interface ILogData
    {
        void Log(LogEntity logEntity);
    }
}
