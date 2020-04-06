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
using UnityEngine;

namespace Kernal
{
    public static class Log 
    {
        private static List<string> _LiLogArray; //log file caches
        private static string _LogPath = null;   //log file path
        private static State _LogState;          //log states
        private static int _LogMaxCapacity;      //log capacity
        private static int _LogBufferMaxNumber;  //max buffer number

        //system constant
        //XML Header noods
        private const string XML_CONFIG_LOG_PATH = "LogPath";//LogPath
        private const string XML_CONFIG_LOG_STATE = "LogState";//LogState
        private const string XML_CONFIG_LOG_MAX_CAPACITY = "LogMaxCapacity";//LogMaxCapacity
        private const string XML_CONFIG_LOG_BUFFER_NUMBER = "LogBufferNumber";//LogBufferNumber

        //Log state constant
        //Develop
        private const string XML_CONFIG_LOG_STATE_DEVELOP = "Develop";
        //Special
        private const string XML_CONFIG_LOG_STATE_SPECIAL = "Special";
        //Deploy
        private const string XML_CONFIG_LOG_STATE_DEPLOY = "Deploy";
        //Stop
        private const string XML_CONFIG_LOG_STATE_STOP = "Stop";

        //Log default path
        private const string XML_CONFIG_LOG_DEFAULT_PATH = "DungeonsAndDragonsLog.txt";

        //log max capacity
        private const int LOG_DEFAULT_MAX_CAPACITY_NUMBER = 2000;

        //log max buffer
        private const int LOG_DEFAULT_MAX_BUFFER = 1;

        //log warning sign
        private const string LOG_TIPS = "@@@ Important !!! @@@";

        //Temporary field

        private static string strLogState =null;//log state

        private static string strLogMaxCapacity=null;//log max capacity

        private static string strLogBufferMaxNumber=null;//log max buffer 


        static Log()
        {
            //log array
            _LiLogArray = new List<string>();

#if UNITY_STANDALONE_WIN || UNITY_EDITOR   
            //log path
            IConfigManager configMgr = new ConfigManager(KernalParameter.GetLogPath(), KernalParameter.GetLogRootNodeName());
            _LogPath = configMgr.AppSetting[XML_CONFIG_LOG_PATH];

            //log state
            strLogState = configMgr.AppSetting[XML_CONFIG_LOG_STATE];
            //log max capacity
            strLogMaxCapacity = configMgr.AppSetting[XML_CONFIG_LOG_MAX_CAPACITY];
            //log max buffer 
            strLogBufferMaxNumber = configMgr.AppSetting[XML_CONFIG_LOG_BUFFER_NUMBER];
#endif




            if (string.IsNullOrEmpty(_LogPath))
            {
                _LogPath = Application.persistentDataPath + "\\" + XML_CONFIG_LOG_DEFAULT_PATH;

            }
       
            //log state
           
            if(!string.IsNullOrEmpty(strLogState))
            {
                switch (strLogState)
                {
                    case XML_CONFIG_LOG_STATE_DEVELOP:
                        _LogState = State.Develop;
                        break;
                    case XML_CONFIG_LOG_STATE_SPECIAL:
                        _LogState = State.Special;
                        break;
                    case XML_CONFIG_LOG_STATE_DEPLOY:
                        _LogState = State.Deploy;
                        break;
                    case XML_CONFIG_LOG_STATE_STOP:
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
          
            if(!string.IsNullOrEmpty(strLogMaxCapacity))
            {
                _LogMaxCapacity = Convert.ToInt32(strLogMaxCapacity);
            }
            else
            {
                _LogMaxCapacity = LOG_DEFAULT_MAX_CAPACITY_NUMBER;
            }
        
            //log max buffer 
          
            if(!string.IsNullOrEmpty(strLogBufferMaxNumber))
            {
                _LogBufferMaxNumber = Convert.ToInt32(strLogBufferMaxNumber);
            }
            else
            {
                _LogBufferMaxNumber = LOG_DEFAULT_MAX_BUFFER;
            }
#if UNITY_STANDALONE_WIN || UNITY_EDITOR           
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
#endif
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
                writeFileData = XML_CONFIG_LOG_STATE + _LogState.ToString() + "/" +DateTime.Now.ToString()+"/"+ writeFileData;

                //For different "log states", write files to specific cases
                if (level == Level.High)
                {
                    writeFileData = LOG_TIPS + writeFileData;
                }
                switch (_LogState)
                {
                    case State.Develop:  //Develop mode
                        AppendDataToFile(writeFileData);
                        break;
                    case State.Special: //special mode
                        if(level == Level.Special || level ==Level.High)
                        {
                            AppendDataToFile(writeFileData);
                        }
                        break;
                    case State.Deploy:  //deploy mode
                        if (level == Level.High)
                        {
                            AppendDataToFile(writeFileData);
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

        //write data to files
        /// <summary>
        /// Append data to a file
        /// </summary>
        /// <param name="writeFileData">data that write in file</param>
        private static void AppendDataToFile(string writeFileData)
        {
            if(!string.IsNullOrEmpty(writeFileData))
            {
                //Debug information data is appended to the cache collection
                _LiLogArray.Add(writeFileData);

            }

            //The number of cache collections exceeds a certain specified number
            if (_LiLogArray.Count%_LogBufferMaxNumber == 0)
            {
                //Synchronize data information in cache to entity file
                SyncLogArrayToFile();
            }

        }

#region important function
        //Query all data in the log cache
        public static List<string> QueryAllDataFromBuffer()
        {
            if(_LiLogArray!=null)
            {
                return _LiLogArray;
            }
            else
            {
                return null;
            }
        }

        //Clear all data in entity log files and log cache
        public static void ClearLogFileAndBufferData()
        {
            if(_LiLogArray!=null)
            {
                _LiLogArray.Clear();
            }
            SyncLogArrayToFile();
        }

        /// <summary>
        /// Synchronize data information in cache to file
        /// </summary>
        public static void SyncLogArrayToFile()
        {
            if (!string.IsNullOrEmpty(_LogPath))
            {
                StreamWriter sw = new StreamWriter(_LogPath);
                foreach (string item in _LiLogArray)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
        }

#endregion


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
