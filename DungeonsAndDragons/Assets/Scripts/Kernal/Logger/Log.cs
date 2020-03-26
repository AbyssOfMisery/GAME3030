/*
 * Title:"Dungoen and dragons"
 *      
 *      Kernal layer: log testing system
 *      
 * Description:
 *        easy for game programmer to test the game
 *        basic logic:
 *          1: Write the debugging statements defined by the developer in the code to the cache of this log
 *          2:When the number in the cache exceeds the defined maximum write file value, the cache content debugging statement is written to the text file at one time
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */
using System.Collections;
using System.Collections.Generic;

using System;       //C# kernal namespace
using System.IO;     //File read-write namespace
using System.Threading; //Multi-threaded namespace


namespace Kernal
{
    public static class Log 
    {
        private static List<string> _LiLogArray; //log file caches
        private static string _LogPath;         //log file path
        private static State _LogState;          //log states
        private static int _LogMaxCapacity;      //log capacity
        private static int _LogBufferMaxNumber;    //max buffer number

        static Log()
        {
           
            //log array
            _LiLogArray = new List<string>();

            //log path
            IConfigManager configMgr = new ConfigManager(KernalParameter.SystemConfigInfo_LogPath,KernalParameter.SystemConfigInfo_LogRootNodeName);
            _LogPath = configMgr.AppSetting["LogPath"];

            if(string.IsNullOrEmpty(_LogPath))
            {
                _LogPath = UnityEngine.Application.persistentDataPath + "\\DungeonsAndDragonLog.txt";

            }
       
            //log state
            string strLogState = configMgr.AppSetting["LogState"];
            if(!string.IsNullOrEmpty(strLogState))
            {
                switch (strLogState)
                {
                    case "DeDevelop":
                        _LogState = State.Develop;
                        break;
                    case "Special":
                        _LogState = State.Special;
                        break;
                    case "Deploy":
                        _LogState = State.Deploy;
                        break;
                    case "Stop":
                        _LogState = State.Stop;
                        break;
                    default:
                        _LogState = State.Stop;
                        break;
                }
            }
            else
            {
                _LogState = State.Stop;
            }
     
            //log max capacity
            string strLogMaxCapacity = configMgr.AppSetting["LogMaxCapacity"];
            if(!string.IsNullOrEmpty(strLogMaxCapacity))
            {
                _LogMaxCapacity = Convert.ToInt32(strLogMaxCapacity);
            }
            else
            {
                _LogMaxCapacity = 2000;
            }
        
            //log max buffer 
            string strLogBufferMaxNumber = configMgr.AppSetting["LogBufferNumber"];
            if(!string.IsNullOrEmpty(strLogBufferMaxNumber))
            {
                _LogBufferMaxNumber = Convert.ToInt32(strLogBufferMaxNumber);
            }
            else
            {
                _LogBufferMaxNumber = 1;
            }
            
            //create file
            if (!File.Exists(_LogPath))          //check is there a log file
            {
                //create file
                File.Create(_LogPath);

                //stop create file if there is one exist
                Thread.CurrentThread.Abort();
            }

            //Synchronize the data in the log file to the log cache
            SyncFileDataToLogArray();

        }//log_end

        //Synchronize the data in the log file to the log cache
        private static void SyncFileDataToLogArray()
        {
            if(!string.IsNullOrEmpty(_LogPath))
            {
                StreamReader sr = new StreamReader(_LogPath);
                while (sr.Peek()>=0)
                {
                    _LiLogArray.Add(sr.ReadLine());
                }
                //you must close when its done reading file or it will cost ram lost
                sr.Close();
            }
        }

        /// <summary>
        /// record data to files
        /// </summary>
        /// <param name="writeFileData">info that you want to write into file</param>
        /// <param name="level">info levels</param>
        public static void Write(string writeFileData, Level level)
        {
            if(_LogState == State.Stop)
            {
                return;
            }

            //If the number of log buffers exceeds the specified capacity, it is cleared
            if(_LiLogArray.Count>= _LogMaxCapacity)
            {
                _LiLogArray.Clear();
            }

            if(!string.IsNullOrEmpty(writeFileData))
            {
                //save date and time when it's recorded
                writeFileData = "Log State:" +_LogState.ToString() + "/" +DateTime.Now.ToString()+"/"+ writeFileData;

                //For different "log states", write files to specific cases
                if (level == Level.High)
                {
                    writeFileData = "@@@ Error or Warning Important !!! @@@" + writeFileData;
                }
                switch (_LogState)
                {
                    case State.Develop:  //Develop mode
                        AppendDataToFile();
                        break;
                    case State.Special: //special mode
                        if(level == Level.Special || level ==Level.High)
                        {
                            AppendDataToFile();
                        }
                        break;
                    case State.Deploy:  //deploy mode
                        if (level == Level.High)
                        {
                            AppendDataToFile();
                        }
                        break;
                    case State.Stop:    //stop
                        break;
                    default:
                        break;
                }

            }

        }

        public static void Write(string writeFileData)
        {
            Write(writeFileData, Level.Low);
        }

        private static void AppendDataToFile()
        {

        }


        #region Enum types of this class
        /// <summary>
        /// log states
        /// </summary>
        public enum State
        {
            Develop,
            Special,
            Deploy,
            Stop
        }

        /// <summary>
        /// log info levels
        /// </summary>
        public enum Level
        {
            High,
            Special,
            Low
        }
        #endregion
    }

}
