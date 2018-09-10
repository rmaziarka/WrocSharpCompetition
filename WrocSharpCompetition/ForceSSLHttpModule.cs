using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace WrocSharpCompetition
{
    public class ForceSSLHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (obj, e) => ContextBeginRequest(context);
        }
        private void ContextBeginRequest(HttpApplication context)
        {
            AntiForgeryConfig.RequireSsl = true;

            switch (context.Request.Url.Scheme)
            {
                case "https":
                    context.Response.AddHeader("Strict-Transport-Security", "max-age=300");
                    break;
                case "http":
                    var path = "https://" + context.Request.Url.Host + context.Request.Url.PathAndQuery;
                    context.Response.Status = "301 Moved Permanently";
                    context.Response.AddHeader("Location", path);
                    break;
            }
        }


        public void Dispose()
        {
        }
    }
}