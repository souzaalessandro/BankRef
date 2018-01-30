// 

using System;
using System.Net;

namespace BankRef.Infrastruture
{
    public class WepAppication
    {
        private readonly string[] _internalUrlsStrings;

        public WepAppication(string[] urlsStrings)
        {
            if ( urlsStrings ==null)
                throw new ArgumentException(nameof(urlsStrings));
            _internalUrlsStrings = urlsStrings;

        }


        public void Initiallize()
        {
            var httpListener = new HttpListener();
            foreach (var internalUrlsString in _internalUrlsStrings)
                httpListener.Prefixes.Add(internalUrlsString);
            httpListener.Start();
        }
    }
}