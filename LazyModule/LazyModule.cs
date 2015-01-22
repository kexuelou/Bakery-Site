using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections;
using System.Diagnostics;

namespace LazyModule
{
    public class LazyModule : IHttpModule
    {

        private static List<HttpContext> historyRequest = new List<HttpContext>();
        private static HttpContext currentContext;
        public void Dispose()
        {
            return;
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
            context.EndRequest += new EventHandler(OnEndRequest);
            context.BeginRequest += new EventHandler(PreSendRequestHeaders);

            context.PreSendRequestHeaders += new EventHandler(OnBeginRequest);

            //System.Diagnostics.Trace.Listeners.Clear();
            //WAWSListener listener = new WAWSListener();
            //System.Diagnostics.Trace.Listeners.Add(listener);
        }

        private void OnBeginRequest(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpRequest request = app.Context.Request;

            Trace.TraceInformation("OnBeginRequest: " + request.Url.ToString());

            if (IsSpecialPage(request))
                return;

            if (request.Url.ToString().ToUpper().Contains("ORDER/1"))
            {
                System.Threading.Thread.Sleep(15000);
            }
        }

        private void PreSendRequestHeaders(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpRequest request = app.Context.Request;
            currentContext = app.Context;
            
            Trace.TraceInformation("PreSendRequestHeaders: " + request.Url.ToString());

            if (IsSpecialPage(request))
                return;

            if (request.Url.ToString().ToUpper().Contains("ORDER/2"))
            {
                Woops();
            }
        }

        private void OnPreRequestHandlerExecute(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpRequest request = app.Context.Request;
            
            Trace.TraceInformation("OnPreRequestHandlerExecute: " + request.Url.ToString());

            if (IsSpecialPage(request))
                return;

            if (request.Url.ToString().ToUpper().Contains("ORDER/6"))
            {
                throw new System.SystemException("woops, I dare to reject you!");
            }
        }

        private void OnEndRequest(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            for (int i = 0; i < 200; i++)
            {
                historyRequest.Add(app.Context);
            }
            
            Trace.TraceInformation("OnEndRequest: " + app.Context.Request.Url.ToString());
        }

        private void Woops()
        {
            for (int i = 0; i < 100; i++)
            {
                Fib(40);
            }
        }

        private int Fib(int n)
        {
            historyRequest.Add(currentContext);
            if (n < 3) return 1;
            return Fib(n - 1) + Fib(n-2);
        }

        private bool IsSpecialPage(HttpRequest request)
        {
            return request.Url.ToString().ToUpper().Contains("ERROR");
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
