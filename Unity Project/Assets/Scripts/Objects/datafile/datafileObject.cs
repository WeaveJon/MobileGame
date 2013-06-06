using UnityEngine;
using System.Collections;

public class datafileObject : MonoBehaviour 
{
    public bool canMoveAgain = true;
    public GameObject controlCenter;
    private Material objectMaterial;
    float orgPosX;
    float orgPosY;
    float pastPosx;
    float pastPosy;

	// Use this for initialization
	void Start () 
    {
        objectMaterial = this.GetComponent<MeshRenderer>().material;
        OpeningPostion();
	}
	
    private void OnMouseDown()
    {
        controlCenter.GetComponent<MeshRenderer>().material = objectMaterial;
        controlCenter.GetComponent<datafileCenter>().setObject(this.gameObject);
        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
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
}
