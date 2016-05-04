using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.Business.Interfaces
{
    public interface IArticleBusiness
    {
        List<Article> SearchArticle(string keyword);
        List<Article> SearchArticleByCategoryId(Guid categoryId);
        Guid InsertArticleLog(ArticleLog articleLog);
        List<Article> GetTopArticles();
    }
}
