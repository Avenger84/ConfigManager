using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.Business.Interfaces
{
    public interface IVideoBusiness
    {
        List<Video> GetVideoListOfCategory(Guid categoryId);
        List<Video> SearchVideo(string keyword, Guid categoryId);
        Guid InsertVideoLog(VideoLog videoLog);
        List<Video> GetTopVideos(Guid categoryId);
    }
}
