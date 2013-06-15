using UnityEngine;
using System.Collections;

public class datafileObject : MonoBehaviour 
{
    public bool canMoveAgain = true;
    public GameObject controlCenter;
    public Material objectMaterial;
    float orgPosX;
    float orgPosY;
    float pastPosx;
    float pastPosy;
    private string movementAxis;
	// Use this for initialization
	void Start () 
    {
        OpeningPostion();
	}
	
    private void OnMouseDown()
    {
        controlCenter.GetComponent<datafileCenter>().setObject(this.gameObject);
    }

    void OpeningPostion()
    {
        orgPosX = this.transform.position.x;
        orgPosY = this.transform.position.y;
    }

    public void ResetToOpeningPosition()
    {
        this.transform.position = new Vector3(orgPosX, orgPosY, 0);
    }

    public void ResetToPreviousPostion()
    {
        this.transform.position = new Vector3(pastPosx, pastPosy, 0);
    }

    public void PreviousPosition()
    {
        pastPosx = this.transform.position.x;
        pastPosy = this.transform.position.y;
    }

    public void SetMovementAxis(string axis)
    {
        movementAxis = axis;
    }

    public string GetMovementAxis()
    {
        return movementAxis;
    }

    public void Selected()
    {
        controlCenter.GetComponent<MeshRenderer>().material = objectMaterial;
        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}
