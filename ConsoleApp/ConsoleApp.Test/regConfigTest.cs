using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNET.Library.ConfigManager;
using VNET.Library.ConfigManager.Interfaces;

namespace ConsoleApp.Test
{
    public class regConfigTest
    {
        private IConfigManager _configManager;

        public regConfigTest()
        {
            //_configManager = configManager;
        }

        public void Process()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("AdminName:{0}|{1}", Configs.AdminName, DateTime.Now.ToString("HH:mm ss"));
                Thread.Sleep(3000);
            }
        }
    }
}
