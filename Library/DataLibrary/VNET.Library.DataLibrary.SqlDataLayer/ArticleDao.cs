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
    public class ArticleDao : IBaseDataManager<Article>, IArticleDao
    {
        private IMsCrmAccess _msCrmAccess;
        private ISqlAccess _sqlAccess;

        public ArticleDao(IMsCrmAccess msCrmAccess, ISqlAccess sqlAccess)
        {
            _msCrmAccess = msCrmAccess;
            _sqlAccess = sqlAccess;
        }

        public Guid Insert(Article entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            return service.Create(ent);
        }

        public void Update(Article entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            service.Update(ent);
        }

        public void Delete(Guid Id)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            service.Delete("new_article", Id);
        }

        public Article Get(Guid Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",Id)
            };

            DataTable dt = _sqlAccess.GetDataTable(ArticleQueries.GET_ARTICLE, parameters);

            return dt.ToList<Article>().FirstOrDefault();
        }

        public void AssociateTo(Guid Id, Entities.CustomEntities.EntityReferenceWrapper targetEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public void AssociateIn(Guid Id, Entities.CustomEntities.EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public List<Article> SearchArticle(string keyword)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@now",DateTime.Now)
            };

            DataTable dt = _sqlAccess.GetDataTable(string.Format(ArticleQueries.SEARCH_ARTICLE, keyword), parameters);

            return dt.ToList<Article>();
        }

        public List<Article> SearchArticleByCategoryId(Guid categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@categoryId",categoryId)
            };

            DataTable dt = _sqlAccess.GetDataTable(ArticleQueries.SEARCH_ARTICLE_BY_CATEGORYID, parameters);

            return dt.ToList<Article>();
        }

        public List<Article> GetTopArticles()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@now",DateTime.Now)
            };

            DataTable dt = _sqlAccess.GetDataTable(ArticleQueries.GET_TOP_ARTICLES, parameters);

            return dt.ToList<Article>();
        }

        public Guid InsertArticleLog(ArticleLog articleLog)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = articleLog.ToCrmEntity();

            return service.Create(ent);
        }
    }
}
