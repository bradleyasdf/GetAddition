using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Drawing2D;
using System.Reflection;
using OpenQA.Selenium.Interactions;
using Microsoft.Win32;
using ProxyLib;

namespace GetAddition
{
    public partial class Form1 : Form
    {
        private List<string> _additionFolders = new List<string>();
        private int _additionIdx = 0;
        private string _additionSs;
        private int _downloadCount = 0;
        private int _attemptCount = 0;
        private int _failedCount = 0;
        private int _folderCount = 0;

        private IWebDriver _driver;
        private readonly string CURRENTDIR = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private readonly string[] SEPARATORS = new string[] { " ", "——", "：", "·", "（" };
        private readonly string[] AUTHORSUFFIX = new string[] { "，", "主编", "改编", "编著", "；", "选编", "编文", "编辑", "合编", "改编", " ", "编写" };
        private int _proxyIdx = -1;
        private List<string> _proxies;
        private List<string> _allProxies;
        private string _currentProxyUrl = "";
        private MyWebClient _downloader;
        private int _reconnectAttempt = 0;
        private readonly int MAXIUMRECONNECT = 100;//100 seconds
        private int _searchAttemptCount = 0;
        private string[] _searchAttempt = new string[] { "title", "author", "folder", "titleboth", "folderboth"};
        private bool _isCancel = false;
        private bool _isTriggered = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        private void initProxyServers(string setting)
        {
            int idx = setting.IndexOf("=") + 1;
            var ps2 = setting.Substring(idx).Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            _proxies = ps2;
        }

        private void initProxyList(string path)
        {
            if (File.Exists(path))
            {
                var lines2 = File.ReadAllLines(path);
                foreach (var line in lines2)
                {
                    if (_proxies.Contains(line) == false)
                    {
                        _proxies.Add(line);
                    }
                }
            }
        }

        private void init()
        {
            if (File.Exists("settings.txt"))
            {
                var lines = File.ReadAllLines("settings.txt");
                int idx = lines[0].IndexOf("+") + 1;
                string proxyMode = lines[0].Substring(idx).Trim();
                if (proxyMode == "no")
                {
                    rbNoProxy.Checked = true;
                }
                else if (proxyMode == "tool")
                {
                    var obj = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Psiphon3", "UICookies", "");
                    if (obj == null)
                    {
                        MessageBox.Show("Please install and run Psiphon3 first");
                        rbNoProxy.Checked = true;
                        return;
                    }
                    string str = (string)obj;
                    int idx1 = str.IndexOf("[") + 1;
                    int idx2 = str.IndexOf("]");
                    //string[] toexclude = new string[] { "AT", "BE", "BG", "GB", "SK", "PL", "CH", "DK" };
                    str = str.Substring(idx1, idx2 - idx1).Replace("\"", "");
                    //foreach (string exclude in toexclude)
                    //{
                    //    str = str.Replace(exclude, "");
                    //}
                    var ps = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    _allProxies = ps;
                    rbProxy.Checked = true;
                    initProxyServers(lines[1]);
                }
                else if (proxyMode == "list")
                {
                    rbProxyList.Checked = true;
                    initProxyList("proxylist.txt");
                }
            }
            this.rbNoProxy.CheckedChanged += onProxyModeChanged;
            this.rbProxy.CheckedChanged += onProxyModeChanged;
            this.rbProxyList.CheckedChanged += onProxyModeChanged;
            nChangeInterval.Enabled = !this.rbNoProxy.Checked;
            _currentProxyUrl = "http://abc.com/";//no proxy
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            _additionFolders.Clear();
            _additionIdx = 0;
            _searchAttemptCount = 0;
            //_isCancel = false;
            gbProxyMode.Enabled = false;
            foreach (var item in lFolders.Items)
            {
                _additionFolders.Add(item.ToString());
            }
            _folderCount += _additionFolders.Count;
            
            if (_downloader == null)
            {
                if (nChangeInterval.Enabled)
                {
                    if (rbProxy.Checked)
                    {
                        switchProxy();
                    }
                    else
                    {
                        switchProxyInList();
                        restart();
                    }
                }
                else
                {
                    restart();
                }
            }
            else
            {
                timerAddition_Tick(null, null);
            }
        }

        private void timerAddition_Tick(object sender, EventArgs e)
        {
            timerAddition.Stop();
            //1.check if login
            //2.get next account (if first then skip)
            //3.set proxy if necessary
            //4.login if necessary
            _additionSs = "";
            if (_additionIdx < _additionFolders.Count)
            {
                while (_additionIdx < _additionFolders.Count
                    && ((File.Exists(Path.Combine(_additionFolders[_additionIdx], "cov001.pdg"))
                    && File.Exists(Path.Combine(_additionFolders[_additionIdx], "cov002.pdg"))
                    && File.Exists(Path.Combine(_additionFolders[_additionIdx], "leg001.pdg")))
                    || File.Exists(Path.Combine(_additionFolders[_additionIdx], "BookInfo.dat")) == false))
                {
                    _additionIdx++;
                    if (_isCancel)
                    {
                        gbProxyMode.Enabled = true;
                        return;
                    }
                }
                if (_additionIdx >= _additionFolders.Count)
                {
                    MessageBox.Show("finish");
                    gbProxyMode.Enabled = true;
                    return;
                }
                search("title");
            }
            else
            {
                MessageBox.Show("finish");
                gbProxyMode.Enabled = true;
                return;
            }
        }

        private void search(string searchType)
        {
            string bookName = "";
            string author = "";
            string year = "";
            using (StreamReader reader = new StreamReader(File.Open(Path.Combine(_additionFolders[_additionIdx], "BookInfo.dat"), FileMode.Open, FileAccess.Read), Encoding.GetEncoding("gb2312")))
            {
                while (reader.Peek() > -1)
                {
                    if (_isCancel)
                        return;
                    var line = reader.ReadLine();
                    var idx1 = line.IndexOf("书名=");
                    if (idx1 > -1)
                    {
                        if (searchType == "folder" || searchType == "folderboth")
                        {
                            bookName = Path.GetFileName(_additionFolders[_additionIdx]);
                        }
                        else
                        {
                            bookName = line.Substring(idx1 + 3);
                        }
                        var nameParts = bookName.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                        if (searchType != "second")
                        {
                            bookName = nameParts[0];
                        }
                        else
                        {
                            if (nameParts.Length > 1)
                            {
                                bookName = nameParts[1];
                            }
                            else
                            {
                                bookName = nameParts[0];
                            }
                        }
                    }
                    else
                    {
                        var idx2 = line.IndexOf("SS号=");
                        if (idx2 > -1)
                        {
                            _additionSs = line.Substring(idx2 + 4);
                        }
                        else
                        {
                            var idx3 = line.IndexOf("作者=");
                            if (idx3 > -1)
                            {
                                var authort = line.Substring(idx3 + 3);
                                var idx4 = authort.IndexOf("）");
                                if (idx4 > -1)
                                {
                                    authort = authort.Substring(idx4 + 1);
                                }
                                var authors = authort.Split(AUTHORSUFFIX, StringSplitOptions.RemoveEmptyEntries);
                                authort = authors[0];
                                author = authort.TrimEnd(new char[] { '等', '编', '著' });
                            }
                            else
                            {
                                idx3 = line.IndexOf("出版日期=");
                                if (idx3 > -1)
                                {
                                    var yeart = line.Substring(idx3 + 5);
                                    var idx5 = yeart.IndexOf(",");
                                    if (idx5 > -1)
                                    {
                                        var idx6 = yeart.IndexOf(".");
                                        if (idx6 > -1)
                                        {
                                            year = yeart.Substring(idx5, idx6 - idx5 - 1).Trim();
                                        }
                                    }
                                    else
                                    {
                                        idx5 = yeart.IndexOf("年");
                                        if (idx5 > -1)
                                        {
                                            year = yeart.Substring(0, idx5).Trim();
                                        }
                                        else
                                        {
                                            idx5 = yeart.IndexOf(".");
                                            if (idx5 > -1)
                                            {
                                                year = yeart.Substring(0, idx5);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //if (!String.IsNullOrEmpty(bookName)
                    //    && !String.IsNullOrEmpty(_additionSs)
                    //    && (ckAdvancedSearch.Checked == false
                    //    || (!String.IsNullOrWhiteSpace(author)
                    //        && !String.IsNullOrWhiteSpace(year))
                    //       )
                    //    )
                    //{
                    //    break;
                    //}
                    if (!String.IsNullOrEmpty(bookName)
                        && !String.IsNullOrEmpty(_additionSs)
                        &&  !String.IsNullOrWhiteSpace(author)
                        && !String.IsNullOrWhiteSpace(year))
                    {
                        break;
                    }
                }
            }

            if (!String.IsNullOrEmpty(_additionSs))
            {
                //var url = "http://book.ucdrs.superlib.net/search?Field=1&channel=search&sw="
                //    //+ 
                //    + HttpUtility.UrlEncode(bookName) + "&ecode=utf-8";

                //if (ckAdvancedSearch.Checked)
                //{
                    //url = "http://book.duxiu.com/search?expertsw="
                    //    + HttpUtility.UrlEncode("A=" + author + "*Y=" + year)
                    //    + "&exp=1&ecode=utf-8";
                if (_isCancel)
                    return;
                string url = "";
                if ((searchType == "title" || searchType == "folder") && !String.IsNullOrEmpty(bookName))
                {
                    url = "http://book.ucdrs.superlib.net/search?expertsw="
                        + HttpUtility.UrlEncode("T=" + bookName + "*Y=" + year)
                        + "&exp=1&ecode=utf-8";
                }
                else if (searchType == "author" && !String.IsNullOrWhiteSpace(author))
                {
                    //if (ckIncludeAuthor.Checked)
                    //{

                    //}
                    url = "http://book.ucdrs.superlib.net/search?expertsw="
                        + HttpUtility.UrlEncode("A=" + author + "*Y=" + year)
                        + "&exp=1&ecode=utf-8";
                }
                else if ((searchType == "folderboth" || searchType == "titleboth")
                         && !String.IsNullOrEmpty(bookName)
                         && !String.IsNullOrWhiteSpace(author))
                {
                    url = "http://book.ucdrs.superlib.net/search?expertsw="
                        + HttpUtility.UrlEncode("T=" + bookName + "*A=" + author + "*Y=" + year)
                        + "&exp=1&ecode=utf-8";
                }
                else
                {
                    _additionIdx++;
                    timerAddition_Tick(null, null);
                    return;
                }
                _driver.Navigate().GoToUrl(url);
                if (_isCancel)
                    return;
                timerAddition2.Stop();
                timerAddition2.Start();
            }
            else
            {
                _additionIdx++;
                timerAddition_Tick(null, null);
            }
        }

        private void timerAddition2_Tick(object sender, EventArgs e)
        {
            timerAddition2.Stop();
            if (_isCancel)
                return;
            try
            {
                var tables = _driver.FindElements(By.TagName("TABLE"));//webBrowserWithProxy1.Document.GetElementsByTagName("TABLE");//webBrowser1.Document.GetElementsByTagName("TABLE");
                int count = 0;
                bool isFound = false;
                foreach (var table in tables)
                {
                    if (_isCancel)
                        return;
                    var className = table.GetAttribute("className");
                    if (!String.IsNullOrEmpty(className)
                        && className.StartsWith("book1"))
                    {

                        var sst = _driver.FindElement(By.Id("ssid" + count.ToString()));//webBrowserWithProxy1.Document.GetElementById("ssid" + count.ToString());//webBrowser1.Document.GetElementById("ssid" + count.ToString());
                        var ss = sst.GetAttribute("value");
                        if (ss == _additionSs)
                        {//found
                            isFound = true;
                            _searchAttemptCount = 0;
                            var dxid = _driver.FindElement(By.Id("dxid" + count.ToString())).GetAttribute("value");//webBrowserWithProxy1.Document.GetElementById("dxid" + count.ToString()).GetAttribute("value");//webBrowser1.Document.GetElementById("dxid" + count.ToString()).GetAttribute("value");
                            var links = table.FindElements(By.TagName("a"));//table.GetElementsByTagName("a");//webBrowser1.Document.GetElementsByTagName("a");
                            string detailLink = "";
                            foreach (var link in links)
                            {
                                if (_isCancel)
                                    return;
                                var href = link.GetAttribute("href");
                                if (!String.IsNullOrWhiteSpace(href)
                                    && href.IndexOf("bookDetail.jsp") > -1)
                                {
                                    detailLink = href;
                                    break;
                                }
                            }

                            _driver.Navigate().GoToUrl(detailLink);
                            if (_isCancel)
                                return;
                            if (_driver.PageSource.Contains("statjz()"))
                            {
                                var links2 = _driver.FindElements(By.TagName("a"));
                                foreach (var link in links2)
                                {
                                    if (_isCancel)
                                        return;
                                    var href = link.GetAttribute("href");
                                    if (!String.IsNullOrEmpty(href)
                                        && href.IndexOf("readDetail.jsp") > -1)
                                    {
                                        _driver.Navigate().GoToUrl(href);
                                        timerAddition3.Stop();
                                        timerAddition3.Start();
                                        return;
                                    }
                                }
                            }
                            //no preview
                            lFailed.Items.Add(_additionFolders[_additionIdx]);
                            _additionIdx++;
                            timerAddition_Tick(null, null);
                            return;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (!isFound)
                {
                    if (_isCancel)
                        return;
                    if (_searchAttemptCount < _searchAttempt.Length)
                    {
                        _searchAttemptCount++;
                        search(_searchAttempt[_searchAttemptCount]);
                    }
                    else
                    {
                        lFailed.Items.Add(_additionFolders[_additionIdx]);
                        _additionIdx++;
                        timerAddition_Tick(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                retry();
            }
        }

        private void retry()
        {
            if (rbProxyList.Checked)
            {
                switchProxyInList();
                restart();
            }
            else if (rbProxy.Checked)
            {
                switchProxy();
            }
            else
            {
                restart();
            }
        }

        private void timerAddition3_Tick(object sender, EventArgs e)
        {
            timerAddition3.Stop();
            var idx = _driver.PageSource.IndexOf("jpgPath");
            if (idx > -1)
            {
                var html = _driver.PageSource;
                var idx1 = html.IndexOf("\"", idx);
                var idx2 = html.IndexOf("\"", idx1 + 1);
                var path = "http://img.duxiu.com" + html.Substring(idx1 + 1, idx2 - idx1 - 1);
                if (_isCancel || backgroundWorker1.IsBusy)
                {
                    if (backgroundWorker1.IsBusy)
                    {
                        if (_isCancel == false)
                        {
                            _isCancel = true;
                            backgroundWorker1.CancelAsync();
                        }
                        while (backgroundWorker1.IsBusy)
                        {
                            Application.DoEvents();
                        }
                        backgroundWorker1.RunWorkerAsync(path);
                    }
                }
                else
                {
                    backgroundWorker1.RunWorkerAsync(path);
                }
                //string[] pageTypes = new string[] { "cov001", "bok001", "leg001", "cov002" };
                //bool hasError = false;
                //int retryCount = 0;
                //foreach (string pageType in pageTypes)
                //{
                //    int result = downloadAddition(path, pageType);
                //    while (result == -2 && retryCount < 10)
                //    {
                //        MessageBox.Show("image");
                //        if (nChangeInterval.Enabled)
                //        {
                //            retryCount = 0;
                //            switchProxy();
                //            return;
                //        }
                //        else
                //        {
                //            retryCount++;
                //            result = downloadAddition(path, pageType);
                //            continue;
                //        }
                //    }
                //    if (result == -2)
                //    {
                //        MessageBox.Show("fail, try again later");
                //        return;
                //    }

                //    if (result == -3)
                //    {
                //        //add to failed
                //        if (lFailed.Items.Contains(_additionFolders[_additionIdx]) == false)
                //        {
                //            lFailed.Items.Add(_additionFolders[_additionIdx]);
                //        }
                //        hasError = true;
                //        continue;
                //    }
                //    else if (result == -4)
                //    {
                //        if (lPossibleFail.Items.Contains(_additionFolders[_additionIdx]) == false)
                //        {
                //            lPossibleFail.Items.Add(_additionFolders[_additionIdx]);
                //        }
                //    }
                //}
                //_attemptCount++;
                //if (!hasError)
                //{
                //    _downloadCount++;
                //}
                //lCount.Text = _downloadCount.ToString() + " of " + _folderCount.ToString();
                //_additionIdx++;
                //int changeInterval = (int)nChangeInterval.Value;
                //if (nChangeInterval.Enabled && changeInterval > 0 && _attemptCount % changeInterval == 0)
                //{
                //    //MessageBox.Show("pause");
                //    if (rbProxy.Checked)
                //    {
                //        switchProxy();
                //    }
                //    else if (rbProxyList.Checked)
                //    {
                //        switchProxyInList();
                //        restart();
                //    }
                //    return;
                //}
                //int interval = (int)nInterval.Value;
                //if (_additionIdx >= _additionFolders.Count || interval == 0)
                //{
                //    timerAddition_Tick(null, null);
                //}
                //else
                //{
                //    timerAddition.Interval = interval * 1000;//milliseconds
                //    timerAddition.Stop();
                //    timerAddition.Start();
                //}
            }
        }

        private int downloadAddition(string pathPrefix, string path, string pageType)
        {
            int result = 0;
            var fileName = Path.Combine(path, pageType + ".pdg");
            if (File.Exists(fileName))
            {
                return 0;
            }
            var fullPath = pathPrefix + pageType + "?zoom=2";
            var firstLine = "";
            if (_downloader == null)
            {
                _downloader = new MyWebClient();
                _downloader.Timeout = 200 * 1000;
            }
            try
            {
                if (nChangeInterval.Enabled)
                {
                    _downloader.Proxy = WebRequest.GetSystemWebProxy();
                    var tstr = _downloader.Proxy.GetProxy(new Uri("http://abc.com")).ToString();
                }
                _downloader.DownloadFile(fullPath, fileName);
            }
            catch (Exception ex)
            {
                result = -3;
                _downloader = null;
            }

            if (File.Exists(fileName))
            {
                var fileInfo = new FileInfo(fileName);
                if (result == -3)
                {
                    File.Delete(fileName);
                }
                else if (fileInfo.Length == 17663)
                {//unavailable
                    result = -1;
                    File.Delete(fileName);
                }
                else if (fileInfo.Length == 37426 || fileInfo.Length == 37215)
                {
                    using (StreamReader reader = File.OpenText(fileName))
                    {
                        firstLine = reader.ReadLine();
                    }
                    if (firstLine.StartsWith("<!DOCTYPE"))
                    {//verify image
                        result = -2;
                        File.Delete(fileName);
                    }
                }
                else if (fileInfo.Length > 0 && fileInfo.Length < 1000000 && pageType != "leg001")
                {
                    result = -4;//possibly failed
                }
                else if (fileInfo.Length > 1000000)
                {
                    result = 1;
                }
            }
            return result;
        }

        private int downloadAddition(string pathPrefix, string pageType)
        {
            return downloadAddition(pathPrefix, _additionFolders[_additionIdx], pageType);
        }

        private void switchProxyInList()
        {
            if (_proxyIdx == _proxies.Count - 1)
            {
                _proxyIdx = 0;
            }
            else
            {
                _proxyIdx++;
            }
            ProxyLib.WinINet.SetConnectionProxy(true, _proxies[_proxyIdx], false);
        }

        private void switchProxy()
        {
            if (_proxyIdx == _proxies.Count - 1)
            {
                _proxyIdx = 0;
            }
            else
            {
                _proxyIdx++;
            }
            Utilities.KillProcessAndChildren("psiphon3.exe");
            //set new proxy
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Psiphon3", "EgressRegion", _proxies[_proxyIdx]);
            Thread.Sleep(1000);
            Process.Start("psiphon3.exe");
            Thread.Sleep(2000);
            //wait for proxy to be ready
            _reconnectAttempt = 0;
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            var proxy = WebRequest.GetSystemWebProxy();
            var proxyStr = proxy.GetProxy(new Uri("http://abc.com")).ToString();
            if (_currentProxyUrl != proxyStr)
            {
                _currentProxyUrl = proxyStr;
                if (_isCancel)
                    return;
                restart();
            }
            else
            {
                if (_isCancel)
                {
                    return;
                }
                if (_reconnectAttempt < MAXIUMRECONNECT)
                {
                    _reconnectAttempt++;
                    timer1.Start();
                }
                else
                {
                    _reconnectAttempt = 0;
                    switchProxy();
                }
            }
        }

        private void restart()
        {
            if (_driver != null)
            {
                try
                {
                    _driver.Close();
                }
                catch { }
                _driver.Quit();
            }
            if (_isCancel)
                return;
            if (Directory.Exists(CURRENTDIR + "\\1"))
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Arguments = "/c rd /s /q \"" + CURRENTDIR + "\\1\"";
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.CreateNoWindow = true;
                info.FileName = "cmd.exe";
                Process cmd = Process.Start(info);
                cmd.WaitForExit();
            }
            if (_isCancel)
                return;
            Directory.CreateDirectory(CURRENTDIR + "\\1");
            if (_isCancel)
                return;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument(@"user-data-dir=" + Path.Combine(CURRENTDIR, "1"));
            _driver = new ChromeDriver(".\\", options, TimeSpan.FromSeconds(180));
            if (_isCancel)
                return;
            Thread.Sleep(2000);
            if (_isCancel)
                return;
            timerAddition_Tick(null, null);
        }

        private void btnFolders_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lFolders.Items.Clear();
                var root = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                foreach (var folder in root.GetDirectories())
                {
                    lFolders.Items.Add(folder.FullName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_downloader != null)
            {
                _downloader.Dispose();
            }
            if (_driver != null)
            {
                _driver.Quit();
            }
            Process[] ps = Process.GetProcessesByName("chromedriver");
            if (ps != null && ps.Length > 0)
            {
                Utilities.KillProcessAndChildren("chromedriver.exe");
            }
            Utilities.KillProcessAndChildren("psiphon3.exe");
            ProxyLib.WinINet.DisableSystemProxy();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            FormOptions options = new FormOptions();
            options.AllProxies = _allProxies;
            options.Selected = _proxies;
            var t = options.ShowDialog();
            if (t == System.Windows.Forms.DialogResult.OK)
            {
                _proxies = options.Selected;
            }
        }

        private void saveProxyModeSetting(string proxyMode)
        {
            var setting = File.ReadAllLines("settings.txt");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < setting.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append("ProxyMode=" + proxyMode);
                }
                else
                {
                    sb.Append(setting[i]);
                }
            }
            File.WriteAllText("settings.txt", sb.ToString());
        }

        private void onProxyModeChanged(object sender, EventArgs e)
        {
            if (_isTriggered)
            {
                _isTriggered = false;
                return;
            }
            else
            {
                _isTriggered = true;
            }
            if (rbNoProxy.Checked)
            {
                nChangeInterval.Enabled = false;
                saveProxyModeSetting("no");
            }
            else
            {
                nChangeInterval.Enabled = true;
                var lines = File.ReadAllLines("settings.txt");
                _proxyIdx = 0;
                if (rbProxy.Checked)
                {
                    saveProxyModeSetting("tool");
                    initProxyServers(lines[1]);
                }
                else
                {
                    saveProxyModeSetting("list");
                    initProxyList("proxylist.txt");
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = (string)e.Argument;
            string[] pageTypes = new string[] { "cov001", "bok001", "leg001", "cov002" };
            bool hasError = false;
            int retryCount = 0;
            foreach (string pageType in pageTypes)
            {
                if (backgroundWorker1.CancellationPending || _isCancel)
                {
                    e.Cancel = true;
                    e.Result = hasError;
                    return;
                }
                int result = downloadAddition(path, pageType);
                while (result == -2 && retryCount < 10)
                {
                    MessageBox.Show("image");
                    if (nChangeInterval.Enabled)
                    {
                        retryCount = 0;
                        backgroundWorker1.ReportProgress(0);
                        e.Result = hasError;
                        //switchProxy();
                        return;
                    }
                    else
                    {
                        retryCount++;
                        result = downloadAddition(path, pageType);
                        continue;
                    }
                }
                if (result == -2)
                {
                    backgroundWorker1.ReportProgress(1);
                    e.Result = hasError;
                    return;
                }

                if (result == -3)
                {
                    //add to failed
                    if (lFailed.Items.Contains(_additionFolders[_additionIdx]) == false)
                    {
                        lFailed.Invoke(new Action(() => lFailed.Items.Add(_additionFolders[_additionIdx])));
                    }
                    hasError = true;
                    continue;
                }
                else if (result == -4)
                {
                    if (lPossibleFail.Items.Contains(_additionFolders[_additionIdx]) == false)
                    {
                        lPossibleFail.Invoke(new Action(() => lPossibleFail.Items.Add(_additionFolders[_additionIdx])));
                    }
                }
            }
            e.Result = hasError;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var hasError = (bool)e.Result;
            if (!hasError)
            {
                _downloadCount++;
            }
            lCount.Text = _downloadCount.ToString() + " of " + _folderCount.ToString();
            _additionIdx++;
            int changeInterval = (int)nChangeInterval.Value;
            if (_isCancel)
            {
                gbProxyMode.Enabled = true;
                return;
            }
            if (nChangeInterval.Enabled && changeInterval > 0 && _attemptCount % changeInterval == 0)
            {
                //MessageBox.Show("pause");
                if (rbProxy.Checked)
                {
                    switchProxy();
                }
                else if (rbProxyList.Checked)
                {
                    switchProxyInList();
                    restart();
                }
                return;
            }
            int interval = (int)nInterval.Value;
            if (_additionIdx >= _additionFolders.Count || interval == 0)
            {
                timerAddition_Tick(null, null);
            }
            else
            {
                timerAddition.Interval = interval * 1000;//milliseconds
                timerAddition.Stop();
                timerAddition.Start();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                if (rbProxy.Checked)
                {
                    switchProxy();
                }
                else
                {
                    switchProxyInList();
                    restart();
                }
            }
            else if (e.ProgressPercentage == 1) //fail
            {
                MessageBox.Show("fail, try again later");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isCancel = true;
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

    }

    public class MyWebClient : WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest lWebRequest = base.GetWebRequest(uri);
            lWebRequest.Timeout = Timeout;
            ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
            return lWebRequest;
        }
    }
}
