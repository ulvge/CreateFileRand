using CreateFileRand.tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraCapture.tools {
    class WriteLog {
        private static object m_lockLog = new object();
        #region 写日志
        public static void WriteLogFile(string input) {
            lock(m_lockLog) {
                Console.WriteLine(input);
                ///指定日志文件的目录
                ///
                string fDirectory = Tools.getCurrentDirectory() + "log\\";
                string fname = fDirectory+DateTime.Now.ToString("yyyyMMdd")+"_log.txt";
                DirectoryInfo dInfo = new DirectoryInfo(fDirectory);
                if(!dInfo.Exists) {
                    dInfo.Create();
                }

                FileInfo finfo = new FileInfo(fname);
                if(!finfo.Exists) {
                    FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.ReadWrite);
                    //using (StreamWriter writer1 = new StreamWriter(_file))

                    //FileStream fs = File.Create(fname);
                    fs.Close();
                    finfo = new FileInfo(fname);
                }



                /**/

                ///判断文件是否存在以及是否大于2K

                if(finfo.Length > 1024 * 1024 * 10) {

                    /**/

                    ///文件超过10MB则重命名

                    File.Move(fDirectory + "LogFile.txt",fDirectory + "" + DateTime.Now.ToString("yyyyMMddHHmmss") + "LogFile.txt");

                    /**/

                    ///删除该文件

                    //finfo.Delete();

                }

                //finfo.AppendText();

                /**/

                ///创建只写文件流


                //FileStream _file = new FileStream(fname,FileMode.Create, FileAccess.ReadWrite);
                FileStream _file = new FileStream(fname,FileMode.Append,FileAccess.Write);
                using(StreamWriter w = new StreamWriter(_file))
                // using (FileStream fs = finfo.OpenWrite())

                {
                    ///根据上面创建的文件流创建写数据流
                    //StreamWriter w = new StreamWriter(fs);
                    ///设置写数据流的起始位置为文件流的末尾
                    w.BaseStream.Seek(0,SeekOrigin.End);
                    ///写入当前系统时间并换行
                    string headStr = string.Format("{0} {1} ", DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString());
                    ///写入日志内容并换行
                    w.Write(headStr+input + Environment.NewLine);
                    ///清空缓冲区内容，并把缓冲区内容写入基础流
                    w.Flush();
                    /**/
                    ///关闭写数据流
                    w.Close();
                }
            }
        }
        private static object m_lockWriteStr = new object();
        public static bool WriteStr(string fullName,string input) {
            lock(m_lockWriteStr) { 
                try {
                    //input = input.Trim();
                    //var gbk_data = Encoding.GetEncoding("GBK").GetBytes(input);
                    //using(StreamWriter writer = new StreamWriter(fullName,false)) {
                    //    writer.WriteLine(input);
                    //    writer.Flush();
                    //}
                    System.IO.File.WriteAllText(fullName,input,Encoding.GetEncoding("GBK"));
                    return true;
                } catch(Exception e) {
                    WriteLogFile(e.Message +":"+ input);
                    return false;
                }
            }
        }

        public static bool ReadStr(string fullName,out string outPut_Err) {
            try {
                outPut_Err = string.Empty;
                FileInfo finfo = new FileInfo(fullName);
                if(!finfo.Exists) {
                    outPut_Err = "read file is not exsit " + fullName;
                    return false;
                } else {
                    if(finfo.Length > 1000) {
                        outPut_Err = "read file is too long " + finfo.Length;
                        WriteLogFile(outPut_Err);
                        return false;
                    }
                }
                string res = string.Empty;
                FileStream _file = new FileStream(fullName,FileMode.Open,FileAccess.Read);
                StreamReader sr = new StreamReader(_file);
                //while(sr.ReadLine() != null) {
                //    res += sr.ReadLine();
                //}
                res = sr.ReadToEnd();
                outPut_Err = res;
                sr.Close();
                return true;
            } catch(Exception e) {
                outPut_Err = e.Message;
                throw e;
            }
        }
        #endregion
    }
}
