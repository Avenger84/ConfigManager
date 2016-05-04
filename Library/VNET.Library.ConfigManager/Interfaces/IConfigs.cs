using System;
namespace VNET.Library.ConfigManager.Interfaces
{
    public interface IConfigs
    {
        string AdminId { get; }
        string AdminName { get; }
        string ConnectionString { get; }
    }
}
