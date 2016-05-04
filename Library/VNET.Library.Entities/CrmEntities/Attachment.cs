using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Entities.CrmEntities
{
    [CrmSchemaName("new_attachment")]
    public class Attachment : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName("new_attachmentid")]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_name")]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_filepath")]
        public string FilePath { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_mimetype")]
        public string MimeType { get; set; }
    }
}
