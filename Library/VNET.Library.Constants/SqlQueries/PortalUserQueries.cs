using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Constants.SqlQueries
{
    public class PortalUserQueries
    {
        #region | CHECK_LOGIN |

        public const string CHECK_LOGIN = @"SELECT
	                                            u.new_userId AS Id
	                                            ,u.new_name AS Name
	                                            ,u.new_contactId AS ContactId
	                                            ,u.new_contactIdName AS ContactIdName
	                                            ,'contact' AS ContactIdTypeName
                                            FROM
                                            new_user AS u (NOLOCK)
                                            WHERE
                                            u.new_name=@userName
                                            AND
                                            u.new_password=@password
                                            AND
                                            u.StateCode=0
                                            AND
                                            u.StatusCode=1 --Active";

        #endregion

        #region | GET_PORTAL_USER |

        public const string GET_PORTAL_USER = @"SELECT
	                                                u.new_userId AS Id
	                                                ,u.new_name AS Name
	                                                ,u.new_contactId AS ContactId
	                                                ,u.new_contactIdName AS ContactIdName
	                                                ,'contact' AS ContactIdTypeName
                                                FROM
                                                new_user AS u (NOLOCK)
                                                WHERE
                                                u.new_userId=@Id";

        #endregion
    }
}
