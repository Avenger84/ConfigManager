using Microsoft.Xrm.Sdk;
using System;
namespace VNET.Library.DataLibrary.SqlDataLayer.Interfaces
{
    public interface IMsCrmAccess
    {
        IOrganizationService GetCrmService();
    }
}
