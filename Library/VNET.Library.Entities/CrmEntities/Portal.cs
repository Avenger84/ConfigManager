using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.Entities.CrmEntities
{
    [CrmSchemaName("new_portal")]
    public class Portal : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName("new_portalid")]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_name")]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName("new_languageid")]
        public EntityReferenceWrapper LanguageId { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_loginimageurl")]
        public string LoginImageUrl { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_logoimageurl")]
        public string LogoImageUrl { get; set; }
    }
}
