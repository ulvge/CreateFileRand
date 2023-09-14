using CameraCapture;
using CameraCapture.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateFileRand {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            //服务启动时，无法在脚本里面带参数
            //直接运行可执行文件，才能带参数。所以有参数的是采集端 ，没有参数的是服务分析端
            bool isCreateOK;
            System.Threading.Mutex run = new System.Threading.Mutex(true,"MonitorImage",out isCreateOK);
            if(!isCreateOK) {
                MessageBox.Show("已经运行了一个实例了","错误");
                return;
            }
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CreateFileRand());
            } catch(Exception ex) {
                string info = "运行失败 " + ex.Message;
                WriteLog.WriteLogFile(info);
                MessageBox.Show(info);
            }
        }
    }
}
