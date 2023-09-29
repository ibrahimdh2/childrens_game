

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AspectRatioManagerScript : MonoBehaviour
{
    public SpriteRenderer background;
    public SpriteRenderer fullBG;
    public float offSet;
    
    void Awake()
    {
        ChangeOrthographicSize();



    }

    //for debugging remove after debugging (the whole update)
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.Log($"Screen Height {Screen.height}: Screen Width {Screen.width} Aspect Ratio {Screen.width/ Screen.height} Ratio2 {Screen.width/ Screen.height}");
            ChangeOrthographicSize();
        }
        
    }
    public void ChangeOrthographicSize()
    {
        float orthoSize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize+ offSet;
    }


}
