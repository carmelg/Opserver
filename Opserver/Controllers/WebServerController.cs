using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Jil;
using StackExchange.Opserver.Data.Dashboard;
using StackExchange.Opserver.Models;
using StackExchange.Opserver.Views.Dashboard;
using System;
using System.Collections.Generic;

namespace StackExchange.Opserver.Controllers
{
    public partial class WebServerController : StatusController
    {
        public override ISecurableModule SettingsModule => Current.Settings.WebServer;

        public override TopTab TopTab => new TopTab("WebServer R@", nameof(Dashboard), this, 0);

        [Route("webserver")]
        public ActionResult Dashboard(string q)
        {
            var vd = new DashboardModel
            {
                Nodes = GetNodes("Web Servers Recuper@"),
                ErrorMessages = DashboardModule.ProviderExceptions.ToList(),
                Filter = q,
                IsStartingUp = DashboardModule.AnyDoingFirstPoll
            };
            return View(Current.IsAjaxRequest ? "Dashboard.Table" : "Dashboard", vd);
        }

        private List<Node> GetNodes(string category) =>
            DashboardCategory.AllCategories.FirstOrDefault(x => x.Name == category).Nodes;
    }
}
