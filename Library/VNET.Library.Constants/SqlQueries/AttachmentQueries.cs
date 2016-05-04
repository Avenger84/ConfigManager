using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.Constants.SqlQueries
{
    public class AttachmentQueries
    {
        #region | GET_ARTICLE_ATTACHMENTS |

        public const string GET_ARTICLE_ATTACHMENTS = @"SELECT
	                                                        F.new_attachmentId Id
	                                                        ,F.new_name Name
	                                                        ,F.new_mimetype MimeType
                                                            ,F.new_filepath FilePath
                                                        FROM
                                                        new_new_article_new_attachment AS EA (NOLOCK)
	                                                        JOIN
		                                                        new_attachment AS F (NOLOCK)
			                                                        ON
			                                                        EA.new_attachmentid =F.new_attachmentId
                                                                    AND
                                                                    F.new_filepath IS NOT NULL
			                                                        AND
			                                                        F.statuscode=1 --Active
			                                                        AND
			                                                        F.statecode=0
                                                        WHERE
                                                        EA.new_articleid=@articleId";

        #endregion

        #region | GET_ATTACHMENT |

        public const string GET_ATTACHMENT = @"SELECT
	                                                att.new_attachmentId Id
	                                                ,att.new_name Name
	                                                ,att.new_mimetype MimeType
	                                                ,att.new_filepath FilePath
                                                FROM
                                                new_attachment AS att (NOLOCK)
                                                WHERE
                                                att.new_attachmentId=@Id";

        #endregion
    }
}
