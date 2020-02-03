/*
 * Title:"Core helper classes "
 *      Integration of a large number of general-purpose algorithms
 *     
 *      
 * Description:
 *         
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kernal
{
    public class UnityHelper
    {
        private static UnityHelper _Instance = null; //instance
        private float floTime; //time counts

        private UnityHelper(){ }

        public static UnityHelper GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new UnityHelper();
            }
            return _Instance;
        }
        /// <summary>
        ///  get a time delays and return a boolean
        /// </summary>
        /// <param name="smallIntervalTime">small interval time</param>
        /// <returns></returns>
        public bool GetSmallTime(float smallIntervalTime)
        {
            floTime += Time.deltaTime; //frame times
            if(floTime >= smallIntervalTime)
            {
                floTime = 0;
                return true;
            }else
            {
                return false;
            }
        }

    }

}
