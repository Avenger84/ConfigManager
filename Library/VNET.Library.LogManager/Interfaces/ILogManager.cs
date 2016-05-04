using VNET.Library.Entities.CrmEntities;
using System;
using VNET.Library.Entities.CustomEntities;
namespace VNET.Library.LogManager.Interfaces
{
    public interface ILogManager
    {
        void Log(LogEntity logEntity);
        void Log(string applicationName, string functionName, string logKey, string detail, LogEntity.EventType eventType);
    }
}
