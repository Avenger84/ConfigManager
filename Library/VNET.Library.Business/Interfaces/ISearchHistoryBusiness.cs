using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.Business.Interfaces
{
    public interface ISearchHistoryBusiness
    {
        List<SearchHistory> GetSimilarSearches(string keyword);
        List<SearchHistory> RecentSearches();
    }
}
