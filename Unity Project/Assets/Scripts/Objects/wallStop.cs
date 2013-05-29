using UnityEngine;
using System.Collections;

public class wallStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " hit wall");
        collision.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        collision.gameObject.GetComponent<datafileObject>().canMoveAgain = true;
        collision.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
}
