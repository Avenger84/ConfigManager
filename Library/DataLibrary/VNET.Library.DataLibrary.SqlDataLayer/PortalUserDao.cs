using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VNET.Library.Constants.SqlQueries;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.DataLibrary.SqlDataLayer
{
    public class PortalUserDao : IBaseDataManager<PortalUser>, IPortalUserDao
    {
        private IMsCrmAccess _msCrmAccess;
        private ISqlAccess _sqlAccess;

        public PortalUserDao(IMsCrmAccess msCrmAccess, ISqlAccess sqlAccess)
        {
            _msCrmAccess = msCrmAccess;
            _sqlAccess = sqlAccess;
        }

        public Guid Insert(PortalUser entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            return service.Create(ent);
        }

        public void Update(PortalUser entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            service.Update(ent);
        }

        public void Delete(Guid Id)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            service.Delete("new_user", Id);
        }

        public PortalUser Get(Guid Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",Id)
            };

            DataTable dt = _sqlAccess.GetDataTable(PortalUserQueries.GET_PORTAL_USER, parameters);

            return dt.ToList<PortalUser>().FirstOrDefault();
        }

        public void AssociateTo(Guid Id, Entities.CustomEntities.EntityReferenceWrapper targetEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public void AssociateIn(Guid Id, Entities.CustomEntities.EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public PortalUser CheckLogin(string userName, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userName",userName),
                new SqlParameter("@password",password)
            };

            DataTable dt = _sqlAccess.GetDataTable(PortalUserQueries.CHECK_LOGIN, parameters);

            return dt.ToList<PortalUser>().FirstOrDefault();
        }
    }
}
