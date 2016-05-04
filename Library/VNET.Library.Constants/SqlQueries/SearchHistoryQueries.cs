using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Constants.SqlQueries
{
    public class SearchHistoryQueries
    {
        #region | SIMILAR_SEARCHES |

        public const string SIMILAR_SEARCHES = @"SELECT
	                                                TOP 20
	                                                sh.new_name AS Name
                                                FROM
                                                new_searchhistory AS sh (NOLOCK)
                                                WHERE
                                                sh.new_name LIKE '%{0}%'
                                                AND
                                                sh.statecode=0 AND sh.new_name!='{0}'
                                                GROUP BY
	                                                sh.new_name
                                                ORDER BY COUNT(0) DESC";

        #endregion

        #region | RECENT_SEARCHES |

        public const string RECENT_SEARCHES = @"SELECT
	                                                DISTINCT
	                                                TOP 20
                                                    sh.new_name AS Name
                                                FROM
                                                new_searchhistory AS sh (NOLOCK)
                                                WHERE
                                                sh.statecode=0";

        #endregion
    }
}
