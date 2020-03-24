/*
 * Title:"Dungoen and dragons"
 *      
 *      interface: Configuration Manager
 *      
 * Description:
 *        -load system core xml configuration
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */
using System.Collections;
using System.Collections.Generic;


namespace Kernal {
    public interface IConfigManager 
    {
        /// <summary>
        /// setting
        /// </summary>
        Dictionary<string,string> AppSetting { get; }

        /// <summary>
        /// get max settings
        /// </summary>
        /// <returns></returns>
         int GetAppSettingMaxNumber();
        
    }
}


