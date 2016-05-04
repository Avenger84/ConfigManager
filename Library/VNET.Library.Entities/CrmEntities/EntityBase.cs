using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.Entities.CrmEntities
{
    public class EntityBase
    {
        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName("statuscode")]
        public OptionSetValueWrapper Status { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        public DateTime? CreatedOn { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        public DateTime? ModifiedOn { get; set; }

        public string CreatedOnString
        {
            get
            {
                if (CreatedOn != null)
                {
                    return ((DateTime)CreatedOn).ToString("dd.MM.yyyy HH:mm");
                }
                else
                {
                    return null;
                }
            }
        }

        public string ModifiedOnString
        {
            get
            {
                if (ModifiedOn != null)
                {
                    return ((DateTime)ModifiedOn).ToString("dd.MM.yyyy HH:mm");
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
