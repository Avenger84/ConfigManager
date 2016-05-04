using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Entities.CrmEntities
{
    [CrmSchemaName("new_article")]
    public class Article : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName("new_articleid")]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_name")]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_summary")]
        public string Summary { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_content")]
        public string Content { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_imageurl")]
        public string ImageUrl { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_learnbyread")]
        public string LearnByRead { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_learnbypractise")]
        public string LearnByPractise { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_learnbywatching")]
        public string LearnByWatch { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_learnbyteam")]
        public string LearnByTeam { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_learnbyqdms")]
        public string LearnByQdms { get; set; }

        public List<Attachment> AttachmentList { get; set; }
    }
}
