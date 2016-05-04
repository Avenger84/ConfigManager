using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Constants.SqlQueries
{
    public class VideoQueries
    {
        #region | SEARCH_VIDEO |

        public const string SEARCH_VIDEO = @"SELECT
	                                                v.new_videoId AS Id
	                                                ,v.new_name AS Name
	                                                ,v.new_summary AS Summary
	                                                ,v.new_youtubeurl AS YoutubeUrl
	                                                ,v.new_otherurl AS OtherUrl
	                                                ,v.new_videourl AS VideoUrl
	                                                ,v.new_imageurl AS ImageUrl
	                                                ,v.CreatedOn
	                                                ,v.ModifiedOn
                                                FROM
                                                new_video AS v (NOLOCK)
                                                WHERE
                                                v.StateCode=0 AND v.new_categoryId=@categoryId
                                                AND
                                                (
	                                                v.new_name LIKE '%{0}%'
	                                                OR
	                                                v.new_hashtags LIKE '%{0}%'
                                                )";

        #endregion

        #region | GET_VIDEO_LIST_BY_CATEGORY |

        public const string GET_VIDEO_LIST_BY_CATEGORY = @"SELECT
	                                                            v.new_videoId AS Id
	                                                            ,v.new_name AS Name
	                                                            ,v.new_summary AS Summary
	                                                            ,v.new_youtubeurl AS YoutubeUrl
	                                                            ,v.new_otherurl AS OtherUrl
	                                                            ,v.new_videourl AS VideoUrl
	                                                            ,v.new_imageurl AS ImageUrl
	                                                            ,v.CreatedOn
	                                                            ,v.ModifiedOn
                                                            FROM
                                                            new_video AS v (NOLOCK)
                                                            WHERE
                                                            v.new_categoryId=@categoryId
                                                            AND
                                                            v.statecode=0";

        #endregion

        #region | GET_VIDEO |

        public const string GET_VIDEO = @"SELECT
	                                        v.new_videoId AS Id
	                                        ,v.new_name AS Name
	                                        ,v.new_summary AS Summary
	                                        ,v.new_youtubeurl AS YoutubeUrl
	                                        ,v.new_otherurl AS OtherUrl
	                                        ,v.new_videourl AS VideoUrl
	                                        ,v.new_imageurl AS ImageUrl
	                                        ,v.CreatedOn
	                                        ,v.ModifiedOn
                                        FROM
                                        new_video AS v (NOLOCK)
                                        WHERE
                                        v.new_videoId=@Id";

        #endregion

        #region | GET_TOP_VIDEOS_BY_CATEGORYID |

        public const string GET_TOP_VIDEOS_BY_CATEGORYID = @"SELECT
                                                                    v.new_videoId AS Id
                                                                    ,v.new_name AS Name
                                                                    ,v.new_summary AS Summary
                                                                    ,v.new_youtubeurl AS YoutubeUrl
                                                                    ,v.new_otherurl AS OtherUrl
                                                                    ,v.new_videourl AS VideoUrl
                                                                    ,v.new_imageurl AS ImageUrl
                                                                    ,v.CreatedOn
                                                                    ,v.ModifiedOn
                                                                FROM
                                                                new_video AS v (NOLOCK)
                                                                WHERE
                                                                v.StateCode=0 
                                                                AND 
                                                                v.new_categoryId=@categoryId
                                                                AND
                                                                v.new_videoId IN
                                                                (
                                                                   SELECT
	                                                                TOP 10
	                                                                vl.new_videoId
	                                                                FROM
	                                                                new_videolog AS vl (NOLOCK)
	                                                                WHERE
	                                                                vl.new_name='ANAHTAR'
	                                                                AND
	                                                                vl.new_videoId IS NOT NULL
	                                                                GROUP BY
		                                                                vl.new_videoId
	                                                                ORDER BY
		                                                                COUNT(0) DESC	
                                                                )";

        #endregion
    }
}
