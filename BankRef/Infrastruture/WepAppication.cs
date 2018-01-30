// 

using System;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Text;

namespace BankRef.Infrastruture
{
    public class WepAppication
    {
        private readonly string[] _internalUrlsStrings;

        public WepAppication(string[] urlsStrings)
        {
            if (urlsStrings == null)
                throw new ArgumentException(nameof(urlsStrings));
            _internalUrlsStrings = urlsStrings;

        }


        public void Initiallize()
        {

            while (true)
            {
                ListenerRequest();
            }



        }

        private void ListenerRequest()
        {
            var httpListener = new HttpListener();
            foreach (var internalUrlsString in _internalUrlsStrings)
                httpListener.Prefixes.Add(internalUrlsString);
            httpListener.Start();
            var context = httpListener.GetContext();
            var request = context.Request;
            var requestPath = request.Url.AbsolutePath;
            var response = context.Response;


            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = Utils.ConvertPath(requestPath);
            var resourceStream = assembly.GetManifestResourceStream(resourceName);

            if (resourceStream == null)
            {
                response.StatusCode = 404;
                response.OutputStream.Close();
            }
            else
            {
                var bytesResource = new byte[resourceStream.Length];
                resourceStream.Read(bytesResource, 0, (int)resourceStream.Length);

                response.ContentType = Utils.GetTypeContent(requestPath);
                response.StatusCode = 200;
                response.ContentLength64 = bytesResource.Length;
                response.OutputStream.Write(bytesResource, 0, bytesResource.Length);
                response.OutputStream.Close();

            }
           
            httpListener.Stop();
            
        }
    }
}
