using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.Business.Interfaces
{
    public interface IBaseEntityBusiness<TEntityType>
    {
        Guid Insert(TEntityType entity);
        void Update(TEntityType entity);
        void Delete(Guid Id);
        TEntityType Get(Guid Id);
        void AssociateTo(Guid Id, EntityReferenceWrapper targetEntity, string relationShipName);
        void AssociateIn(Guid Id, EntityReferenceWrapper sourceEntity, string relationShipName);
    }
}
