using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class is assigned to each interactable object, this allows the selection manager to
/// interact with the objects that have this script on them. Handles - popping and unpopping animations, resetting
/// animation animation after a certain time. Also the name
/// </summary>
public class SelectableObjectScript : MonoBehaviour
{
    [Header("Basics")]
   
    [Tooltip("The text that will be displayed on screen when the object is selected")]
    public string objectName; //this is the display name of the object
    public AudioSource nameSound; // this will be played when the object is selected
    public TextMeshProUGUI UINameText;


    //Outline toggled on and off by changing materials
    [Header("Visuals")]
    private SpriteRenderer spriteRenderer;
    public Material outlineMaterial;
    public Material withoutOutlineMaterial;
    

    [Header("Animation Parameters")]
    public bool pop;
    public bool unpop;
    public float minSize;
    public float maxSize;
    public float animationSpeed;

    //these parameters control the time of the pop start and end
    private float popStartTime;
    public int initialSortOrder;

    [Tooltip("The time it takes for animation to end")]
    public float popEndTime;
    public bool startTimeRegistered;


    

  
    void Start()
    {
        //referring the sprite renderer to be able to change materials with/without outline
        spriteRenderer = GetComponent<SpriteRenderer>();
        minSize = transform.localScale.x;
        initialSortOrder = spriteRenderer.sortingOrder;
        //using this formula so every object increases its size by the same exact proprotion. (To avoid different size increases).
        maxSize = minSize + (minSize/2.5f);
       
    }

    void Update()
    {
        //this handles slerped size to maxSize when the boolean is true
        //else-if branch does the opposite from maxSize to original size
        if (pop)
        {
            if (!startTimeRegistered)
            {
                popStartTime = Time.time;
                startTimeRegistered = true;
            }

            if (this.transform.localScale.x < maxSize)
            {
                Vector3 sizeChange = Vector3.Slerp(transform.localScale, new Vector3(maxSize, maxSize, maxSize),
                    animationSpeed * Time.deltaTime);

                transform.localScale = sizeChange;
            }
        }
        else if (unpop)
        {
            if (this.transform.localScale.x > minSize)
            {
                Vector3 sizeChange = Vector3.Slerp(transform.localScale, new Vector3(minSize, minSize, minSize),
                   animationSpeed * Time.deltaTime);

                transform.localScale = sizeChange;
            }

            else
            {
                unpop = false;
                startTimeRegistered = false;
            }
        }
        
        //After a certain amount of time the scale will be slerped to the original scale
        if (Time.time >= popStartTime + popEndTime)
        {
            if (!unpop)
            {
                pop = false;
                unpop = true;
                
            }
        }
        
    }

    /// <summary>
    /// This method is called when the object is selected.
    /// It changes the object's material to an outline material and 
    /// plays the pop animation.
    /// </summary>
    public void OnSelected()
    {
        if (nameSound != null)
        {
            nameSound.Play();
        }
        spriteRenderer.material = outlineMaterial;
        spriteRenderer.sortingOrder = initialSortOrder + 2;
        unpop = false;
        pop = true;
    }

    /// <summary>
    /// This method is called when the object is unselected.
    /// It changes the object's material to an without outline material and 
    /// plays the unpop animation.
    /// </summary>
    public void OnDeselected()
    {
        startTimeRegistered = false;
        spriteRenderer.material = withoutOutlineMaterial;
        spriteRenderer.sortingOrder = initialSortOrder;
        UINameText.text = "";
        pop = false;
        unpop = true;
    }

    /// <summary>
    /// This method is called when the object is clicked on again (selected again).
    /// It changes the object's material to an outline material and 
    /// plays the pop animation.
    /// </summary>
    public void OnReselect()
    {
        startTimeRegistered = false;
        unpop = false;
        pop = true;
    }
    
}
