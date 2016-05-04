using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.ConfigManager;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Net;
using System.ServiceModel.Description;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.Constants;

namespace VNET.Library.DataLibrary.SqlDataLayer
{
    public class MsCrmAccess : IMsCrmAccess
    {
        private readonly bool _isAdmin = true;
        private readonly string _behalfOfUserId = string.Empty;
        private readonly IConfigManager _configManager;

        public MsCrmAccess(bool isAdmin, IConfigManager configManager)
        {
            _isAdmin = isAdmin;
            _configManager = configManager;
        }

        public MsCrmAccess(string behalfOfUserId)
        {
            _isAdmin = true;
            _behalfOfUserId = behalfOfUserId;
        }

        public IOrganizationService GetCrmService()
        {
            IOrganizationService crmService = null;

            if (!string.IsNullOrEmpty(_behalfOfUserId))
            {
                crmService = GetCrmServiceBehalfOfUser(_behalfOfUserId);
            }
            else if (_isAdmin)
            {
                crmService = GetAdminCrmService();
            }
            else
            {
                crmService = GetCurrentUserCrmService();
            }

            return crmService;
        }

        private IOrganizationService GetAdminCrmService()
        {
            ClientCredentials credential = new ClientCredentials();

            if (_configManager[RegKeys.CRM_ORGANIZATION_SERVICE_URL].Contains("https"))
            {
                credential.Windows.ClientCredential = new NetworkCredential(_configManager[RegKeys.CRM_ADMIN_USER_NAME], _configManager[RegKeys.CRM_ADMIN_PASSWORD], _configManager[RegKeys.DOMAIN_NAME]);
                credential.UserName.UserName = _configManager[RegKeys.DOMAIN_NAME] + @"\" + _configManager[RegKeys.CRM_ADMIN_USER_NAME];
                credential.UserName.Password = _configManager[RegKeys.CRM_ADMIN_PASSWORD];
            }
            else
            {
                credential.Windows.ClientCredential = new NetworkCredential(_configManager[RegKeys.CRM_ADMIN_USER_NAME], _configManager[RegKeys.CRM_ADMIN_PASSWORD], _configManager[RegKeys.DOMAIN_NAME]);
            }

            OrganizationServiceProxy orgServiceProxy = new OrganizationServiceProxy(new Uri(_configManager[RegKeys.CRM_ORGANIZATION_SERVICE_URL]), null, credential, null);

            return orgServiceProxy;
        }

        private IOrganizationService GetCrmServiceBehalfOfUser(string callerId)
        {
            OrganizationServiceProxy orgServiceProxy = (OrganizationServiceProxy)GetAdminCrmService();

            orgServiceProxy.CallerId = new Guid(callerId);

            return orgServiceProxy;
        }

        private IOrganizationService GetCurrentUserCrmService()
        {
            ClientCredentials credential = new ClientCredentials();
            credential.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;

            OrganizationServiceProxy orgServiceProxy = new OrganizationServiceProxy(new Uri(_configManager[RegKeys.CRM_ORGANIZATION_SERVICE_URL]), null, credential, null);

            return orgServiceProxy;
        }
    }
}
