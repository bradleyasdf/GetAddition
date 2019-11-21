using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ProxyLib
{
    public class VerifyProxy
    {
        public bool IsProxyWorking(string proxyServer, string url, List<string> expectedFields, List<string> expectedValue)
        {
            bool result = true;
            //WinINet.SetConnectionProxy(true, proxyServer, isPac);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Proxy = new WebProxy(proxyServer);
            request.Method = "GET";
            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                string str = reader.ReadToEnd();
                if (!String.IsNullOrWhiteSpace(str))
                {
                    foreach (string field in expectedFields)
                    {
                        if (str.IndexOf(field) < 0)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result)
                    {
                        foreach (string value in expectedValue)
                        {
                            if (str.IndexOf(value) < 0)
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
