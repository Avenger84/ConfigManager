using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.Entities.CustomEntities;
using VNET.Library.LogManager.Interfaces;

namespace VNET.Library.LogManager
{
    public class Logger : ILogManager
    {
        private ILogData _logData;

        public Logger(ILogData logData)
        {
            _logData = logData;
        }

        public void Log(LogEntity logEntity)
        {
            _logData.Log(logEntity);
        }

        public void Log(string applicationName, string functionName, string logKey, string detail, LogEntity.EventType eventType)
        {
            LogEntity logEntity = new LogEntity()
                                        {
                                            ApplicationName = applicationName,
                                            FunctionName = functionName,
                                            LogKey = logKey,
                                            CreatedOn = DateTime.Now,
                                            Detail = detail,
                                            LogEventType = eventType
                                        };

            _logData.Log(logEntity);
        }
    }
}
