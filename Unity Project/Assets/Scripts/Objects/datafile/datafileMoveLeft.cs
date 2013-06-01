using UnityEngine;
using System.Collections;

public class datafileMoveLeft : MonoBehaviour
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
                datafileParent.rigidbody.constraints = RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                datafileParent.rigidbody.AddForce(Vector3.left * force);
                datafileParent.GetComponent<datafileObject>().canMoveAgain = false;
            }
        }
        else
        {
            Debug.Log("Please select a data file");
        }
    }
}