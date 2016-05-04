using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.DataLibrary.SqlDataLayer.Interfaces
{
    public interface IArticleDao
    {
        List<Article> SearchArticle(string keyword);
        List<Article> SearchArticleByCategoryId(Guid categoryId);
        Guid InsertArticleLog(ArticleLog articleLog);
        List<Article> GetTopArticles();
    }
}
