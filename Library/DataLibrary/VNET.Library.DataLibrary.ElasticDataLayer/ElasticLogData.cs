using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.DataLibrary.ElasticDataLayer.Interfaces;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.DataLibrary.ElasticDataLayer
{
    public class ElasticLogData : ILogData
    {
        private IElasticAccess _elasticAccess;
        private string _applicationName;

        public ElasticLogData(IElasticAccess elasticAccess, string applicationName)
        {
            _elasticAccess = elasticAccess;
            _applicationName = applicationName;
        }

        public void Log(LogEntity logEntity)
        {
            logEntity.ApplicationName = _applicationName;

            _elasticAccess.CreateDocument(logEntity.FunctionName, logEntity);
        }
    }
}
