using FluentValidation.Mvc;
using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Concrete.Managers;
using ProductStockTracking.Business.DepandencyResolvers.Ninject;
using ProductStockTracking.Core.CrossCuttingConcerns.Security.Web;
using ProductStockTracking.Core.CrossCuttingConcerns.Validation.FluentValidation;
using ProductStockTracking.Core.Utilities.Mvc.Infrastructure;
using ProductStockTracking.DataAccess.Abstract;
using ProductStockTracking.DataAccess.Concrete.EntityFramework;
using ProductStockTracking.MvcWebUI.Filters;
using ProductStockTracking.MvcWebUI.StartupTasks;
using ProductStockTracking.MvcWebUI.StartupTasks.StartupInit;
using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace ProductStockTracking.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new StartupTaskModule()));
            //GlobalFilters.Filters.Add(new HandleErrorAttribute());
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
            });

            StarUpInit();

        }
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtlities = new SecurityUtilities();
                var identity = securityUtlities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;


            }
            catch (Exception)
            {

            }


        }

        private void StarUpInit()
        {
            //var asa = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IStartupTask));
            //var a =   DependencyResolver.Current.GetServices(typeof(IStartupTask)) as IEnumerable<IStartupTask>;
            //foreach (var item in a)
            //{
            //    item.Run();
            //}


            var roleStartupTask = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleStartupTask)) as RoleStartupTask;

            if (roleStartupTask==null)
            {
                roleStartupTask = new RoleStartupTask(new RoleManager(new EfRoleDal()));
            }
            roleStartupTask.Run();
        }
    }
}

