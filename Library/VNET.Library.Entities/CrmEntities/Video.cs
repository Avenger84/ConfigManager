using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Entities.CrmEntities
{
    [CrmSchemaName("new_video")]
    public class Video : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName("new_videoid")]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_name")]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_summary")]
        public string Summary { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_youtubeurl")]
        public string YoutubeUrl { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_otherurl")]
        public string OtherUrl { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_videourl")]
        public string VideoUrl { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName("new_imageurl")]
        public string ImageUrl { get; set; }
    }
}
