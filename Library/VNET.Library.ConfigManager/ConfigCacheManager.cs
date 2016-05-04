using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using VNET.Library.ConfigManager.Interfaces;

namespace VNET.Library.ConfigManager
{
    internal class ConfigCacheManager
    {
        private const int CACHE_INTERVAL = 10 * 1000;
        private System.Timers.Timer _timer;

        private IConfigManager _configManager;

        public ConfigCacheManager(IConfigManager configManager)
        {
            _configManager = configManager;

            _timer = new System.Timers.Timer();
            _timer.Interval = CACHE_INTERVAL;
            _timer.AutoReset = true;
        }

        public void StartConfigCache()
        {
            _configManager.FillConfigValues();

            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            _timer.Start();
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _configManager.FillConfigValues();
        }
    }
}
