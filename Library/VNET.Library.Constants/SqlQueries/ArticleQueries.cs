using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Constants.SqlQueries
{
    public class ArticleQueries
    {
        #region | SEARCH_ARTICLE |

        public const string SEARCH_ARTICLE = @"SELECT
	                                                a.new_articleId AS Id
	                                                ,a.new_name AS Name
	                                                ,a.new_summary AS Summary
	                                                ,a.new_content AS Content
	                                                ,a.new_imageurl AS ImageUrl
                                                    ,a.new_learnbyread AS LearnByRead
                                                    ,a.new_learnbypractise AS LearnByPractise
                                                    ,a.new_learnbywatching AS LearnByWatch
                                                    ,a.new_learnbyteam AS LearnByTeam
                                                    ,a.new_learnbyqdms AS LearnByQdms
                                                FROM
                                                new_article AS a (NOLOCK)
                                                WHERE
                                                a.StateCode=0 AND a.new_iskeydocument=1
                                                AND
                                                @now BETWEEN a.new_startdate AND a.new_enddate
                                                AND
                                                (
	                                                a.new_name LIKE '%{0}%'
	                                                OR
	                                                a.new_hashtags LIKE '%{0}%'
                                                )";

        #endregion

        #region | SEARCH_ARTICLE_BY_CATEGORYID |

        public const string SEARCH_ARTICLE_BY_CATEGORYID = @"SELECT
                                                                a.new_articleId AS Id
                                                                ,a.new_name AS Name
                                                                ,a.new_summary AS Summary
                                                                ,a.new_content AS Content
                                                                ,a.new_imageurl AS ImageUrl
                                                                ,a.new_learnbyread AS LearnByRead
                                                                ,a.new_learnbypractise AS LearnByPractise
                                                                ,a.new_learnbywatching AS LearnByWatch
                                                            FROM
                                                            new_article AS a (NOLOCK)
                                                            WHERE
                                                            a.StateCode=0
                                                            AND
                                                            a.new_categoryId=@categoryId";

        #endregion

        #region | GET_ARTICLE |

        public const string GET_ARTICLE = @"SELECT
	                                                a.new_articleId AS Id
	                                                ,a.new_name AS Name
	                                                ,a.new_summary AS Summary
	                                                ,a.new_content AS Content
	                                                ,a.new_imageurl AS ImageUrl
                                                    ,a.new_learnbyread AS LearnByRead
                                                    ,a.new_learnbypractise AS LearnByPractise
                                                    ,a.new_learnbywatching AS LearnByWatch
                                                    ,a.new_learnbyteam AS LearnByTeam
                                                    ,a.new_learnbyqdms AS LearnByQdms
                                                FROM
                                                new_article AS a (NOLOCK)
                                                WHERE
                                                a.new_articleId=@Id";

        #endregion

        #region | GET_TOP_ARTICLES |

        public const string GET_TOP_ARTICLES = @"SELECT
                                                    a.new_articleId AS Id
                                                    ,a.new_name AS Name
                                                    ,a.new_summary AS Summary
                                                    ,a.new_content AS Content
                                                    ,a.new_imageurl AS ImageUrl
                                                    ,a.new_learnbyread AS LearnByRead
                                                    ,a.new_learnbypractise AS LearnByPractise
                                                    ,a.new_learnbywatching AS LearnByWatch
                                                    ,a.new_learnbyteam AS LearnByTeam
                                                    ,a.new_learnbyqdms AS LearnByQdms
                                                FROM
                                                new_article AS a (NOLOCK)
                                                WHERE
                                                a.StateCode=0 
                                                AND 
                                                a.new_iskeydocument=1
                                                AND
                                                @now BETWEEN a.new_startdate AND a.new_enddate
                                                AND
                                                a.new_articleId IN
                                                (
                                                    SELECT
	                                                TOP 10
	                                                al.new_articleId
	                                                FROM
	                                                new_articlelog AS al (NOLOCK)
	                                                WHERE
	                                                al.new_name='ANAHTAR'
	                                                AND
	                                                al.new_articleId IS NOT NULL
	                                                GROUP BY
		                                                al.new_articleId
	                                                ORDER BY
		                                                COUNT(0) DESC	
                                                )";

        #endregion
    }
}
