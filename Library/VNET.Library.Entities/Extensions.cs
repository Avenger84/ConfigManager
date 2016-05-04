using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CustomEntities;
namespace VNET.Library.Entities
{
    public static class Extensions
    {
        public static EntityReferenceWrapper ToEntityReferenceWrapper(this object entityObject)
        {
            EntityReferenceWrapper returnValue = null;

            if (entityObject == null)
            {
                return null;
            }

            System.Reflection.MemberInfo info = entityObject.GetType();

            var schemaAttr = info.GetCustomAttributes(typeof(CrmSchemaName), false).OfType<CrmSchemaName>().FirstOrDefault();

            if (schemaAttr != null)
            {
                string entityName = schemaAttr.SchemaName;

                var id = entityObject.GetType().GetProperty("Id").GetValue(entityObject, null);
                var name = entityObject.GetType().GetProperty("Name").GetValue(entityObject, null);

                if (id != null && name != null)
                {
                    returnValue = new EntityReferenceWrapper();

                    returnValue.Id = (Guid)id;
                    returnValue.Name = name.ToString();
                    returnValue.LogicalName = entityName;
                }

                return returnValue;
            }
            else
            {
                return null;
            }
        }

    }
}
