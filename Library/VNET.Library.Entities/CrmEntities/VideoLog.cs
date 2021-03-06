﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.Entities.CrmEntities
{
    [CrmSchemaName("new_videolog")]
    public class VideoLog : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName("new_videologid")]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_name")]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName("new_portalid")]
        public EntityReferenceWrapper PortalId { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName("new_userid")]
        public EntityReferenceWrapper UserId { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName("new_videoid")]
        public EntityReferenceWrapper VideoId { get; set; }
    }
}
