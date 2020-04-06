/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: Beginner's guide manager
 *      
 * Description:
 *        Beginner's guide
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
using Kernal;

namespace View {
    public class GuideMgr : MonoBehaviour
    {
        //all 'new beginner guide' script
        private List<IGuideTrigger> _LiGuideTrigger = new List<IGuideTrigger>();

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);
            //add IGuideTrigger to list
            IGuideTrigger iTri_1 = TriggerDialogs.Instance;
            IGuideTrigger iTri_2 = TriggerOperET.Instance;
            IGuideTrigger iTri_3 = TriggerOperVisualKey.Instance;

            _LiGuideTrigger.Add(iTri_1);
            _LiGuideTrigger.Add(iTri_2);
            _LiGuideTrigger.Add(iTri_3);

            //active trigger logic check
            StartCoroutine("CheckGuidState");

        }

        /// <summary>
        /// Check boot status
        /// </summary>
        /// <returns></returns>
        IEnumerator CheckGuidState()
        {
            Log.Write(GetType()+ "/CheckGuidState");
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);
            
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                for (int i = 0; i < _LiGuideTrigger.Count; i++)
                {
                    IGuideTrigger iTrigger = _LiGuideTrigger[i];
                    //check every trigger is able to run

                    if(iTrigger.CheckCondition())
                    {
                        //Each trigger script, carried out trigger logic
                        if (iTrigger.RunOperation())
                        {
                            Log.Write(GetType() + "/CheckGuidState()/Number of trigger"+i+"logic run complete");
                            _LiGuideTrigger.Remove(iTrigger);
                        }

                    }//if_end

                }//for_end

            }//while_end

        }//CheckGuidState_End

    }

}

