using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using System.Reflection;

namespace ProxyLib
{
    public class SetProxy
    {
        private List<ProxyInfo> _proxyList;
        private Timer _timer;
        private int _currentIdx = 0;
        private string _pacTemplate;
        private bool _isRewind;

        public double SwitchInterval 
        { 
            get
            {
                return _timer.Interval;
            }
            set
            {
                _timer.Interval = value;
            }
        }

        public void SetPacProxy(string pacPath)
        {
            WinINet.SetConnectionProxy(true, pacPath, true);
        }

        public void DisableProxy()
        {
            WinINet.DisableSystemProxy();
        }

        public void SetHttpProxy(string proxyServer, bool isMachineSetting)
        {
            WinINet.SetConnectionProxy(isMachineSetting, proxyServer, false);
        }

        public void DisableSwitch()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        public SetProxy()
        {
            _pacTemplate = File.ReadAllText("pacTemplate.pac");
        }

        public SetProxy(List<ProxyInfo> proxyList, int interval, bool isRewind)
            : this()
        {
            _proxyList = proxyList;
            _isRewind = isRewind;
            _timer = new Timer();
            _timer.Elapsed += onElapsed;
            _timer.Interval = interval;
            _timer.Start();
        }

        private void onElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            if (_proxyList != null && _proxyList.Count > 0)
            {
                while (_currentIdx < _proxyList.Count)
                {
                    bool isMachieSetting = true;
                    bool isPac = false;
                    string proxy = "";
                    if (_proxyList[_currentIdx].IsPac)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < _proxyList[_currentIdx].Domains.Length; i++)
                        {
                            if (i > 0)
                            {
                                sb.Append(",'" + _proxyList[_currentIdx].Domains[i] + "'");
                            }
                            else
                            {
                                sb.Append("'" + _proxyList[_currentIdx].Domains[i] + "'");
                            }
                        }
                        string txt = _pacTemplate.Replace("%URLPATTERNS%", sb.ToString())
                            .Replace("%PROXY%", _proxyList[_currentIdx].ServerName + ":"
                            + _proxyList[_currentIdx].Port.ToString());
                        File.WriteAllText("pactest.pac", txt);
                        proxy = "file://" + Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                            "pactest.pac").Replace("\\", "/");
                        isMachieSetting = true;
                        isPac = true;
                    }
                    else
                    {
                        proxy = _proxyList[_currentIdx].ServerName + ":"
                            + _proxyList[_currentIdx].Port.ToString();
                        isMachieSetting = _proxyList[_currentIdx].IsMachineSetting;
                        isPac = false;
                    }
                    try
                    {
                        WinINet.SetConnectionProxy(isMachieSetting, proxy, isPac);
                        if (_currentIdx == _proxyList.Count - 1)
                        {
                            if (_isRewind)
                            {
                                _currentIdx = 0;
                            }
                            else
                                return;
                        }
                        else
                        {
                            _currentIdx++;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                _timer.Start();
            }

        }
    }
}
