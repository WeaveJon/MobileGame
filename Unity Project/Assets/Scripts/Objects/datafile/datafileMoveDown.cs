using UnityEngine;
using System.Collections;

public class datafileMoveDown : MonoBehaviour 
{
    public GameObject datafileParent;
    public float force = 100.0f;

    private void OnMouseDown()
    {
        if (datafileParent != null)
        {
            if (datafileParent.GetComponent<datafileObject>().canMoveAgain == true)
            {
                Debug.Log("hit :" + this.name);
                datafileParent.GetComponent<datafileObject>().PreviousPosition();
                datafileParent.rigidbody.constraints = RigidbodyConstraints.FreezePositionX| RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                datafileParent.rigidbody.AddForce(Vector3.down * force);
                datafileParent.GetComponent<datafileObject>().canMoveAgain = false;
            }
        }
        else
        {
            Debug.Log("Please select a data file");
            GameObject mainCamera = GameObject.Find("Main Camera");
            mainCamera.GetComponent<InGameMenu>().SelectAPiece();
        }
    }
}