using UnityEngine;
using System.Collections;

public class wallStop : MonoBehaviour
{
    Collision collisionObject;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " hit wall");
        collision.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        collision.gameObject.rigidbody.velocity = new Vector3(0, 0, 0) * 0;
        collision.gameObject.rigidbody.drag = 20;
        collision.gameObject.GetComponent<datafileObject>().canMoveAgain = true;
        collision.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        collisionObject = collision;
        StartCoroutine("DragRest");
    }
    IEnumerator DragRest()
    {
        yield return new WaitForSeconds(.1f);
        collisionObject.gameObject.rigidbody.drag = 0;
    }
}
