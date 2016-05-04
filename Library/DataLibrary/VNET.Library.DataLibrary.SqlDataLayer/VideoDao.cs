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
    public class VideoDao : IBaseDataManager<Video>, IVideoDao
    {
        private IMsCrmAccess _msCrmAccess;
        private ISqlAccess _sqlAccess;

        public VideoDao(IMsCrmAccess msCrmAccess, ISqlAccess sqlAccess)
        {
            _msCrmAccess = msCrmAccess;
            _sqlAccess = sqlAccess;
        }

        public Guid Insert(Video entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            return service.Create(ent);
        }

        public void Update(Video entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            service.Update(ent);
        }

        public void Delete(Guid Id)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            service.Delete("new_video", Id);
        }

        public Video Get(Guid Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",Id)
            };

            DataTable dt = _sqlAccess.GetDataTable(VideoQueries.GET_VIDEO, parameters);

            return dt.ToList<Video>().FirstOrDefault();
        }

        public void AssociateTo(Guid Id, Entities.CustomEntities.EntityReferenceWrapper targetEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public void AssociateIn(Guid Id, Entities.CustomEntities.EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetVideoListOfCategory(Guid categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@categoryId",categoryId)
            };

            DataTable dt = _sqlAccess.GetDataTable(VideoQueries.GET_VIDEO_LIST_BY_CATEGORY, parameters);

            return dt.ToList<Video>();
        }

        public List<Video> SearchVideo(string keyword, Guid categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@now",DateTime.Now),
                new SqlParameter("@categoryId",categoryId)
            };

            DataTable dt = _sqlAccess.GetDataTable(string.Format(VideoQueries.SEARCH_VIDEO, keyword), parameters);

            return dt.ToList<Video>();
        }

        public List<Video> GetTopVideos(Guid categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@categoryId",categoryId)
            };

            DataTable dt = _sqlAccess.GetDataTable(VideoQueries.GET_TOP_VIDEOS_BY_CATEGORYID, parameters);

            return dt.ToList<Video>();
        }

        public Guid InsertVideoLog(VideoLog videoLog)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = videoLog.ToCrmEntity();

            return service.Create(ent);
        }
    }
}
