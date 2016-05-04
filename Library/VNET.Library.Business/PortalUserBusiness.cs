using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Business.Interfaces;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.Business
{
    public class PortalUserBusiness : BaseEntityBusiness<PortalUser>, IPortalUserBusiness
    {
        private IBaseDataManager<PortalUser> _baseDataManager;
        private IPortalUserDao _portalUserDao;

        public PortalUserBusiness(IBaseDataManager<PortalUser> baseDataManager, IPortalUserDao portalUserDao)
            : base(baseDataManager)
        {
            _baseDataManager = baseDataManager;
            _portalUserDao = portalUserDao;
        }

        public PortalUser CheckLogin(string userName, string password)
        {
            return _portalUserDao.CheckLogin(userName, password);
        }
    }
}
