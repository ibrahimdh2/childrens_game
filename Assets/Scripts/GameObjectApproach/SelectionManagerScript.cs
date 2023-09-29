using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class handles selection, deselection, and reselection of objects by
/// interacting with the objects.
/// </summary>
public class SelectionManagerScript : MonoBehaviour
{
    
    public SelectableObjectScript selectedObject;
    public SelectableObjectScript previousSelectedObject;
    public LayerMask selectableObjectMask;
    public Vector3 direction;
    public float distance;

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction);

           
            if (hit.collider != null)
            {
                
                SelectableObjectScript selectable = hit.collider.GetComponent<SelectableObjectScript>();
                

                if (selectable != null)
                {
                    if (selectable != selectedObject)
                    {
                        if (selectedObject != null)
                        {
                            selectedObject.OnDeselected();

                        }
                        selectedObject = selectable;
                        selectedObject.UINameText.text = selectedObject.objectName;
                        
                        selectedObject.OnSelected();

                    }
                    else
                    {
                        selectedObject.OnReselect();
                    }

                    
                }
                else
                {
                    
                    previousSelectedObject = selectedObject;
                    selectedObject.OnDeselected();
                    selectedObject.UINameText.text = "";
                    selectedObject = null;
                }
            }
            else
            {
                
                
                if (selectedObject != null)
                {
                    previousSelectedObject = selectedObject;
                    selectedObject.OnDeselected();
                    selectedObject.UINameText.text = "";
                }
               
                selectedObject = null;
            }
        }

    }
    
}
