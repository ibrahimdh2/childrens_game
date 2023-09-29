using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectionManager : MonoBehaviour
{
    public SelectableUIScript currentSelectedObject;
    public SelectableUIScript previousSeletedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Deselect()
    {
        previousSeletedObject = currentSelectedObject;
        currentSelectedObject.Deselect();
        
        currentSelectedObject = null;
    }
}
