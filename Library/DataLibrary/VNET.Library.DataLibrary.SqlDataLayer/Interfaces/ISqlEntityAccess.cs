using Microsoft.Xrm.Sdk;
using System;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
namespace VNET.Library.DataLibrary.SqlDataLayer.Interface
{
    public interface ISqlEntityAccess
    {
        object Create(Entity entity, string PKName);
        void Delete(string entityName, Guid id, string PKName);
        void Update(Entity entity, string PKName);

        ISqlAccess SqlAccess { get; }
    }
}
