using UnityEngine;
using System.Collections;

public class datafileMovementController : MonoBehaviour 
{
    public string stopAxis = "y";
    public GameObject preventMovingDirection;
    private Vector3 position;
    
    void Start()
    {
        position = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, 0);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (stopAxis == collision.GetComponent<datafileObject>().GetMovementAxis())
        {
            
            collision.gameObject.rigidbody.velocity = new Vector3(0, 0, 0) * 0;
            LeanTween.moveLocal(collision.gameObject, position, .5f);
            collision.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            collision.gameObject.GetComponent<datafileObject>().canMoveAgain = true;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        preventMovingDirection.GetComponent<Renderer>().enabled = false;
        preventMovingDirection.GetComponent<Collider>().enabled = false;
    }

    void OnTriggerExit(Collider collision)
    {
        preventMovingDirection.GetComponent<Renderer>().enabled = true;
        preventMovingDirection.GetComponent<Collider>().enabled = true;
    }
}
