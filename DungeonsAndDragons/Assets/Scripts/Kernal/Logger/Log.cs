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

        #region Enum types of this class
        /// <summary>
        /// log states
        /// </summary>
        public enum State
        {
            DeDevelop,
            Special,
            Deploy,
            Stop
        }
        #endregion
    }

}
