/*
 * Title:"Dungoen and dragons"
 *      
 *      Kernal layer: dialog info
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
    public class DialogDataFormat 
    {
        /// <summary>
        /// Dialogue paragraph number 
        /// </summary>
        public int DialogSecNumber { set; get; }

        /// <summary>
        /// //Dialogue paragraph name
        /// </summary>
        public string DialogSecName { set; get; }

        /// <summary>
        /// paragraph number 
        /// </summary>
        public int SectionIndex { set; get; }

        /// <summary>
        /// Dialogue parties
        /// </summary>
        public string DialogSide { set; get; }
        /// <summary>
        /// dialog person name
        /// </summary>
        public string DialogPerson { set; get; }
        /// <summary>
        /// dialog
        /// </summary>
        public string DialogContent { set; get; }



    }
}

