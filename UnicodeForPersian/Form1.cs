using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace UnicodeForPersian
{
    public partial class Form1 : Form
    {
        private BackgroundWorker checkUpdates;
        private Timer netconnectiontimer;
        private float version = 1f;

        public Form1()
        {
            InitializeComponent();
        }

   
    
        private void btnopendir_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dirDialog=new FolderBrowserDialog();
            dirDialog.Description = "پوشه زیرنویس ها را انتخاب کنید";
            dirDialog.ShowNewFolderButton = true;
            DialogResult dialogResult= dirDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtdirpath.Text = dirDialog.SelectedPath;
            }
            

        }

        private void btnconvertdirs_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if(txtdirpath.Text!="" && Directory.Exists(txtdirpath.Text))
            {
                string path = txtdirpath.Text;
                ReadDirectories(path, chksubdir.Checked);
                Cursor.Current = Cursors.Default;
                Show_Completed_Message();
            }
            
        }

        private void ReadDirectories(string dirpath,bool checkSubdir)
        {
            
            bool DirExists = Directory.Exists(dirpath);

            if (DirExists)
            {
                string[] fileNames = Directory.GetFiles(dirpath,"*.srt");
                if(fileNames.Length>0)
                    ArrangeFiles(fileNames);
                if (!checkSubdir)
                    return;
                else
                {
                    string[] directories = Directory.GetDirectories(dirpath);

                    if (directories.Length > 0)
                    {
                        foreach (string directory in directories)
                        {
                            ReadDirectories(directory,true);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

            }
        }



        private void btnopenfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = true;
            fileDialog.RestoreDirectory = true;
            fileDialog.Title = "انتخاب زیرنویس (ها)";
            fileDialog.Filter="SRT Subtitle (*.srt)|*.srt";

            DialogResult dialogResult = fileDialog.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            if (dialogResult == DialogResult.OK)
            {
                String[] fileNames = fileDialog.FileNames;
                ArrangeFiles(fileNames);

            }
            Cursor.Current = Cursors.Default;
            Show_Completed_Message();
        }

        private void ArrangeFiles(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                ConvertFile(fileName);
            }
        }

        private string ChangeFileName(string fileName,string postfix)
        {
            fileName = fileName.Substring(0, fileName.Length - 4) + postfix + fileName.Substring(fileName.Length - 4);
            return fileName;
        }

        private void ConvertFile(string filename)
        {
            if (File.Exists(filename))
            {
                String subtitle = File.ReadAllText(filename, Encoding.Default);
                SubRipServices Services = new SubRipServices();
                string converted = Services.ToUnicode(subtitle);

                File.Copy(filename, ChangeFileName(filename,"_Orig"),true);
                File.WriteAllText(filename, converted, Encoding.Unicode);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkUpdates = new BackgroundWorker();
            checkUpdates.DoWork += new DoWorkEventHandler(CheckUpdate);
            listBox1.DisplayMember = "Text";
            listBox1.ValueMember = "Value";

            int onemin = 60000;
            int fivemin = 5*onemin;
            netconnectiontimer=new Timer();
            netconnectiontimer.Interval = fivemin;
            netconnectiontimer.Tick+=new EventHandler(NetConnectionState);
            netconnectiontimer.Enabled = true;
            NetConnectionState(null, null);
            netconnectiontimer.Start();
          
    
        }

        private void CheckUpdate(object sender, DoWorkEventArgs e)
        {
            netconnectiontimer.Stop();
            RSSReader();
            WebClient client = new WebClient();
            var stream = client.DownloadString("http://www.parsnevis.in/lastver.txt");
            float version;
            float.TryParse(stream.ToString(), out version);
            if (this.version < version)
            {
                notifyIcon1.Text = "نسخه جدید را دریافت کنید";
                notifyIcon1.BalloonTipTitle = "نسخه جدید نرم افزار";
                notifyIcon1.BalloonTipText = "برای دانلود اینجا کلیک کنید";
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.Click += new EventHandler(download);
                notifyIcon1.ShowBalloonTip(6000);
            }
        }

        private void NetConnectionState(object sender,EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    checkUpdates.RunWorkerAsync();
                }
            }
            catch
            {
                return;
            }
        }

        private void download(object sender, EventArgs e)
        {
            FolderBrowserDialog dirDialog=new FolderBrowserDialog();
            dirDialog.Description = "محل ذخیره را مشخص کنید";
            DialogResult result= dirDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                WebClient wc = new WebClient();
                string filename = "parsnevis_persian_reshaper.exe";
                string dirpath = Path.Combine(dirDialog.SelectedPath , filename);
                int j = 2;
                while (File.Exists(dirpath))
                {
                  dirpath=Path.Combine(dirDialog.SelectedPath,ChangeFileName(filename,"_"+j.ToString()));
                    j++;
                }
                             notifyIcon1.Text = "دانلود برنامه آغاز شد";
                notifyIcon1.BalloonTipTitle = "آغاز دانلود";
                notifyIcon1.BalloonTipText = "تا یک یا دو دقیقه دیگر برنامه روی سیستم شما دانلود شده است";
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(6000);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadfinished);
                wc.DownloadFileAsync(new Uri("http://www.parsnevis.in/" + filename), dirpath);
                
            }
        }

        private void downloadfinished(object sender, EventArgs e)
        {
             notifyIcon1.Text = "دانلود به پایان رسید";
                notifyIcon1.BalloonTipTitle = "پایان دانلود";
                notifyIcon1.BalloonTipText = "از این پس از برنامه جدید استفاده کنید و برنامه فعلی را حذف نمایید";
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(6000);
        }

        private void RSSReader()
        {
            WebClient wc=new WebClient();
            var response=wc.DownloadString("http://parsnevis.in/external.php?type=RSS2");
            XmlDocument doc=new XmlDocument();
            doc.LoadXml(response);


      

            foreach (XmlNode xmlnode in doc.ChildNodes[1].ChildNodes[0].ChildNodes)
            {
                if (xmlnode.Name == "item")
                {
                    XmlNode xtitle = xmlnode.ChildNodes[0];
                    XmlNode xlink = xmlnode.ChildNodes[1];

                    string title = xtitle.InnerText;
                    string link = xlink.InnerText;

                    var utf8 = Encoding.UTF8;
                    byte[] utfBytes = Encoding.Default.GetBytes(title);
                    title = utf8.GetString(utfBytes, 0, utfBytes.Length);
   
                    ListItem item=new ListItem();
                    item.Text = title;
                    item.Value = link;

                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(
                            new MethodInvoker(delegate { listBox1.Items.Add(item); }));
                    }
                    else
                    {
                        listBox1.Items.Add(item);
                    }
                    
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string link = ((ListItem) listBox1.SelectedItem).Value;
            Process.Start(link);
        }

        private void Show_Completed_Message()
        {
            MessageBox.Show("عملیات به پایان رسید", "اتمام عملیات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
     
    }
}
