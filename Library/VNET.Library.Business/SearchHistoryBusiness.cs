using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Business.Interfaces;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.Business
{
    public class SearchHistoryBusiness : BaseEntityBusiness<SearchHistory>, ISearchHistoryBusiness
    {
        private IBaseDataManager<SearchHistory> _baseDataManager;
        private ISearchHistoryDao _searchHistoryDao;

        public SearchHistoryBusiness(IBaseDataManager<SearchHistory> baseDataManager
            , ISearchHistoryDao searchHistoryDao)
            : base(baseDataManager)
        {
            _baseDataManager = baseDataManager;
            _searchHistoryDao = searchHistoryDao;
        }

        public List<SearchHistory> GetSimilarSearches(string keyword)
        {
            return _searchHistoryDao.GetSimilarSearches(keyword);
        }

        public List<SearchHistory> RecentSearches()
        {
            return _searchHistoryDao.RecentSearches();
        }
    }
}
