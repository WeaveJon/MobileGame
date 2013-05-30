using UnityEngine;
using System.Collections;

public class datafileMoveUp : MonoBehaviour {

    public GameObject datafileParent;
    public float force = 100.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (datafileParent.GetComponent<datafileObject>().canMoveAgain == true)
        {
            Debug.Log("hit :" + this.name);
            datafileParent.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
            datafileParent.rigidbody.AddForce(Vector3.up * force);
            datafileParent.GetComponent<datafileObject>().canMoveAgain = false;
        }
    }
}