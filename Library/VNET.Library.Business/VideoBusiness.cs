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
    public class VideoBusiness : BaseEntityBusiness<Video>, IVideoBusiness
    {
        private IBaseDataManager<Video> _baseDataManager;
        private IVideoDao _videoDao;

        public VideoBusiness(IBaseDataManager<Video> baseDataManager, IVideoDao videoDao)
            : base(baseDataManager)
        {
            _baseDataManager = baseDataManager;
            _videoDao = videoDao;
        }

        public List<Video> GetVideoListOfCategory(Guid categoryId)
        {
            return _videoDao.GetVideoListOfCategory(categoryId);
        }

        public List<Video> SearchVideo(string keyword, Guid categoryId)
        {
            return _videoDao.SearchVideo(keyword, categoryId);
        }

        public List<Video> GetTopVideos(Guid categoryId)
        {
            return _videoDao.GetTopVideos(categoryId);
        }

        public Guid InsertVideoLog(VideoLog videoLog)
        {
            return _videoDao.InsertVideoLog(videoLog);
        }
    }
}
