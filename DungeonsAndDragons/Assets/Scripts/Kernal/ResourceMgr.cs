/*
 * Title:"Dungoen and dragons"
 *      
 *      kernal layer: resource manager
 *      
 * Description:
 *      
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
    public class ResourceMgr : MonoBehaviour
    {
        private static ResourceMgr _Instance;  //instance
        private Hashtable ht = null;           //Collection of container key-value pairs
        
        private ResourceMgr()
        {
            ht = new Hashtable();
        }

        /// <summary>
        /// get instance
        /// </summary>
        /// <returns></returns>
        public static ResourceMgr GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new GameObject("ResourceMgr").AddComponent<ResourceMgr>();
            }
            return _Instance;
        }


        /// <summary>
        /// Call resource with object buffering
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        private T LoadResource<T>(string path, bool isCatch) where T : UnityEngine.Object
        {
            if(ht.Contains(path))
            {
                return ht[path] as T;
            }

            T TResource = Resources.Load<T>(path);
            if(TResource == null)
            {
                Debug.LogWarning(GetType() + "/GetInstance()/TResource no resource is loaded, path =" + path);

            }else if(isCatch)
            {
                ht.Add(path, TResource);
            }
            return TResource;
        }

        /// <summary>
        /// Call resource with object buffering
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        public GameObject LoadAsset(string _path, bool isCatch,Transform transform)
        {
            GameObject goObj = LoadResource<GameObject>(_path, isCatch);
            goObj.transform.position = transform.position;
            GameObject goObjClone = GameObject.Instantiate<GameObject>(goObj);

            if (goObjClone == null)
            {
                Debug.LogWarning(GetType() + "/LoadAsset/ failed, path = " + _path);
            }
            return goObjClone;
        }

    }

}
