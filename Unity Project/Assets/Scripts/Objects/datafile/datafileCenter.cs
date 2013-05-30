using UnityEngine;
using System.Collections;

public class datafileCenter : MonoBehaviour 
{
    private GameObject selectedObject;
    private GameObject previousSelectedObject;
    private GameObject upButton;
    private GameObject downButton;
    private GameObject leftButton;
    private GameObject rightButton;

	// Use this for initialization
	void Start () 
    {
        upButton = GameObject.Find("Up");
        downButton = GameObject.Find("Down");
        leftButton = GameObject.Find("Left");
        rightButton = GameObject.Find("Right");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (previousSelectedObject != selectedObject)
        {
            setControls();
            previousSelectedObject = selectedObject;
        }
	}
    public void setObject(GameObject target)
    {
        previousSelectedObject = selectedObject;
        selectedObject = target;
    }
    
    void setControls ()
    {
        upButton.GetComponent<datafileMoveUp>().datafileParent = selectedObject;
        downButton.GetComponent<datafileMoveDown>().datafileParent = selectedObject;
        leftButton.GetComponent<datafileMoveLeft>().datafileParent = selectedObject;
        rightButton.GetComponent<datafileMoveRight>().datafileParent = selectedObject;
    }
}
