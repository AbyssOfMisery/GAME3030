/*
 * Title:"Dungoen and dragons"
 *      
 *     Kernal layer: Trigger gameobjects hide and display
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

using Global;

namespace Kernal
{
    public class TriggerDisplayAndHide : MonoBehaviour
    {
        public string TagNameByPlayer = Tag.Player;
        public string TagNameByDisplayObject = "TagNameDisplayName";
        public string TagNameByHideObject = "TagNameHideName";

        private GameObject[] goDisplayObjectArray;
        private GameObject[] goHideObjectArray;

        // Start is called before the first frame update
        void Start()
        {
            //get display objects
            goDisplayObjectArray = GameObject.FindGameObjectsWithTag(TagNameByDisplayObject);
            //get hide objects
            goHideObjectArray = GameObject.FindGameObjectsWithTag(TagNameByHideObject);
        }

        /// <summary>
        /// trigger
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            //find player
            if(other.gameObject.tag == TagNameByPlayer)
            {
                foreach (var goItem in goDisplayObjectArray)
                {
                    goItem.SetActive(true);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //find player
            if (other.gameObject.tag == TagNameByPlayer)
            {
                foreach (var goItem in goHideObjectArray)
                {
                    goItem.SetActive(false);
                }
            }
        }

    }

}
