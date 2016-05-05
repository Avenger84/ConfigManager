using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VNET.Library.ConfigManager;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.DataLibrary.SqlDataLayer;
using VNET.Library.DataLibrary.SqlDataLayer.Interface;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.Utility;

namespace ConsoleApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string den = ConfigWrapper.Config.AdminId;

            //IConfigManager _confManager = new RegConfigManager("sahibindenTest");

            ISqlAccess sqlAccess = new SqlAccess("Data Source=192.168.5.76; Initial Catalog=SSIS_DEST; User Id=CrmSqlUser; Password=Crm123;Max Pool Size = 10000;Pooling = True");
            ISqlEntityAccess sqlEntityAccess = new SqlEntityAccess(sqlAccess);
            IDBConfigDao configDao = new DBConfigDao(sqlEntityAccess);

            //IConfigManager _confManager = new DBConfigManager(configDao, "TEST");

            IConfigManager _confManager = new AppSettingsConfigManager();

            IConfigs configs = new Configs(_confManager);

            string adminId = _confManager.GetKeyValue("AdminId");
            string adminName = configs.AdminName;


            regConfigTest regTest = new regConfigTest(configs);
            regTest.Process();
        }
    }
}
