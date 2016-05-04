using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNET.Library.Business.Interfaces;
using VNET.Library.ConfigManager;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.Constants;
using VNET.Library.Entities.CrmEntities;
using VNET.Library.IocManager;
using VNET.Web.Portal.Models;

namespace VNET.Web.Portal.Controllers
{
    public class LoginController : Controller
    {
        private readonly IContainer _container;
        private IConfigManager _configManager;
        private IBaseEntityBusiness<PortalUser> _portalUserBaseBusiness;
        private IPortalUserBusiness _portalUserBusiness;

        public LoginController()
        {
            var appSettings = ConfigurationManager.AppSettings;

            _configManager = new RegConfigManager(appSettings["RegName"]);

            var builder = new ContainerBuilder();

            builder.Register<IConfigManager>(c => new RegConfigManager("DoTest")).InstancePerLifetimeScope();

            builder = IocContainerBuilder.GetDataLayerIocContainer(builder, _configManager[RegKeys.CRM_CONNECTION_STRING]);
            builder = IocContainerBuilder.GetLoginControllerIocContainer(builder);

            _container = builder.Build();

            _portalUserBusiness = _container.Resolve<IPortalUserBusiness>();

            _portalUserBaseBusiness = _container.Resolve<IBaseEntityBusiness<PortalUser>>();
        }

        public ActionResult Index(SessionModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckLogin(SessionModel model)
        {
            PortalUser user = _portalUserBusiness.CheckLogin(model.UserName, model.Password);

            if (user != null)
            {
                model.PortalUser = user;

                Session["user"] = model;

                return Redirect("~/Home/Index");
            }
            else
            {
                model.ErrorMessage = "Kullanıcı adı veya Şifre doğrulanamadı.";
            }

            return View("Index", model);
        }
    }
}