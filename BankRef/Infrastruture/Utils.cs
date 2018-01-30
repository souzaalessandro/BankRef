// 

using System;
using System.Reflection;

namespace BankRef.Infrastruture
{
    public static class Utils
    {

        public static string ConvertPath(string path)
        {
            const string internalAssemblyName = "BankRef";

            var dotPath = path.Replace("/", ".");

            return $"{internalAssemblyName}{dotPath}";


        }

        public static string GetTypeContent(string path)
        {

            if (path.EndsWith(".css"))
                return "text/css; charset=utf-8";
            if (path.EndsWith(".js"))
                return "Application/js; charset=utf-8";
            if (path.EndsWith(".html"))
                return "text/html; charset=utf-8";

            throw new NotImplementedException("Informed type not locate");



        }


    }
}