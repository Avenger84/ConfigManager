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
    public class ArticleBusiness : BaseEntityBusiness<Article>, IArticleBusiness
    {
        private IBaseDataManager<Article> _baseDataManager;
        private IArticleDao _articleDao;

        public ArticleBusiness(IBaseDataManager<Article> baseDataManager, IArticleDao articleDao)
            : base(baseDataManager)
        {
            _baseDataManager = baseDataManager;
            _articleDao = articleDao;
        }

        public List<Article> SearchArticle(string keyword)
        {
            return _articleDao.SearchArticle(keyword);
        }

        public List<Article> SearchArticleByCategoryId(Guid categoryId)
        {
            return _articleDao.SearchArticleByCategoryId(categoryId);
        }

        public List<Article> GetTopArticles()
        {
            return _articleDao.GetTopArticles();
        }

        public Guid InsertArticleLog(ArticleLog articleLog)
        {
            return _articleDao.InsertArticleLog(articleLog);
        }
    }
}
