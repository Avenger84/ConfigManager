using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.DataLibrary.SqlDataLayer.Interfaces
{
    public interface ISearchHistoryDao
    {
        List<SearchHistory> GetSimilarSearches(string keyword);
        List<SearchHistory> RecentSearches();
    }
}
