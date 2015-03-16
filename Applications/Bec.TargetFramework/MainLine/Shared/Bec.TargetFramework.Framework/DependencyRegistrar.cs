using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Framework.Data;
using Bec.TargetFramework.Framework.Fakes;
using Bec.TargetFramework.Framework.Infrastructure;
using Bec.TargetFramework.Framework.Infrastructure.DependencyManagement;
using Bec.TargetFramework.Framework.Interfaces;
using Bec.TargetFramework.Framework.Plugins;
using Bec.TargetFramework.Web.Framework.EmbeddedViews;
using Bec.TargetFramework.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bec.TargetFramework.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerRequest();

            //controllers
            //builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            //data layer
          //  var dataSettingsManager = new DataSettingsManager();
          //  var dataProviderSettings = dataSettingsManager.LoadSettings();
           // builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
           // builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            //builder.RegisterType<EmbeddedViewResolver>().As<IEmbeddedViewResolver>().SingleInstance();
            

            // register route publisher
            //builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

            //plugins
            //builder.RegisterType<PluginFinder>().As<IPluginFinder>().InstancePerRequest();
       }

        public int Order
        {
            get { return 0; }
        }
    }


    public class SettingsSource : IRegistrationSource
    {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);

        public IEnumerable<IComponentRegistration> RegistrationsFor(
                Service service,
                Func<Service, IEnumerable<IComponentRegistration>> registrations)
        {
            var ts = service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        //static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        //{
        //    return RegistrationBuilder
        //        .ForDelegate((c, p) =>
        //        {
        //            var currentStoreId = c.Resolve<IStoreContext>().CurrentStore.Id;
        //            //uncomment the code below if you want load settings per store only when you have two stores installed.
        //            //var currentStoreId = c.Resolve<IStoreService>().GetAllStores().Count > 1
        //            //    c.Resolve<IStoreContext>().CurrentStore.Id : 0;

        //            //although it's better to connect to your database and execute the following SQL:
        //            //DELETE FROM [Setting] WHERE [StoreId] > 0
        //            return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
        //        })
        //        .InstancePerHttpRequest()
        //        .CreateRegistration();
        //}

        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
}
