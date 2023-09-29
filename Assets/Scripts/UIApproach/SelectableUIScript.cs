using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectableUIScript : MonoBehaviour
{
    public string objectName;

    //Outline toggled on and off by changing materials
    [Header("Visuals")]
    public Image objectImage;
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

    [Tooltip("The time it takes for animation to end")]
    public float popEndTime;
    public bool startTimeRegistered;

    public UISelectionManager selectionManager;
    public TextMeshProUGUI uiText;

    public RectTransform recT;

    // Start is called before the first frame update
    void Start()
    {
        recT = gameObject.GetComponent<RectTransform>();
        minSize = recT.localScale.x;
       
    }

    // Update is called once per frame
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
    public void Select()
    {
        objectImage.material = outlineMaterial;
        unpop = false;
        pop = true;
        uiText.enabled = true;
        selectionManager.currentSelectedObject = this;
        selectionManager.previousSeletedObject = selectionManager.currentSelectedObject;
        selectionManager.currentSelectedObject = this;
    }
    public void Deselect()
    {
        
        

        
        startTimeRegistered = false;
        uiText.enabled = false;

        //Change the iamge material to without outline
        pop = false;
        unpop = true;

    }
    //public void Reselect()
    //{
    //    startTimeRegistered = false;
    //    unpop = false;
    //    pop = true;
    //}
}
