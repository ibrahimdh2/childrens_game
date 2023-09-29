

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AspectRatioManagerScript : MonoBehaviour
{
    public SpriteRenderer background;
    public SpriteRenderer fullBG;
    public float offSet;
    public float tabThreshold;
    
    void Awake()
    {
        ChangeOrthographicSize(offSet);
        



    }

    //for debugging remove after debugging (the whole update)
    void Update()
    {

        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log($"Screen Height {Screen.height}: Screen Width {Screen.width} Aspect Ratio {Screen.width/ Screen.height} Ratio2 {Screen.width/ Screen.height}");
        //    Debug.Log($"Height Inches {Screen.height/Screen.dpi} Width Inches {Screen.width/Screen.dpi}  inches ratio h/w{(Screen.height / Screen.dpi)/ (Screen.width / Screen.dpi)}  inches ratio w/h{(Screen.width / Screen.dpi)/ (Screen.height / Screen.dpi)}" );
        //    ChangeOrthographicSize(offSet);
        //    if (IsTablet(tabThreshold))
        //    {
        //        Debug.Log("Is a tab");
        //    }
        //    else
        //    {
        //        Debug.Log("Is a phone");
        //    }
        //}
        
    }
    public void ChangeOrthographicSize(float offSet)
    {
        float orthoSize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize+ offSet;
    }
    public bool IsTablet(float threshold)
    {
        return false;
    }


}
