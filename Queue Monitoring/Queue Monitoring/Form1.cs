using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices; // DllImport
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Data.OleDb;

namespace Queue_Monitoring
{
    public partial class cMainForm : Form
    {
        //string url = @"http://10.177.128.14:8081/cuic/report/grid/GridView.htmx?reportId=DF6C31D710000131368E4F420AB1800E&datasetId=27F1F2791000014173528EF50AB3800E&viewId=DF6C31D7100001316FA0F52E0AB1800E&repDefVersion=76&reqSrc=&command=refresh&linkType=htmlType";
        string url = @"http://gaqcuic1.nacc.adinternal.com:8081/cuic/permalink/report/grid/GridView.htmx?reportId=27F1F2791000014149CF83370AB3800E&datasetId=9A9EB9BF10000149006320BD0AB3811C&viewId=27F1F2791000014173528EF50AB3800E&repDefVersion=170&reqSrc=&command=refresh&linkType=htmlType";
        string url2 = @"http://gaqcuic1.nacc.adinternal.com:8081/cuic/permalink/report/grid/GridView.htmx?reportId=27F5C835100001416F1534D80AB3800E&datasetId=9AA15EE810000149006324300AB3811C&viewId=27F5C835100001417640FD1E0AB3800E&repDefVersion=609&reqSrc=&command=refresh&linkType=htmlType";
        WebClient client = new WebClient();
        WebClient client2 = new WebClient();
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags); static readonly IntPtr HWND_TOPMOST = new IntPtr(-1); const UInt32 SWP_NOSIZE = 0x0001; const UInt32 SWP_NOMOVE = 0x0002; const UInt32 SWP_SHOWWINDOW = 0x0040; static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        System.Timers.Timer Timer_MainLoop = new System.Timers.Timer();
        [DllImport("user32.dll")]
        static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public Int32 dwFlags;
            public UInt32 uCount;
            public Int32 dwTimeout;
        }
        // stop flashing
        //int FLASHW_STOP = 0;

        // flash the window title 
        //int FLASHW_CAPTION = 1;

        // flash the taskbar button
        int FLASHW_TRAY = 2;

        // 1 | 2
        //int FLASHW_ALL = 3;

        // flash continuously 
        //int FLASHW_TIMER = 4;

        // flash until the window comes to the foreground 
        int FLASHW_TIMERNOFG = 12;
        //string xlsfilename = "";
        //string xlsfilepath = @"\\caicssarea51\Support\Team_Schedules-DoNotDelete\Sage_100_ERP\Current Schedule\";

        delegate void MyDelegate(bool show);
        //int status = 0;
        string AppPath = string.Empty;
        List<string> Rules = new List<string>();
        byte[] raw;
        Uri tmpuri;
        Uri tmpuri2;
        DataTable ds = new DataTable();
        string AnalystPrimaryQueue = string.Empty;
        bool pause = false;
        bool disablewarnings = false;

        public cMainForm()
        {
            try
            {
                
                InitializeComponent();
                cQueueCycle.Stop();

                //cCheckSchedule.Stop();
                QueueRules InstantiateRules = new QueueRules();
                Rules.AddRange(InstantiateRules.RuleSets);
                //queryschedule();
                //PopulateAnalystList();
                tmpuri = new Uri(url);
                tmpuri2 = new Uri(url2);

                AppPath = Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf('\\'));
                checkstate();
                LoadPreferences();
                fControlStatesandLocations();
                fQueueStatusUpdate();
                fReadyStatusUpdate();
                cQueueCycle.Start();
                /*populatescheduleelements();
                if (toolStripAnalystList.SelectedItem.ToString().Trim() != "")
                {
                    SetPrimaryQueueForAnalyst();
                    fQueueStatusUpdate();
                    cQueueCycle.Start();
                    //cCheckSchedule.Start();
                    pause = false;
                }*/
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

        }

        private void queryschedule()
        {
            /*try
            {
                findschedule();
                ExcelOLEDB oledb = new ExcelOLEDB();
                ds = oledb.ReturnSchedule(xlsfilename);

            }
            catch (Exception ex)
            {
                //stopalltimers();
               // MessageBox.Show(ex.Message);
                //Application.Exit();
                //MessageBox.Show(ex.ToString());
                cOops();
            }*/


        }
        private void stopalltimers()
        {
            cQueueCycle.Stop();
            //cCheckSchedule.Stop();
            MasterTimer.Stop();
            SnoozeTimer.Stop();
        }

        private void populatescheduleelements()
        {
            try
            {
                
                foreach (DataRow row in ds.Rows)
                {
                    if (toolStripAnalystList.SelectedItem.ToString().Trim() != "")
                    {
                        if (row["F1"].ToString().Contains(toolStripAnalystList.SelectedItem.ToString()))
                        {
                            string cur = CurrentTimeColumn();
                            string nxt = NextTimeColumn();
                            if (cur != "F-1")
                            {
                                //cNowTextBox.Text = row[cur].ToString();
                            }
                            else if (Convert.ToInt32(cur.Replace("F", string.Empty)) >= 0)
                            {
                                //cNowTextBox.Text = "Error Code:" + cur;
                                //cNextTextBox.Text = string.Empty;
                                break;
                            }
                            if (nxt != "F-1")
                            {
                                //cNextTextBox.Text = row[nxt].ToString();
                                break;
                            }
                            else
                            {
                                //cNextTextBox.Text = string.Empty;
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                cOops();
            }
        }
        private void cOops()
        {
        //    cNowTextBox.Text = "Schedule Updating?...";
          //  cNextTextBox.Text = "Retrying in 5m...";
        }
        private string CurrentTimeColumn()
        {
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            hours = (hours - 5) * 4;
            minutes = minutes / 15;
            int currentrowposition = hours + minutes + 6;
            if (currentrowposition > 65) { currentrowposition = -1; }
            return "F" + currentrowposition.ToString();
        }
        private string NextTimeColumn()
        {
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            hours = (hours - 5) * 4;
            minutes = minutes / 15;
            int currentrowposition = hours + minutes + 7;
            if ((currentrowposition +1) > 65) { currentrowposition = -1; }
            return "F" + currentrowposition.ToString();
        }
        private void findschedule()
        {/*
            try
            {
                foreach (string vfile in Directory.GetFiles(xlsfilepath))
                {
                    DateTime Latesttime = DateTime.Today;

                    if (vfile.Contains('~') == false && vfile.Contains(".xlsx"))
                    {
                        if (xlsfilename == string.Empty)
                        {
                            Latesttime = File.GetLastWriteTime(vfile);
                            xlsfilename = vfile;
                        }
                        if (File.GetLastWriteTime(vfile) > Latesttime)
                        {
                            Latesttime = File.GetLastWriteTime(vfile);
                            xlsfilename = vfile;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }*/
        }
        private void cMainForm_Load(object sender, EventArgs e)
        {


        }

        private void PopulateAnalystList()
        {
            /*
            try
            {
                foreach (DataRow row in ds.Rows)
                {
                    if (row["F1"].ToString().Trim() == string.Empty)
                    {
                        break; //assume the list is done if we hit a blank row
                    }
                    toolStripAnalystList.Items.Add(row["F1"].ToString());
                }
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            //toolStripAnalystList.Items.AddRange
             */
        }
        private void LoadPreferences()
        {
            try
            {
                int x = Properties.Settings.Default.DesktopX;
                int y = Properties.Settings.Default.DesktopY;
                this.DesktopLocation = new Point(x, y);
                showPhoneStatusToolStripMenuItem.Checked = Properties.Settings.Default.ShowPhoneStatus;
                alwaysOnTopToolStripMenuItem.Checked = Properties.Settings.Default.AlwaysOnTop;
                //showScheduleToolStripMenuItem.Checked = Properties.Settings.Default.ShowSchedule;
                if (Properties.Settings.Default.AnalystName.Trim() != "")
                {
                    toolStripAnalystList.SelectedItem = Properties.Settings.Default.AnalystName;
                }
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void SavePreferences()
        {
            try
            {
                Properties.Settings.Default.DesktopX = this.Location.X;
                Properties.Settings.Default.DesktopY = this.Location.Y;
                Properties.Settings.Default.ShowPhoneStatus = showPhoneStatusToolStripMenuItem.Checked;
                Properties.Settings.Default.AlwaysOnTop = alwaysOnTopToolStripMenuItem.Checked;
                //Properties.Settings.Default.ShowSchedule = showScheduleToolStripMenuItem.Checked;
                if (toolStripAnalystList.SelectedIndex != -1 )
                {
                    Properties.Settings.Default.AnalystName = toolStripAnalystList.SelectedItem.ToString();
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void cQueueCycle_Tick(object sender, EventArgs e)
        {
            fQueueStatusUpdate();
            fReadyStatusUpdate();
            checkstate();

        }
       
        private void SetPrimaryQueueForAnalyst()
        {
            /*
            try
            {
                string tmprow = string.Empty;
                foreach (DataRow row in ds.Rows)
                {
                    tmprow = row["F1"].ToString();
                    if (tmprow == toolStripAnalystList.SelectedItem.ToString())
                    {
                        string tmp = row["F3"].ToString().Trim().ToUpper();
                        if (tmp == "APPS" && row["F5"].ToString() == "F1")
                        {
                            tmp = "F1";

                        }
                        switch (tmp)
                        {
                            case "APPS":
                                AnalystPrimaryQueue = "BS_SPT_100E_Apps_Q_CT";
                                break;
                            case "TOOLS":
                                AnalystPrimaryQueue = "BS_SPT_100E_Tech_Q_CT";
                                break;
                            case "F1":
                                AnalystPrimaryQueue = "BS_SPT_100E_Finance_Q_CT";
                                break;
                        }
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                cOops();
            }
             * */
        }

        private void fQueueStatusUpdate()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    raw = client.DownloadData(tmpuri);
                    client.Dispose();
                }

                string rawfeed = System.Text.Encoding.UTF8.GetString(raw);
                cToolsTextBox.Text = fDecode(rawfeed, "BS_SPT_X3_Q_CT");
                //cAppsTextBox.Text = fDecode(rawfeed, "BS_SPT_100E_Apps_Q_CT");
                //cFinTextBox.Text = fDecode(rawfeed, "BS_SPT_100E_Finance_Q_CT");
                //cCloudtextBox.Text = fDecode(rawfeed, "BS_SPT_Cloud_SIA_Q_CT");

                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Text = "Queue X3:" + cToolsTextBox.Text.Substring(0, 1);//+ " F:" + cFinTextBox.Text.Substring(0, 1) + " A:" + cAppsTextBox.Text.Substring(0, 1);
                   // cReadyTextBox=
                }
                else
                {
                    this.Text = "Queue Monitoring for Sage ERP X3";
                }
                if (this.TopMost == true)
                {
                    this.ShowInTaskbar = false;
                    this.Text = "Queue Monitoring Sage ERP X3";
                    this.TopMost = true;
                    this.BringToFront();
                }
                else
                {

                    this.ShowInTaskbar = true;
                    this.Text = "Queue X3: " + cToolsTextBox.Text.Substring(0, 1)+ " calls waiting";// +" F:" + cFinTextBox.Text.Substring(0, 1) + " A:" + cAppsTextBox.Text.Substring(0, 1);
                    this.TopMost = false;
                }
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        private void fReadyStatusUpdate()
        {
            try
            {
                using (WebClient client2 = new WebClient())
                {
                    raw = client2.DownloadData(tmpuri2);
                    client2.Dispose();
                }

                string rawfeed = System.Text.Encoding.UTF8.GetString(raw);
                //cToolsTextBox.Text = fDecode2(rawfeed, "Ready");
                //string searchString = "TEST";
                //string completeText = "Some sentence TEST with other words incluing TEST";
                int count = rawfeed.Split(new string[] { ">Ready" }, StringSplitOptions.None)
                                        .Count() - 1;
                //Console.WriteLine(rawfeed);
                int yanik = rawfeed.Split(new string[] { "Yannick" }, StringSplitOptions.None)
                                                        .Count() - 1;
                int yanikpos= rawfeed.IndexOf("Yannick");

                if (yanik > 0)
                {
                    string rawynik = rawfeed.Substring(yanikpos, 300);
                    int yanikready = rawynik.Split(new string[] { ">Ready" }, StringSplitOptions.None)
                                        .Count() - 1;
                    if (yanikready>0 )
                    { count=count-1;
                    }
                }   

                string ReadyText = count.ToString();
                if (count == 0)
                {
                    ReadyText = ReadyText + " (Everyone Go Ready ASAP.)";
                }
                else if (count >=3)
                {
                    ReadyText = ReadyText + "  (Thank you for your efforts.)";
                }
                
                //MessageBox.Show(count.ToString() + " Matches Found");



                //cAppsTextBox.Text = fDecode(rawfeed, "BS_SPT_100E_Apps_Q_CT");
                //cFinTextBox.Text = fDecode(rawfeed, "BS_SPT_100E_Finance_Q_CT");
                //cCloudtextBox.Text = fDecode(rawfeed, "BS_SPT_Cloud_SIA_Q_CT");

                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Text = "Number of Ready" + count.ToString();//+ " F:" + cFinTextBox.Text.Substring(0, 1) + " A:" + cAppsTextBox.Text.Substring(0, 1);
                    cReadyTextBox.Text = ReadyText;
                }
                else
                {
                    //this.Text = "Queue Monitoring for Sage ERP X3";
                }
                if (this.TopMost == true)
                {
                    this.ShowInTaskbar = false;
                   // this.Text = "Queue Monitoring Sage ERP X3";
                    this.TopMost = true;
                    this.BringToFront();
                }
                else
                {

                    this.ShowInTaskbar = true;
                    //this.Text = "Queue X3:" + count.ToString();// +" F:" + cFinTextBox.Text.Substring(0, 1) + " A:" + cAppsTextBox.Text.Substring(0, 1);
                    cReadyTextBox.Text = ReadyText;
                    this.TopMost = false;
                }
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private string fDecode(string rawdata, string queue)
        {
            try
            {

                if (rawdata.Contains(queue))
                {
                    string tmp = string.Empty;
                    int tmpfirst = rawdata.IndexOf(queue);
                    int tmptd = rawdata.IndexOf("</td>", tmpfirst);
                    int tmpsecond = rawdata.IndexOf("<td HEADERS='1' class='nn' >", tmpfirst) + "<td HEADERS='1' class='nn' >".Length;
                    tmptd = rawdata.IndexOf("</td>", tmpsecond);
                    tmp = rawdata.Substring(tmpsecond, (tmptd - tmpsecond));
                    int tmpthird = rawdata.IndexOf("<td HEADERS='2'", tmpsecond) + "<td HEADERS='2' class='nn'".Length;
                    int tmpthird_2 = rawdata.IndexOf('>', tmpthird);
                    tmptd = rawdata.IndexOf("</td>", tmpthird_2);
                    // trim left over > the position of this char seems to change
                    tmp += rawdata.Substring(tmpthird_2, (tmptd - tmpthird_2));
                    tmp = tmp.Replace('>', ' ');
                    //tmp = tmp.Substring(2, tmp.Length - 2);
                    if (AnalystPrimaryQueue == queue)
                    {
                        eventtrigger(tmp);
                    }
                    return tmp;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            return string.Empty;
        }
        private string fDecode2(string rawdata, string queue)
        {
            try
            {

                if (rawdata.Contains(queue))
                {
                    string tmp = string.Empty;
                    int tmpfirst = rawdata.IndexOf(queue);
                    int tmptd = rawdata.IndexOf("</td>", tmpfirst);
                    int tmpsecond = rawdata.IndexOf("<td HEADERS=1 class='nn' >", tmpfirst) + "<td HEADERS=1 class='nn' >".Length;
                    tmptd = rawdata.IndexOf("</td>", tmpsecond);
                    tmp = rawdata.Substring(tmpsecond, (tmptd - tmpsecond));
                    int tmpthird = rawdata.IndexOf("<td HEADERS=2", tmpsecond) + "<td HEADERS=2 class='nn'".Length;
                    int tmpthird_2 = rawdata.IndexOf('>', tmpthird);
                    tmptd = rawdata.IndexOf("</td>", tmpthird_2);
                    // trim left over > the position of this char seems to change
                    tmp += rawdata.Substring(tmpthird_2, (tmptd - tmpthird_2));
                    tmp = tmp.Replace('>', ' ');
                    //tmp = tmp.Substring(2, tmp.Length - 2);
                    if (AnalystPrimaryQueue == queue)
                    {
                        eventtrigger(tmp);
                    }
                    return tmp;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            return string.Empty;
        }
        private void eventtrigger(string queue)
        {
            try
            {
                string[] rawminutes = queue.Split(':');
                int queueminutes = Convert.ToInt32(rawminutes[1]);
                int waiting = Convert.ToInt32(rawminutes[0].Substring(0, 1));
                int timewait = 0;
                bool vFlash = false;
                bool vFront = false;
                string vColor = "Control";
                foreach (string rule in Rules)
                {
                    if (rule.ToLower().Contains("<time>") && rule.ToLower().Contains("</time>"))
                    {
                        string tmp = rule.Replace("<time>", "");
                        tmp = tmp.Remove(tmp.IndexOf("<"));
                        if (timewait <= queueminutes)
                        {
                            timewait = Convert.ToInt32(tmp);
                            if (rule.ToLower().Contains("color:"))
                            {
                                vColor = rule.Substring(rule.IndexOf("color:"));
                                vColor = vColor.Remove(vColor.IndexOf('>'));
                                vColor = vColor.Replace("color:", "").Trim();
                            }
                            

                            if (rule.ToLower().Contains("<flash>"))
                            {
                                vFlash = true;
                            }

                            if (rule.ToLower().Contains("<front>"))
                            {
                                vFront = true;
                            }
                            else { vColor = "control"; }
                        }

                    }
                    if (rule.ToLower().Contains("<waiting>") && rule.ToLower().Contains("</waiting>"))
                    {
                        string tmp = rule.Replace("<waiting>", "");
                        tmp = tmp.Remove(tmp.IndexOf("<"));
                        if (timewait <= queueminutes)
                        {
                            timewait = Convert.ToInt32(tmp);
                            if (rule.ToLower().Contains("color:"))
                            {
                                vColor = rule.Substring(rule.IndexOf("color:"));
                                vColor = vColor.Remove(vColor.IndexOf('>'));
                                vColor = vColor.Replace("color:", "").Trim();
                            }
                            
                            if (rule.ToLower().Contains("<flash>"))
                            {
                                vFlash = true;
                            }

                            if (rule.ToLower().Contains("<front>"))
                            {
                                vFront = true;
                            }
                        }
                        else { vColor = "control"; }

                    }
                }
                if (vColor != "control")
                {
                    foreach (Control element in this.Controls)
                    {
                        element.BackColor = ColorTranslator.FromHtml(vColor);
                    }
                    this.BackColor = ColorTranslator.FromHtml(vColor);

                }
                if (vColor == "control" || queueminutes == 0)
                {
                    foreach (Control element in this.Controls)
                    {
                        element.BackColor = SystemColors.Control;
                    }
                    this.BackColor = SystemColors.Control;

                }
                if (vFront == true)
                {
                    if (disablewarnings == false)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.TopMost = true;
                    }
                }
                if (vFlash == true && vFront == true)
                {
                    if (disablewarnings == false)
                    {
                        Flash(FLASHW_TRAY);
                    }
                }
                if (vFlash == true && vFront == false)
                {
                    if (disablewarnings == false)
                    {
                        Flash(FLASHW_TIMERNOFG);
                    }
                }
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

            
        }

        private void Flash(int flashtype)
        {
            try
            {
                FLASHWINFO fw = new FLASHWINFO();
                fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
                fw.hwnd = this.Handle;
                fw.dwFlags = 12;
                fw.uCount = UInt32.MaxValue;
                FlashWindowEx(ref fw);
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }


        private void checkstate()
        {
            //The main function, looks for Agent as a process name
            try
            {
                foreach (Process gP in Process.GetProcessesByName("agent"))
                {
                    IntPtr WinPtr = gP.MainWindowHandle; //windows pointer to the agent process
                    string TxtRsp = string.Empty; //store the windows title here
                    int len;  // Window caption if ((len = GetWindowTextLength(WindowHandle)) > 0) {     sb = new StringBuilder(len + 1);     if (GetWindowText(WindowHandle, sb, sb.Capacity) == 0)         throw new Exception(String.Format("unable to obtain window caption, error code {0}", Marshal.GetLastWin32Error()));     Caption = sb.ToString(); }
                    if ((len = GetWindowTextLength(WinPtr)) > 0) //check to make sure Agent has a title!
                    {
                        StringBuilder sb = new StringBuilder(len + 1);
                        //gather windows title and convert to string
                        if (GetWindowText(WinPtr, sb, sb.Capacity) == 0) throw new Exception(String.Format("unable to obtain window caption, error code {0}", Marshal.GetLastWin32Error()));
                        TxtRsp = sb.ToString();
                    }
                    if (gP.MainWindowTitle.Contains("Ready") && gP.MainWindowTitle.Contains("Work") == false && gP.MainWindowTitle.Contains("Not") == false)
                    {
                        cStatusPictureBox.BackgroundImage = Image.FromFile(AppPath + @"\Resources\OnReady.gif");
                        //status = 1; // read is 1
                        cPhoneStatustextBox.Text = "Ready";
                        HideMainForm();
                        break;

                    }
                    else if (gP.MainWindowTitle.Contains("Talk"))
                    {
                        cStatusPictureBox.BackgroundImage = Image.FromFile(AppPath + @"\Resources\OnConversation.gif");
                        //status = 2;
                        cPhoneStatustextBox.Text = "Talk";
                        HideMainForm();
                        break;

                    }
                    else if (gP.MainWindowTitle.Contains("Hold"))
                    {
                        cStatusPictureBox.BackgroundImage = Image.FromFile(AppPath + @"\Resources\OnHold.gif");
                        //status = 3;
                        cPhoneStatustextBox.Text = "Hold";
                        HideMainForm();
                        break;

                    }
                    else if (gP.MainWindowTitle.Contains("Reserved"))
                    {
                        cStatusPictureBox.BackgroundImage = Image.FromFile(AppPath + @"\Resources\OnCall.gif");
                        //status = 3;
                        cPhoneStatustextBox.Text = "Reserved";

                        break;

                    }
                    else if (gP.MainWindowTitle.Contains("Work"))
                    {
                        cStatusPictureBox.BackgroundImage = Image.FromFile(AppPath + @"\Resources\OnWrap.gif");
                        //status = 4;
                        cPhoneStatustextBox.Text = "WORK READY!!!";
                        ShowMainForm();
                        break;

                    }
                    else
                    {
                        cStatusPictureBox.BackgroundImage = Image.FromFile(AppPath + @"\Resources\OffReady.gif");
                        //status = 4;
                        cPhoneStatustextBox.Text = "Not Ready";
                        HideMainForm();
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }

        }

        private void ShowMainForm()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(ShowMainForm));
                    return;
                }
                if (disablewarnings == false)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                }
                //Screen_Flash();
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.InnerException.Message);
                Application.Exit();
            }

        }
        private void HideMainForm()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(HideMainForm));
                    return;
                }

                this.TopMost = false;
            }
            catch (Exception ex)
            {
                stopalltimers();
                MessageBox.Show(ex.InnerException.Message);
                Application.Exit();
            }

        }


        //Yes dammit, I did this just because I'm a repetetive lazy bastard. :P
        private void cAppsQueue_HyperLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(url);
        }
        //Yes dammit, I did this just because I'm a repetetive lazy bastard. :P
        private void cFinQueue_HyperLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(url);
        }
        //Yes dammit, I did this just because I'm a repetetive lazy bastard. :P
        private void cToolsQueue_HyperLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(url);
        }
        private void cReadyQueue_HyperLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(url2);
        }

        private void showScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fControlStatesandLocations();
        }

        private void fControlStatesandLocations()
        {
            //try
            //{
            //    if (showScheduleToolStripMenuItem.Checked == true && showPhoneStatusToolStripMenuItem.Checked == true)
            //    {
            //        this.Height = 415;
            //        this.Width = 295;
            //        ScheduleGroupBox.Location = new Point(0, 147);
            //        cNow_Hyperlink.Location = new Point(32, 25);
            //        cNextSch_Hyperlink.Location = new Point(32, 69);
            //        cNextTextBox.Location = new Point(89, 69);
            //        PhoneStatusGroupBox.Location = new Point(0, 264);
            //        cStatusPictureBox.Location = new Point(22, 19);
            //        cPhoneStatustextBox.Location = new Point(129, 20);
            //        ScheduleGroupBox.Show();
            //        cNow_Hyperlink.Show();
            //        cNextSch_Hyperlink.Show();
            //        cNextTextBox.Show();
            //        PhoneStatusGroupBox.Show();
            //        cStatusPictureBox.Show();
            //        cPhoneStatustextBox.Show();
            //    }
            //    if (showScheduleToolStripMenuItem.Checked == true && showPhoneStatusToolStripMenuItem.Checked == false)
            //    {
            //        this.Height = 295;
            //        this.Width = 295;
            //        ScheduleGroupBox.Location = new Point(0, 147);
            //        cNow_Hyperlink.Location = new Point(32, 25);
            //        cNextSch_Hyperlink.Location = new Point(32, 69);
            //        cNextTextBox.Location = new Point(89, 69);
            //        PhoneStatusGroupBox.Location = new Point(0, 264);
            //        cStatusPictureBox.Location = new Point(22, 19);
            //        cPhoneStatustextBox.Location = new Point(129, 20);
            //        ScheduleGroupBox.Show();
            //        cNow_Hyperlink.Show();
            //        cNextSch_Hyperlink.Show();
            //        cNextTextBox.Show();
            //        PhoneStatusGroupBox.Hide();
            //        cStatusPictureBox.Hide();
            //        cPhoneStatustextBox.Hide();

            //    }
            //    if (showScheduleToolStripMenuItem.Checked == false && showPhoneStatusToolStripMenuItem.Checked == true)
            //    {
            //        this.Height = 295;
            //        this.Width = 295;
            //        ScheduleGroupBox.Location = new Point(0, 264);
            //        cNow_Hyperlink.Location = new Point(32, 25);
            //        cNextSch_Hyperlink.Location = new Point(32, 69);
            //        cNextTextBox.Location = new Point(89, 69);
            //        PhoneStatusGroupBox.Location = new Point(0, 147);
            //        cStatusPictureBox.Location = new Point(12, 19);
            //        cPhoneStatustextBox.Location = new Point(166, 20);
            //        ScheduleGroupBox.Hide();
            //        cNow_Hyperlink.Hide();
            //        cNextSch_Hyperlink.Hide();
            //        cNextTextBox.Hide();
            //        PhoneStatusGroupBox.Show();
            //        cStatusPictureBox.Show();
            //        cPhoneStatustextBox.Show();
            //    }
            //    if (showScheduleToolStripMenuItem.Checked == false && showPhoneStatusToolStripMenuItem.Checked == false)
            //    {
            //        this.Height = 180;
            //        this.Width = 295;
            //        ScheduleGroupBox.Hide();
            //        cNow_Hyperlink.Hide();
            //        cNextSch_Hyperlink.Hide();
            //        cNextTextBox.Hide();
            //        PhoneStatusGroupBox.Hide();
            //        cStatusPictureBox.Hide();
            //        cPhoneStatustextBox.Hide();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    stopalltimers();
            //    MessageBox.Show(ex.Message);
            //    Application.Exit();
            //}
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fControlStatesandLocations();
        }

        private void showPhoneStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fControlStatesandLocations();
        }

        private void cMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePreferences();
        }

        private void cCheckSchedule_Tick(object sender, EventArgs e)
        {
            //populatescheduleelements();
            //queryschedule();
        }

        private void toolStripAnalystList_SelectedIndexChanged(object sender, EventArgs e)
        {
                //ScheduleGroupBox.Text = "Schedule: " + toolStripAnalystList.SelectedItem.ToString();
                //populatescheduleelements();
        }

        private void toolStripAnalystList_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripAnalystList_Leave(object sender, EventArgs e)
        {
            if (toolStripAnalystList.SelectedItem.ToString().Trim() != "")
            {
                cQueueCycle.Enabled = true;
                cCheckSchedule.Enabled = true;
                SetPrimaryQueueForAnalyst();
                fQueueStatusUpdate();
                fReadyStatusUpdate();
                this.Text = "Queue Monitoring";
                pause = false;

                
            }
        }

        private void cNow_Hyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FullSchedule tmp = new FullSchedule(toolStripAnalystList.SelectedItem.ToString());
            //tmp.Show();
        }

        private void toolStripAnalystList_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripAnalystList.SelectedItem.ToString().Trim() != "")
            {
                cQueueCycle.Enabled = false;
                //cCheckSchedule.Enabled = false;
                this.Text = "Disabled";
                pause = true;
                //MessageBox.Show("Disabled");
            }
        }

        private void MasterTimer_Tick(object sender, EventArgs e)
        {

            cQueueCycle.Enabled = true;
            /*
            string tmpday = DateTime.Now.DayOfWeek.ToString().ToUpper();
            DateTime Morning = Convert.ToDateTime("5:00:00 AM");
            DateTime Evening = Convert.ToDateTime("7:45:00 PM");
            DateTime Current = DateTime.Now;
            switch (cNowTextBox.Text.Trim().ToUpper())
            {
                case "L":
                    disablewarnings = true;
                    break;
                case "BR":
                    disablewarnings = true;
                    break;
                case "M":
                    disablewarnings = true;
                    break;
                case "V":
                    disablewarnings = true;
                    break;
                case "LV":
                    disablewarnings = true;
                    break;
                case "J":
                    disablewarnings = true;
                    break;
                case "U":
                    disablewarnings = true;
                    break;
                case "L8":
                    disablewarnings = true;
                    break;
                case "B":
                    disablewarnings = true;
                    break;
                case "":
                    disablewarnings = true;
                    break;
                default:
                    disablewarnings = false;
                    break;
            }*/
            /*
            if (tmpday.ToUpper() != "SATURDAY" || tmpday != "SUNDAY")
            {
                if (DateTime.Compare(Current, Morning) < 0 || DateTime.Compare(Current, Evening) > 0)
                    //if its before 5am or after 7:45pm
                {
                    if (cQueueCycle.Enabled == true || cCheckSchedule.Enabled == true)
                    {
                        cQueueCycle.Enabled = false;
                        //cCheckSchedule.Enabled = false;
                        this.Text = "Off Schedule, Monitor Sleeping";
                    }
                }
        
                else //within schedule hours
                {
                    if (pause != true && cQueueCycle.Enabled == false || cCheckSchedule.Enabled == false)
                        //if we are not in a pause state then we should be enabled
                    {
                        cQueueCycle.Enabled = true;
                        //cCheckSchedule.Enabled = true;
                        this.Text = "Queue Monitoring";
                    }
                }
            }
            else//outside of schedule days
            {
                cQueueCycle.Enabled = false;
                //cCheckSchedule.Enabled = false;
                this.Text = "Off Schedule, Monitor Sleeping";
            }
            */

        }

        private void SnoozeTimer_Tick(object sender, EventArgs e)
        {
            cQueueCycle.Enabled = true;
            //cCheckSchedule.Enabled = true;
            MasterTimer.Enabled = true;
            this.Text = "Queue Monitoring";
            //toolStripMenuItem1.Checked = false;
            SnoozeTimer.Enabled = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SnoozeTimer.Enabled = true;
            cQueueCycle.Enabled = false;
            //cCheckSchedule.Enabled = false;
            MasterTimer.Enabled = false;
            this.TopMost = false;
            this.WindowState = FormWindowState.Minimized;
            this.Text = "Pausing for 5 minutes...";
            //toolStripMenuItem1.Checked = true;
        }

        private void showScheduleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fControlStatesandLocations();
        }

        private void cCloudQueue_HyperLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void cReadyQueue_HyperLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(url2);
        }

        private void cToolsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void reportIssuesOrAskForToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2  form = new Form2();
            form.ShowDialog();

        }

        private void aboutQueueMonitoringSageERPX3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 form = new AboutBox1();
            form.ShowDialog();
        }

    }
}
