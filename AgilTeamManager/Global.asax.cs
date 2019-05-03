using AgilTeamManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AgilTeamManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ConfiguracoesIniciais cfgIni = new ConfiguracoesIniciais();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            cfgIni.AdicionaPrimeiraConfig();
            cfgIni.AdicionarEventosPadroes();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            cfgIni = new ConfiguracoesIniciais();
            cfgIni.SetarLinguagemDoSistema();
        }
    }
}
