using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LazyModule
{
    public class LazyModule : IHttpModule
    {
        public void Dispose()
        {
            return;
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
            //context.EndRequest += new EventHandler(OnEndRequest);
            //context.BeginRequest += new EventHandler(OnBeginRequest);

            context.PreSendRequestHeaders += new EventHandler(OnBeginRequest);

            //System.Diagnostics.Trace.Listeners.Clear();
            //WAWSListener listener = new WAWSListener();
            //System.Diagnostics.Trace.Listeners.Add(listener);
        }

        private void OnPreRequestHandlerExecute(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpRequest request = app.Context.Request;

            if (request.Url.ToString().ToUpper().Contains("ORDER/6"))
            {
                throw new System.SystemException("woops, I dare to reject you!");
            }
        }

        private void OnBeginRequest(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpRequest request = app.Context.Request;

            if (request.Url.ToString().ToUpper().Contains("ORDER/1"))
            {
                System.Threading.Thread.Sleep(15000);
            }
        }

        //private void OnEndRequest(Object source, EventArgs e)
        //{
        //    HttpApplication app = (HttpApplication)source;
        //    HttpRequest request = app.Context.Request;

        //    if (request.Url.ToString().ToUpper().Contains("Exception"))
        //    {
        //        throw new System.SystemException("woops, I won't tell you what's wrong!");
        //    }
        //}

        //private void OnSendReuqestHeaders(Object source, EventArgs e)
        //{
        //    HttpApplication curApp = (HttpApplication)source;
        //    HttpResponse response = curApp.Context.Response;
        //    response.StatusCode = 500;
        //    response.SubStatusCode = 19;

        //}
    }
}
