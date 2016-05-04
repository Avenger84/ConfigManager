using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Business.Interfaces;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.Entities.CustomEntities;

namespace VNET.Library.Business
{
    public class BaseEntityBusiness<T> : IBaseEntityBusiness<T>
    {
        private IBaseDataManager<T> _baseDataManager;

        public BaseEntityBusiness(IBaseDataManager<T> baseDataManager)
        {
            _baseDataManager = baseDataManager;
        }

        public Guid Insert(T entity)
        {
            return _baseDataManager.Insert(entity);
        }

        public void Update(T entity)
        {
            _baseDataManager.Update(entity);
        }

        public void Delete(Guid Id)
        {
            _baseDataManager.Delete(Id);
        }

        public T Get(Guid Id)
        {
            return _baseDataManager.Get(Id);
        }

        public void AssociateTo(Guid Id, EntityReferenceWrapper targetEntity, string relationShipName)
        {
            _baseDataManager.AssociateTo(Id, targetEntity, relationShipName);
        }

        public void AssociateIn(Guid Id, EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            _baseDataManager.AssociateIn(Id, sourceEntity, relationShipName);
        }
    }
}
