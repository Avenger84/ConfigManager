using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VNET.Library.Constants.SqlQueries;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.DataLibrary.SqlDataLayer.Interface;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.DataLibrary.SqlDataLayer
{
    public class DBConfigDao : IDBConfigDao
    {
        private ISqlEntityAccess _sqlEntityAccess;

        private string _PKName;

        public DBConfigDao(ISqlEntityAccess sqlEntityAccess)
        {
            _sqlEntityAccess = sqlEntityAccess;
        }

        public ConfigCollection GetConfigVaribales(string server)
        {
            ConfigCollection returnValue = new ConfigCollection();

            SqlParameter[] parameters = new SqlParameter[] { 
                        new SqlParameter("@server",server)
                    };

            DataTable dt = _sqlEntityAccess.SqlAccess.GetDataTable(ConfigManagerQueries.GET_CONFIG_VARS, parameters);

            returnValue.AddRange(dt.ToKeyValueList<string, string>());

            return returnValue;
        }
    }
}