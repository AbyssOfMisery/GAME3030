/*
 * Title:"Dungoen and dragons"
 *      
 *      kernal layer: dialog manager class
 *      
 * Description:
 *          out put dialogs
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
    /// <summary>
    /// character that's talking
    /// </summary>
    public enum DialogSide
    {
        None,               //none
        PlayerSide,         //player
        NPCSide             //npc
    }

    public class DialogDataMgr 
    {
        private static DialogDataMgr _Instance; //instance
        private static List<DialogDataFormat>  _AllDialogDataArray; //all dialog data array
        private static List<DialogDataFormat> _CurrentDialogBufferArray; //current dialog buffer
        private static int _IntIndexByDialogSection;                    //dialog index section number

        //constant vaule
        private const string XML_DEFINATION_HERO = "Hero";
        private const string XML_DEFINATION_NPC = "NPC";

        // original dialog index number
        private static int _OriginalDialogSectionNum = 1;

        private DialogDataMgr()
        {
            _AllDialogDataArray = new List<DialogDataFormat>();
            _CurrentDialogBufferArray = new List<DialogDataFormat>();
            _IntIndexByDialogSection = 0;
        }

        /// <summary>
        /// get instance
        /// </summary>
        /// <returns></returns>
        public static DialogDataMgr GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new DialogDataMgr();
            }
            return _Instance;
        }

        /// <summary>
        /// load outside data array 
        /// </summary>
        /// <param name="dialogDataArray"></param>
        /// <returns></returns>
        public bool LoadAllDialogData(List<DialogDataFormat> dialogDataArray)
        { 
            //bool check
            if (dialogDataArray == null || dialogDataArray.Count==0)
            {
                return false;
            }
            //load data
            if(_AllDialogDataArray!=null && _AllDialogDataArray.Count==0)
            {
                for (int i = 0; i < dialogDataArray.Count; i++)
                {
                    _AllDialogDataArray.Add(dialogDataArray[i]);
                }
            }
            else
            {
                return false;
            }

            return true;

        }//LoadAllDialogData_end

        /// <summary>
        /// get next dialog 
        /// </summary>
        /// <param name="diaSectionNum">section number</param>
        /// <param name="dialogSide">left side of right side(showing charater icon)</param>
        /// <param name="strPersonName">character's name</param>
        /// <param name="strDialogContent">dialog content</param>
        /// <returns></returns>
        public bool GetNextDialogInfoRecoder(int diaSectionNum, out DialogSide dialogSide, out string strPersonName, out string strDialogContent)
        {
            dialogSide = DialogSide.None;
        
            strPersonName = "[GetNextDialogInfoRecoder()/strPersonName]";
            strDialogContent = "[GetNextDialogInfoRecoder()/strDialogContent]";
            //input data check
            if (diaSectionNum<0)
            {
                return false;
            }

            //reset int Index By Dialog Section
            if (diaSectionNum != _OriginalDialogSectionNum)
            {
                _IntIndexByDialogSection = 0;

                _CurrentDialogBufferArray.Clear();

                _OriginalDialogSectionNum = diaSectionNum;
            }
            //if array isnt empty
            if(_CurrentDialogBufferArray != null && _CurrentDialogBufferArray.Count >= 1)
            {
                if(_IntIndexByDialogSection <_CurrentDialogBufferArray.Count)
                {
                    ++_IntIndexByDialogSection;
                }
                else
                {
                    return false;
                }
            }
            //array is empty
            else
            {
                ++_IntIndexByDialogSection;
            }
            //get dialog Dialog Content
            GetDialogInfoRecoder(diaSectionNum, out dialogSide, out strPersonName, out strDialogContent);

            return true;
        }

        /// <summary>
        /// get dialog content
        /// </summary>
        /// <param name="diaSectionNum"></param>
        /// <param name="dialogSide"></param>
        /// <param name="strPersonName"></param>
        /// <param name="strDialogContent"></param>
        /// <returns></returns>
        private bool GetDialogInfoRecoder(int diaSectionNum, out DialogSide dialogSide, out string strPersonName, out string strDialogContent)
        {
            dialogSide = DialogSide.None;
            string strDialogSide = "[GetNextDialogInfoRecoder()/strDialogSide]";
            strPersonName = "[GetNextDialogInfoRecoder()/strPersonName]";
            strDialogContent = "[GetNextDialogInfoRecoder()/strDialogContent]";

            if(diaSectionNum <=0)
            {
                return false;
            }

            if(_CurrentDialogBufferArray != null && _CurrentDialogBufferArray.Count >=1)
            {
                for (int i = 0; i < _CurrentDialogBufferArray.Count; i++)
                {
                    if(_CurrentDialogBufferArray[i].DialogSecNumber == diaSectionNum)
                    {
                        if(_CurrentDialogBufferArray[i].SectionIndex == _IntIndexByDialogSection)
                        {
                            strDialogSide = _CurrentDialogBufferArray[i].DialogSide;
                             
                            if(strDialogSide.Trim().Equals(XML_DEFINATION_HERO))
                            {
                                dialogSide = DialogSide.PlayerSide;
                            }
                            else if(strDialogSide.Trim().Equals(XML_DEFINATION_NPC))
                            {
                                dialogSide = DialogSide.NPCSide;
                            }
                            strPersonName = _CurrentDialogBufferArray[i].DialogPerson;
                            strDialogContent = _CurrentDialogBufferArray[i].DialogContent;

                            return true;
                        }
                    }
                }
            }//if_end

            if (_AllDialogDataArray != null && _AllDialogDataArray.Count >= 1)
            {
                for (int i = 0; i < _AllDialogDataArray.Count; i++)
                {
                    if (_AllDialogDataArray[i].DialogSecNumber == diaSectionNum)
                    {
                        if (_AllDialogDataArray[i].SectionIndex == _IntIndexByDialogSection)
                        {
                            strDialogSide = _AllDialogDataArray[i].DialogSide;

                            if (strDialogSide.Trim().Equals(XML_DEFINATION_HERO))
                            {
                                dialogSide = DialogSide.PlayerSide;
                            }
                            else if (strDialogSide.Trim().Equals(XML_DEFINATION_NPC))
                            {
                                dialogSide = DialogSide.NPCSide;
                            }
                            strPersonName = _AllDialogDataArray[i].DialogPerson;
                            strDialogContent = _AllDialogDataArray[i].DialogContent;
                            LoadToBufferArraySectionNum(diaSectionNum);

                            return true;
                        }
                    }
                }
            }//if_end
            return false;
        }

        /// <summary>
        /// put dialog in array
        /// </summary>
        /// <param name="diasecNum"></param>
        /// <returns></returns>
        private bool LoadToBufferArraySectionNum(int diasecNum)
        {
            if(diasecNum <=0)
            {
                return false;
            }
            if(_AllDialogDataArray!=null && _AllDialogDataArray.Count>=1)
            {
                //clear current dialog buffer array 
                _CurrentDialogBufferArray.Clear();

                for (int i = 0; i < _AllDialogDataArray.Count; i++)
                {
                    if(_AllDialogDataArray[i].DialogSecNumber == diasecNum)
                    {
                    

                        //add new one 
                        _CurrentDialogBufferArray.Add(_AllDialogDataArray[i]);
                    }
                }

                return true;
            }

            return false;
        }
    }
}

