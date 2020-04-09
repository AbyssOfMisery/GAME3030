/*
 * Title:"Dungoen and dragons"
 *      
 *     global layer: UI covers
 *      
 * Description:
 *      when a windows open in game player cant click anything instead of that windows
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

public class UIMaskMgr : MonoBehaviour
{
    public GameObject GoTopPlane; //top panel
    public GameObject goMaskPlane; // cover plane
    private Camera _UICamera;
    private float _OriginalUICameraDepth; 

    // Start is called before the first frame update
    void Start()
    {
        _UICamera = this.gameObject.transform.parent.Find("UICamera").GetComponent<Camera>();

        if(_UICamera!=null)
        {
            _OriginalUICameraDepth = _UICamera.depth;
        }else
        {
            Debug.LogError(GetType() + "/Start()/_UICamera is NULL");
        }
    
    }
    /// <summary>
    /// active Mask Windows
    /// </summary>
    /// <param name="goDisplayPlane"></param>
    public void SetMaskWindow(GameObject goTopPlane)
    {
        //move top window depth Move down
        GoTopPlane.transform.SetAsLastSibling();
        //active cover window
        goMaskPlane.SetActive(true);
        //cover window depth Move down
        goMaskPlane.transform.SetAsLastSibling();
        //active window Move down
        goTopPlane.transform.SetAsLastSibling();
        //increase camera depth 
        if(_UICamera!=null)
        {
            _UICamera.depth = _UICamera.depth + 20;
        }
    }

    /// <summary>
    /// cancle mask window
    /// </summary>
    public void CancleMaskWindow()
    {
        //move top window depth Move up
        GoTopPlane.transform.SetAsFirstSibling();
        //deactive cover window
        goMaskPlane.SetActive(false);
        //recover camera depth 
        if (_UICamera != null)
        {
            _UICamera.depth = _OriginalUICameraDepth;
        }
    }

}
