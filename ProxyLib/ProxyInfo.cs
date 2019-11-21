using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyLib
{
    public class ProxyInfo
    {
        public string ServerName { get; set; }
        public string Port { get; set; }
        public bool IsPac { get; set; }
        public string[] Domains { get; set; }
        public bool IsMachineSetting { get; set; }
    }
}
