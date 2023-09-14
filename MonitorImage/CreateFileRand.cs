using CameraCapture;
using CameraCapture.tools;
using CreateFileRand.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateFileRand {
    public partial class CreateFileRand : Form {
        private static INIClassHelper config_ini;
        private const string Config_Para = "MonitorImage";
        const string DestSavePath_KEY = "DestSavePath";
        const string Intval_KEY = "Intval_KEY";
        

        public CreateFileRand() {
            InitializeComponent();
            config_ini = new INIClassHelper(Tools.getCurrentDirectory() + "config.ini");
            InitReadPara();
        }
        /// <summary>
        /// 读取参数
        /// </summary>
        public void InitReadPara() {
            if(!config_ini.ExistINIFile()) {
                setAndSave_DefaultPara();
                return;
            } else {
                try {
                    //@ MonitorImagePara.IsService = config_ini.IniReadValue(Config_Para,"IsService");
                    CreateFilePathPara.DestSavePath = config_ini.IniReadValue(Config_Para,DestSavePath_KEY);
                    CreateFilePathPara.Intval = int.Parse(config_ini.IniReadValue(Config_Para,Intval_KEY,2000));
                    if(string.IsNullOrEmpty(CreateFilePathPara.DestSavePath)) {
                        setAndSave_DefaultPara();
                    }
                } catch(Exception) {
                    setAndSave_DefaultPara();
                }
            }
        }
        public void setAndSave_DefaultPara() {
            CreateFilePathPara.DestSavePath = @"D:\";
            CreateFilePathPara.Intval = 2000;

            config_ini.IniWriteValue(Config_Para,DestSavePath_KEY,CreateFilePathPara.DestSavePath);
            config_ini.IniWriteValue(Config_Para,Intval_KEY,CreateFilePathPara.Intval.ToString());
        }


        private void MainForm_Load(object sender,EventArgs e) {
            tb_imageSavePath.Text = CreateFilePathPara.DestSavePath;
            tb_intval.Text = CreateFilePathPara.Intval.ToString();

            Thread.Sleep(500);
            createFileRand();
        }

        public System.Timers.Timer timer = null;
        private void createFileRand() {
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(callBackCreateFile); //到达时间的时候执行事件；   
            timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；
            timer.Stop();
        }

        private void callBackCreateFile(object sender,System.Timers.ElapsedEventArgs e) {
            timer.Stop();
            string fileName = DateTime.Now.ToString("HHmmss")+".txt" ;
            WriteLog.WriteStr(CreateFilePathPara.DestSavePath + "\\" + fileName,Tools.GetRandomString());
            timer.Start();
        }
        public static class CreateFilePathPara {
            public static string DestSavePath { get; set; }//
            public static int Intval { get; set; }//
        }
       

        private void tb_selectImagePath_Click(object sender,EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //打开指定目录
            dialog.SelectedPath = CreateFilePathPara.DestSavePath;

            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                tb_imageSavePath.Text = dialog.SelectedPath;
                CreateFilePathPara.DestSavePath = tb_imageSavePath.Text;
                config_ini.IniWriteValue(Config_Para,DestSavePath_KEY,CreateFilePathPara.DestSavePath);
            }
        }

        private void bt_switch_Click(object sender,EventArgs e) {
            if(bt_switch.Text.Equals("启动")) {
                timer.Start();
                bt_switch.Text = "停止";
            } else {
                timer.Stop();
                bt_switch.Text = "启动";
            }
        }

        private void bt_intval_Click(object sender,EventArgs e) {
            try {
                int intval = int.Parse(tb_intval.Text);
                if(intval < 20) {
                    MessageBox.Show("数字<20，请适当延长");
                } else {
                    timer.Stop();
                    Thread.Sleep(100);
                    timer.Interval = intval;
                    timer.Start();
                    config_ini.IniWriteValue(Config_Para,Intval_KEY,CreateFilePathPara.Intval.ToString());
                }
            } catch(Exception) {
                MessageBox.Show("请输入数字，单位");
                throw;
            } 

        }

        private void CreateFileRand_FormClosed(object sender,FormClosedEventArgs e) {
            System.Environment.Exit(0);
        }
    }
}
