using Microsoft.Crm.Sdk.Messages;
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
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.DataLibrary.SqlDataLayer
{
    public class AttachmentDao : IBaseDataManager<Attachment>, IAttachmentDao
    {
        private IMsCrmAccess _msCrmAccess;
        private ISqlAccess _sqlAccess;

        public AttachmentDao(IMsCrmAccess msCrmAccess, ISqlAccess sqlAccess)
        {
            _msCrmAccess = msCrmAccess;
            _sqlAccess = sqlAccess;
        }

        public Guid Insert(Attachment entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            return service.Create(ent);
        }

        public void Update(Attachment entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            service.Update(ent);
        }

        public void Delete(Guid Id)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            service.Delete("new_attachment", Id);
        }

        public Attachment Get(Guid Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",Id)
            };

            DataTable dt = _sqlAccess.GetDataTable(AttachmentQueries.GET_ATTACHMENT, parameters);

            return dt.ToList<Attachment>().FirstOrDefault();
        }

        public void AssociateTo(Guid Id, EntityReferenceWrapper targetEntity, string relationShipName)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            AssociateEntitiesRequest request = new AssociateEntitiesRequest();
            request.Moniker1 = new EntityReference("new_attachment", Id);
            request.Moniker2 = targetEntity.ToCrmEntityReference();
            request.RelationshipName = relationShipName;

            service.Execute(request);
        }

        public void AssociateIn(Guid Id, EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public List<Attachment> GetArticleAttachments(Guid articleId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@articleId",articleId)
            };

            DataTable dt = _sqlAccess.GetDataTable(AttachmentQueries.GET_ARTICLE_ATTACHMENTS, parameters);

            return dt.ToList<Attachment>();
        }
    }
}
