using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Management;

namespace oBTC_ABC_Plus_Miner
{
    public partial class frmMain : Form
    {
        string appVersion = "1.0";

        bool logWork = false;

        string logFileName = "";

        string device = "";

        string url = "";
        string walletAddr = "";
        string password = "";


        bool advanced = false;

        string amdworkeradv = "";
        string amdpasswordadv = "";

        public frmMain()
        {
            InitializeComponent();

            gInfo.Enabled = false;

            Text += " V" + appVersion;

            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.ToLower().Contains("srbminer"))
                {
                    if (process.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                    {
                        process.Kill();
                    }
                }

                if (process.ProcessName.ToLower().Contains("suprminer"))
                {
                    if (process.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                    {
                        process.Kill();
                    }
                }
            }



        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            frmLoad frml = new frmLoad();
            frml.ShowDialog(this);

            if (frml.deviceList.Count > 0)
            {
                for (int i = 0; i < frml.deviceList.Count; i++)
                {
                    List<string> adevice = frml.deviceList[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    dataGridDevices.Rows.Add(new object[] { true, adevice[0].Replace(":", "").Trim(), adevice[1], adevice[3], "", "" });
                }

                gInfo.Enabled = true;

                LoadAdv();
            }
            else
            {
                MessageBox.Show("Device not found");
                Application.Exit();
                return;
            }
        }

        private void btnStartAdv_Click(object sender, EventArgs e)
        {
            advanced = true;

            if (btnStartAdv.Text == "Start")
            {
                if (txtWalletAdv.Text.Trim() == "")
                {
                    MessageBox.Show("Enter wallet address");
                    return;
                }

                if (txtPool.Text.Trim() == "")
                {
                    MessageBox.Show("Enter pool address");
                    return;
                }

                bool _checked = false;
                bool _worker_pass_empty = false;
                bool _amd_worker_pass_diff = false;

                string amdworker = "";
                string amdpassword = "";

                for (int i = 0; i < dataGridDevices.Rows.Count; i++)
                {
                    if ((bool)dataGridDevices.Rows[i].Cells[0].Value)
                    {
                        _checked = true;

                        if (dataGridDevices.Rows[i].Cells[4].Value.ToString().Trim() == "" || dataGridDevices.Rows[i].Cells[5].Value.ToString().Trim() == "")
                        {
                            _worker_pass_empty = true;
                        }

                        if (dataGridDevices.Rows[i].Cells[1].Value.ToString().Trim() == "AMD")
                        {
                            if ((amdworker == "") && (dataGridDevices.Rows[i].Cells[4].Value.ToString().Trim() != ""))
                            {
                                amdworker = dataGridDevices.Rows[i].Cells[4].Value.ToString().Trim();
                            }

                            if ((amdpassword == "") && (dataGridDevices.Rows[i].Cells[5].Value.ToString().Trim() != ""))
                            {
                                amdpassword = dataGridDevices.Rows[i].Cells[5].Value.ToString().Trim();
                            }

                            if ((amdworker != dataGridDevices.Rows[i].Cells[4].Value.ToString().Trim()))
                            {
                                _amd_worker_pass_diff = true;
                            }

                            if ((amdpassword != dataGridDevices.Rows[i].Cells[5].Value.ToString().Trim()))
                            {
                                _amd_worker_pass_diff = true;
                            }
                        }

                    }
                }

                if (!_checked)
                {
                    MessageBox.Show("No device selected");
                    return;
                }

                if (_worker_pass_empty)
                {
                    MessageBox.Show("Worker/Password Empty");
                    return;
                }

                if (_amd_worker_pass_diff)
                {
                    MessageBox.Show("AMD devices must have same Worker/Password");
                    return;
                }

                amdworkeradv = amdworker;
                amdpasswordadv = amdpassword;

                btnStartAdv.Enabled = false;
                txtPool.Enabled = false;
                txtWalletAdv.Enabled = false;
                dataGridDevices.Enabled = false;
                btnSelectAllAdv.Enabled = false;
                btnClearAdv.Enabled = false;
                txtParamsAMD.Enabled = false;
                txtParamsNvidia.Enabled = false;
                nPort.Enabled = false;

                walletAddr = txtWalletAdv.Text.Trim();

                url = txtPool.Text.Trim() + ":" + nPort.Value.ToString();

                List<string> amdDevices = new List<string>();
                List<string> nvidiaDevices = new List<string>();

                for (int i = 0; i < dataGridDevices.Rows.Count; i++)
                {
                    if ((bool)dataGridDevices.Rows[i].Cells[0].Value)
                    {
                        if (dataGridDevices.Rows[i].Cells[1].Value.ToString().Trim() == "AMD")
                        {
                            amdDevices.Add(dataGridDevices.Rows[i].Cells[2].Value.ToString().Trim() + " " + dataGridDevices.Rows[i].Cells[3].Value.ToString().Trim());
                        }

                        if (dataGridDevices.Rows[i].Cells[1].Value.ToString().Trim() == "NVIDIA")
                        {
                            nvidiaDevices.Add(dataGridDevices.Rows[i].Cells[2].Value.ToString().Trim() + " " + dataGridDevices.Rows[i].Cells[3].Value.ToString().Trim() + " " + dataGridDevices.Rows[i].Cells[4].Value.ToString().Trim() + " " + dataGridDevices.Rows[i].Cells[5].Value.ToString().Trim());
                        }
                    }
                }


                List<BackgroundWorker> bwPool = new List<BackgroundWorker>();

                tabDevices.TabPages.Clear();

                if (amdDevices.Count > 0)
                {
                    TabPage tb = new TabPage("AMD");
                    tb.BackColor = Color.White;

                    TextBox info = new TextBox();
                    info.BackColor = Color.White;
                    info.BorderStyle = BorderStyle.None;
                    info.Multiline = true;
                    info.Dock = DockStyle.Fill;
                    info.ReadOnly = true;
                    info.ScrollBars = ScrollBars.Vertical;
                    tb.Controls.Add(info);

                    tabDevices.TabPages.Add(tb);
                }

                if (nvidiaDevices.Count > 0)
                {
                    for (int i = 0; i < nvidiaDevices.Count; i++)
                    {
                        List<string> adevice = nvidiaDevices[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        TabPage tb = new TabPage(adevice[0]);
                        tb.BackColor = Color.White;

                        TextBox info = new TextBox();
                        info.BackColor = Color.White;
                        info.BorderStyle = BorderStyle.None;
                        info.Multiline = true;
                        info.Dock = DockStyle.Fill;
                        info.ReadOnly = true;
                        info.ScrollBars = ScrollBars.Vertical;
                        tb.Controls.Add(info);

                        tabDevices.TabPages.Add(tb);
                    }
                }


                string saveFile = Application.StartupPath + "\\" + "adv.dat";

                if (File.Exists(saveFile))
                {
                    File.Delete(saveFile);
                }

                StreamWriter sw = new StreamWriter(saveFile, false, Encoding.Default);
                sw.WriteLine(txtPool.Text.Trim());
                sw.WriteLine(nPort.Value.ToString().Trim());
                sw.WriteLine(txtWalletAdv.Text.Trim());
                sw.WriteLine(txtParamsNvidia.Text.Trim());
                sw.WriteLine(txtParamsAMD.Text.Trim());

                for (int i = 0; i < dataGridDevices.Rows.Count; i++)
                {
                    sw.WriteLine(dataGridDevices.Rows[i].Cells[1].Value.ToString().Trim() + ";" + dataGridDevices.Rows[i].Cells[2].Value.ToString().Trim() + ";" + dataGridDevices.Rows[i].Cells[3].Value.ToString().Trim() + ";" + dataGridDevices.Rows[i].Cells[0].Value.ToString().Trim() + ";" + dataGridDevices.Rows[i].Cells[4].Value.ToString().Trim() + ";" + dataGridDevices.Rows[i].Cells[5].Value.ToString().Trim() + ";");
                }
                sw.Close();

                int tabId = 0;

                if (amdDevices.Count > 0)
                {
                    BackgroundWorker bwStartAMD = new BackgroundWorker();
                    bwStartAMD.DoWork += BwStartAMD_DoWork;
                    bwStartAMD.RunWorkerAsync(new object[] { amdDevices, tabId++ });

                    bwPool.Add(bwStartAMD);
                }

                if (nvidiaDevices.Count > 0)
                {
                    for (int i = 0; i < nvidiaDevices.Count; i++)
                    {
                        BackgroundWorker bwStartNVIDIA = new BackgroundWorker();
                        bwStartNVIDIA.DoWork += BwStartNVIDIA_DoWork;
                        bwStartNVIDIA.RunWorkerAsync(new object[] { nvidiaDevices[i], tabId++ });

                        bwPool.Add(bwStartNVIDIA);
                    }
                }

                for (int i = 0; i < bwPool.Count; i++)
                {
                    while (bwPool[i].IsBusy)
                    {
                        Application.DoEvents();
                        Thread.Sleep(50);
                    }
                }

                btnStartAdv.Text = "Start";
                btnStartAdv.Enabled = true;
                txtPool.Enabled = true;
                txtWalletAdv.Enabled = true;
                dataGridDevices.Enabled = true;
                btnSelectAllAdv.Enabled = true;
                btnClearAdv.Enabled = true;
                txtParamsAMD.Enabled = true;
                txtParamsNvidia.Enabled = true;
                nPort.Enabled = true;
            }

            if (btnStartAdv.Text == "Stop")
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower().Contains("srbminer"))
                    {
                        if (process.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                        {
                            process.Kill();
                        }
                    }

                    if (process.ProcessName.ToLower().Contains("suprminer"))
                    {
                        if (process.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                        {
                            process.Kill();
                        }
                    }
                }
            }
        }

        private void BwStartAMD_DoWork(object sender, DoWorkEventArgs e)
        {
            TextBox info = (TextBox)tabDevices.TabPages[0].Controls[0];

            Action a;

            bool isFound = false;

            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.ToLower().Contains("srbminer"))
                {
                    if (p.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                    {
                        p.Kill();
                        isFound = true;
                    }
                }
            }

            if (isFound)
            {
                Thread.Sleep(1000);
            }

            logFileName = Application.StartupPath + "\\SRBMiner\\_out.txt";

            try
            {
                if (File.Exists(logFileName))
                {
                    File.Delete(logFileName);
                }
            }
            catch (Exception ex)
            {
                a = () => info.AppendText(ex.Message); info.Invoke(a);
                return;
            }

            string worker = "";
            string deviceIdList = "";


            if (!advanced)
            {
                List<string> amdDevices = (List<string>)((object[])e.Argument)[0];

                for (int i = 0; i < amdDevices.Count; i++)
                {
                    List<string> adevice = amdDevices[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    worker = "." + adevice[5];

                    deviceIdList += adevice[3] + "!";
                }

                deviceIdList = deviceIdList.Substring(0, deviceIdList.Length - 1);
            }
            else
            {
                List<string> amdDevices = (List<string>)((object[])e.Argument)[0];

                for (int i = 0; i < amdDevices.Count; i++)
                {
                    List<string> adevice = amdDevices[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    deviceIdList += adevice[1] + "!";
                }

                deviceIdList = deviceIdList.Substring(0, deviceIdList.Length - 1);
            }

            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.UseShellExecute = true;
                startInfo.FileName = Application.StartupPath + "\\SRBMiner\\SRBMiner-MULTI.exe";
                startInfo.WorkingDirectory = Application.StartupPath + "\\SRBMiner\\";

                if (!advanced)
                {
                    startInfo.Arguments = @"--disable-cpu --algorithm heavyhash --pool " + url + " --wallet " + walletAddr + worker + " --password " + password + " --gpu-id " + deviceIdList + " --log-file _out.txt";
                }
                else
                {
                    startInfo.Arguments = @"--disable-cpu --algorithm heavyhash --pool " + url + " --wallet " + walletAddr + "." + amdworkeradv + " --password " + amdpasswordadv + " --gpu-id " + deviceIdList + " --log-file _out.txt" + " " + txtParamsAMD.Text;
                }

                process.StartInfo = startInfo;
                process.Start();

                a = () => btnStartAdv.Text = "Stop"; btnStartAdv.Invoke(a);
                a = () => btnStartAdv.Enabled = true; btnStartAdv.Invoke(a);


                while (true)
                {
                    if (File.Exists(logFileName))
                    {
                        break;
                    }

                    Thread.Sleep(500);
                }

                logWork = true;

                BackgroundWorker bwLogAMD = new BackgroundWorker();
                bwLogAMD.DoWork += BwLogAMD_DoWork;
                bwLogAMD.RunWorkerAsync();

                process.WaitForExit();

                logWork = false;
            }
            catch (Exception ex)
            {
                logWork = false;
                a = () => info.AppendText(ex.Message); info.Invoke(a);
                return;
            }
        }

        private void BwStartNVIDIA_DoWork(object sender, DoWorkEventArgs e)
        {
            string nvidiaDevice = (string)((object[])e.Argument)[0];
            int tabId = (int)((object[])e.Argument)[1];

            TextBox info = (TextBox)tabDevices.TabPages[tabId].Controls[0];

            Action a;

            bool isFound = false;

            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.ToLower().Contains("suprminer"))
                {
                    if (p.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                    {
                        p.Kill();
                        isFound = true;
                    }
                }
            }

            if (isFound)
            {
                Thread.Sleep(1000);
            }

            string worker = "";
            string deviceIdList = "";

            string advworker = "";
            string advpassword = "";
            if (!advanced)
            {
                List<string> devinfo = nvidiaDevice.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                worker = "." + devinfo[5];
                deviceIdList = devinfo[3];
            }
            else
            {
                List<string> devinfo = nvidiaDevice.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                deviceIdList = devinfo[1];
                advworker = devinfo[2];
                advpassword = devinfo[3];
            }

            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = Application.StartupPath + "\\Suprminer\\suprminer.exe";
                startInfo.WorkingDirectory = Application.StartupPath + "\\Suprminer\\";

                if (!advanced)
                {
                    startInfo.Arguments = @"-a obtc -o " + url + " -u " + walletAddr + worker + " -p " + password + " -d " + deviceIdList;
                }
                else
                {
                    startInfo.Arguments = @"-a obtc -o " + url + " -u " + walletAddr + "." + advworker + " -p " + advpassword + " -d " + deviceIdList + " " + txtParamsNvidia.Text;
                }

                process.StartInfo = startInfo;
                process.Start();


                a = () => btnStartAdv.Text = "Stop"; btnStartAdv.Invoke(a);
                a = () => btnStartAdv.Enabled = true; btnStartAdv.Invoke(a);


                while (!process.HasExited)
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        a = () => info.AppendText(process.StandardOutput.ReadLine() + "\r\n"); info.Invoke(a);
                    }
                }

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                a = () => info.AppendText(ex.Message); info.Invoke(a);
                return;
            }
        }

        private void BwLogAMD_DoWork(object sender, DoWorkEventArgs e)
        {
            TextBox info = (TextBox)tabDevices.TabPages[0].Controls[0];

            Action a;

            FileStream fs = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (true)
                {
                    if (!logWork)
                    {
                        break;
                    }

                    try
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            a = () => info.AppendText(line + "\r\n"); info.Invoke(a);
                        }

                    }
                    catch { }

                    Thread.Sleep(500);
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.ToLower().Contains("srbminer"))
                {
                    if (process.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                    {
                        process.Kill();
                    }
                }

                if (process.ProcessName.ToLower().Contains("suprminer"))
                {
                    if (process.MainModule.FileName.ToLower().Contains(Application.StartupPath.ToLower()))
                    {
                        process.Kill();
                    }
                }
            }
        }

        private void LoadAdv()
        {
            try
            {
                string loadFile = Application.StartupPath + "\\" + "adv.dat";
                StreamReader sr = new StreamReader(loadFile, Encoding.Default);

                try
                {
                    List<string> devices = new List<string>();

                    int lineNum = 0;
                    while (!sr.EndOfStream)
                    {
                        if (lineNum == 0)
                        {
                            txtPool.Text = sr.ReadLine().Trim();
                            lineNum++;
                            continue;
                        }

                        if (lineNum == 1)
                        {
                            nPort.Value = Convert.ToDecimal(sr.ReadLine().Trim());
                            lineNum++;
                            continue;
                        }

                        if (lineNum == 2)
                        {
                            txtWalletAdv.Text = sr.ReadLine().Trim();
                            lineNum++;
                            continue;
                        }

                        if (lineNum == 3)
                        {
                            txtParamsNvidia.Text = sr.ReadLine().Trim();
                            lineNum++;
                            continue;
                        }

                        if (lineNum == 4)
                        {
                            txtParamsAMD.Text = sr.ReadLine().Trim();
                            lineNum++;
                            continue;
                        }


                        devices.Add(sr.ReadLine().Trim());

                    }

                    for (int i = 0; i < dataGridDevices.Rows.Count; i++)
                    {
                        string[] dev = devices[i].Split(';');

                        if (dataGridDevices.Rows[i].Cells[1].Value.ToString().Trim() != dev[0] || dataGridDevices.Rows[i].Cells[2].Value.ToString().Trim() != dev[1] || dataGridDevices.Rows[i].Cells[3].Value.ToString().Trim() != dev[2])
                        {
                            throw new Exception();
                        }

                        try
                        {
                            dataGridDevices.Rows[i].Cells[0].Value = Convert.ToBoolean(dev[3]);
                            dataGridDevices.Rows[i].Cells[4].Value = dev[4];
                            dataGridDevices.Rows[i].Cells[5].Value = dev[5];
                        }
                        catch
                        {
                            throw new Exception();
                        }
                    }

                }
                catch
                {
                    sr.Close();
                    File.Delete(loadFile);
                    return;
                }

                sr.Close();

            }
            catch
            {

            }


        }

        private void btnSelectAllAdv_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridDevices.Rows.Count; i++)
            {
                dataGridDevices.Rows[i].Cells[0].Value = true;
            }
        }

        private void btnClearAdv_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridDevices.Rows.Count; i++)
            {
                dataGridDevices.Rows[i].Cells[0].Value = false;
            }
        }
    }


}
