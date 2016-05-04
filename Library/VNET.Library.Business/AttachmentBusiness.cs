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
    public class AttachmentBusiness : BaseEntityBusiness<Attachment>, IAttachmentBusiness
    {
        private IBaseDataManager<Attachment> _baseDataManager;
        private IAttachmentDao _attachmentDao;

        public AttachmentBusiness(IBaseDataManager<Attachment> baseDataManager, IAttachmentDao attachmentDao)
            : base(baseDataManager)
        {
            _baseDataManager = baseDataManager;
            _attachmentDao = attachmentDao;
        }

        public List<Attachment> GetArticleAttachments(Guid articleId)
        {
            return _attachmentDao.GetArticleAttachments(articleId);
        }
    }
}
