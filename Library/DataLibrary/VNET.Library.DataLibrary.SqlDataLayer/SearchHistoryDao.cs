using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VNET.Library.Constants.SqlQueries;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.DataLibrary.SqlDataLayer
{
    public class SearchHistoryDao : IBaseDataManager<SearchHistory>, ISearchHistoryDao
    {
        private IMsCrmAccess _msCrmAccess;
        private ISqlAccess _sqlAccess;

        public SearchHistoryDao(IMsCrmAccess msCrmAccess, ISqlAccess sqlAccess)
        {
            _msCrmAccess = msCrmAccess;
            _sqlAccess = sqlAccess;
        }

        public Guid Insert(SearchHistory entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            return service.Create(ent);
        }

        public void Update(SearchHistory entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            service.Update(ent);
        }

        public void Delete(Guid Id)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            service.Delete("new_searchhistory", Id);
        }

        public SearchHistory Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void AssociateTo(Guid Id, Entities.CustomEntities.EntityReferenceWrapper targetEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public void AssociateIn(Guid Id, Entities.CustomEntities.EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public List<SearchHistory> GetSimilarSearches(string keyword)
        {
            DataTable dt = _sqlAccess.GetDataTable(string.Format(SearchHistoryQueries.SIMILAR_SEARCHES, keyword));

            return dt.ToList<SearchHistory>();
        }

        public List<SearchHistory> RecentSearches()
        {
            DataTable dt = _sqlAccess.GetDataTable(SearchHistoryQueries.RECENT_SEARCHES);

            return dt.ToList<SearchHistory>();
        }
    }
}
