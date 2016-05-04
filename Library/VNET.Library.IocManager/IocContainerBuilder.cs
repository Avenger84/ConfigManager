using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Castle.DynamicProxy;
using VNET.Library.DataLibrary.SqlDataLayer.Interfaces;
using VNET.Library.DataLibrary.SqlDataLayer;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.ConfigManager;
using VNET.Library.Business.Interfaces;
using VNET.Library.Business;
using VNET.Library.Entities.CrmEntities;
using VNET.Library.DataLibrary.Interfaces;

namespace VNET.Library.IocManager
{
    public class IocContainerBuilder
    {
        private const string SQL_ACCESS_CRM = "SQL_ACCESS_CRM";

        public static ContainerBuilder GetDataLayerIocContainer(ContainerBuilder builder, string connectionString)
        {
            builder.Register<ISqlAccess>(c => new SqlAccess(connectionString)).Named<ISqlAccess>(SQL_ACCESS_CRM).InstancePerLifetimeScope();
            builder.Register<IMsCrmAccess>(c => new MsCrmAccess(true, c.Resolve<IConfigManager>())).InstancePerDependency();

            return builder;
        }

        public static ContainerBuilder GetSearchControllerIocContainer(ContainerBuilder builder)
        {
            #region | DATA |

            builder.Register<IBaseDataManager<Article>>(c => new ArticleDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            builder.Register<IBaseDataManager<SearchHistory>>(c => new SearchHistoryDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            builder.Register<IBaseDataManager<Attachment>>(c => new AttachmentDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            builder.Register<IArticleDao>(c => new ArticleDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            builder.Register<ISearchHistoryDao>(c => new SearchHistoryDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            builder.Register<IAttachmentDao>(c => new AttachmentDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            #endregion

            #region | BUSINESS |

            builder.Register<IArticleBusiness>(c => new ArticleBusiness(c.Resolve<IBaseDataManager<Article>>()
                , c.Resolve<IArticleDao>()))
                .InstancePerDependency();

            builder.Register<IBaseEntityBusiness<SearchHistory>>(c => new SearchHistoryBusiness(c.Resolve<IBaseDataManager<SearchHistory>>()
                , c.Resolve<ISearchHistoryDao>()))
                .InstancePerDependency();

            builder.Register<IBaseEntityBusiness<Article>>(c => new ArticleBusiness(c.Resolve<IBaseDataManager<Article>>()
                , c.Resolve<IArticleDao>()))
                .InstancePerDependency();

            builder.Register<IBaseEntityBusiness<Attachment>>(c => new AttachmentBusiness(c.Resolve<IBaseDataManager<Attachment>>()
                , c.Resolve<IAttachmentDao>()))
                .InstancePerDependency();

            builder.Register<ISearchHistoryBusiness>(c => new SearchHistoryBusiness(c.Resolve<IBaseDataManager<SearchHistory>>()
                , c.Resolve<ISearchHistoryDao>()))
                .InstancePerDependency();

            builder.Register<IAttachmentBusiness>(c => new AttachmentBusiness(c.Resolve<IBaseDataManager<Attachment>>()
                , c.Resolve<IAttachmentDao>()))
                .InstancePerDependency();

            #endregion

            return builder;
        }

        public static ContainerBuilder GetVideoControllerIocContainer(ContainerBuilder builder)
        {
            #region | DATA |

            builder.Register<IBaseDataManager<Video>>(c => new VideoDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            builder.Register<IVideoDao>(c => new VideoDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            #endregion

            #region | BUSINESS |

            builder.Register<IBaseEntityBusiness<Video>>(c => new VideoBusiness(c.Resolve<IBaseDataManager<Video>>()
                , c.Resolve<IVideoDao>()))
                .InstancePerDependency();

            builder.Register<IVideoBusiness>(c => new VideoBusiness(c.Resolve<IBaseDataManager<Video>>()
                , c.Resolve<IVideoDao>()))
                .InstancePerDependency();

            #endregion

            return builder;
        }

        public static ContainerBuilder GetLoginControllerIocContainer(ContainerBuilder builder)
        {
            #region | DATA |

            builder.Register<IBaseDataManager<PortalUser>>(c => new PortalUserDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            builder.Register<IPortalUserDao>(c => new PortalUserDao(c.Resolve<IMsCrmAccess>()
                , c.ResolveNamed<ISqlAccess>(SQL_ACCESS_CRM)))
                .InstancePerDependency();

            #endregion

            #region | BUSINESS |

            builder.Register<IBaseEntityBusiness<PortalUser>>(c => new PortalUserBusiness(c.Resolve<IBaseDataManager<PortalUser>>()
                , c.Resolve<IPortalUserDao>()))
                .InstancePerDependency();

            builder.Register<IPortalUserBusiness>(c => new PortalUserBusiness(c.Resolve<IBaseDataManager<PortalUser>>()
                , c.Resolve<IPortalUserDao>()))
                .InstancePerDependency();

            #endregion

            return builder;
        }
    }
}
