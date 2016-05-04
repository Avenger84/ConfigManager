using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Entities.CustomEntities
{
    public class MsCrmResult
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string Result { get; set; }
        public bool HasException { get; set; }
    }
}
