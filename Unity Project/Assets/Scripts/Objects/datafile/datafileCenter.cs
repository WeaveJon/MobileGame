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
    public float force;

    // Use this for initialization
    void Start()
    {
        upButton = GameObject.Find("Up");
        downButton = GameObject.Find("Down");
        leftButton = GameObject.Find("Left");
        rightButton = GameObject.Find("Right");
        GameObject temp = GameObject.FindGameObjectWithTag("Datafile");
        setObject(temp);
        temp.GetComponent<datafileObject>().Selected();
    }

    // Update is called once per frame
    void Update()
    {
        if (previousSelectedObject != selectedObject)
        {
            previousSelectedObject = selectedObject;
        }
    }

    public void setObject(GameObject target)
    {
        previousSelectedObject = selectedObject;
        selectedObject = target;
    }

    public void MoveDataFile(string button)
    {
        if (selectedObject == null)
        {
            Debug.Log("Please select a data file");
            GameObject mainCamera = GameObject.Find("Main Camera");
            mainCamera.GetComponent<InGameMenu>().SelectAPiece();
        }

        else
        {
            switch (button)
            {

                case "Down":
                    if (selectedObject.GetComponent<datafileObject>().canMoveAgain == true)
                    {
                        selectedObject.GetComponent<datafileObject>().PreviousPosition();
                        selectedObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                        selectedObject.rigidbody.AddForce(Vector3.down * force);
                        selectedObject.GetComponent<datafileObject>().canMoveAgain = false;
                        selectedObject.GetComponent<datafileObject>().SetMovementAxis("y");
                    }
                    break;

                case "Up":
                    if (selectedObject.GetComponent<datafileObject>().canMoveAgain == true)
                    {
                        selectedObject.GetComponent<datafileObject>().PreviousPosition();
                        selectedObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                        selectedObject.rigidbody.AddForce(Vector3.up * force);
                        selectedObject.GetComponent<datafileObject>().canMoveAgain = false;
                        selectedObject.GetComponent<datafileObject>().SetMovementAxis("y");
                    }
                    break;

                case "Right" :
                    if (selectedObject.GetComponent<datafileObject>().canMoveAgain == true)
                    {
                        selectedObject.GetComponent<datafileObject>().PreviousPosition();
                        selectedObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                        selectedObject.rigidbody.AddForce(Vector3.right * force);
                        selectedObject.GetComponent<datafileObject>().canMoveAgain = false;
                        selectedObject.GetComponent<datafileObject>().SetMovementAxis("x");
                    }
                    break;

                case "Left" :
                    if (selectedObject.GetComponent<datafileObject>().canMoveAgain == true)
                    {
                        selectedObject.GetComponent<datafileObject>().PreviousPosition();
                        selectedObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                        selectedObject.rigidbody.AddForce(Vector3.left * force);
                        selectedObject.GetComponent<datafileObject>().canMoveAgain = false;
                        selectedObject.GetComponent<datafileObject>().SetMovementAxis("x");
                    }
                    break;
            }
        }
    }

    
}
