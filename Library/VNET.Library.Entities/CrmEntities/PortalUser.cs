using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.Entities.CrmEntities
{
    [CrmSchemaName("new_user")]
    public class PortalUser : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName("new_userid")]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_name")]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName("new_languageid")]
        public EntityReferenceWrapper LanguageId { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName("new_contactid")]
        public EntityReferenceWrapper ContactId { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName("new_iswelcome")]
        public bool? IsWelcomeMessageGenerated { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName("new_iscontractapproved")]
        public bool? IsDisclaimerApproveGenerated { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName("new_contactapprovedate")]
        public DateTime? DisclaimerApproveDate { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_imageurl")]
        public string ProfileImageUrl { get; set; }

        public DateTime? FirstLoginDate { get; set; }
        public DateTime? PasswordChangeDate { get; set; }
        public Contact ContactInfo { get; set; }
        public List<PortalRole> UserRoles { get; set; }

    }

    public enum PortalUserStatus
    {
        ACTIVE = 1,
        PENDING = 100000000
    }
}
