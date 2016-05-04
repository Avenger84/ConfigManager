using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.Business.Interfaces
{
    public interface IAttachmentBusiness
    {
        List<Attachment> GetArticleAttachments(Guid articleId);
    }
}
