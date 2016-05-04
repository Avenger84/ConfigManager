using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Entities.CustomEntities
{
    public class UserSession
    {
        public string Token { get; set; }
        public EntityReferenceWrapper PortalId { get; set; }
        public EntityReferenceWrapper PortalUserId { get; set; }
        public EntityReferenceWrapper LanguageId { get; set; }
    }
}
