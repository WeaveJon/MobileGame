using UnityEngine;
using System.Collections;

public class datafileObject : MonoBehaviour {

    public bool canMoveAgain = true;
    public GameObject controlCenter;
    private Material objectMaterial;

	// Use this for initialization
	void Start () 
    {
        objectMaterial = this.GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    private void OnMouseDown()
    {
        controlCenter.GetComponent<MeshRenderer>().material = objectMaterial;
        controlCenter.GetComponent<datafileCenter>().setObject(this.gameObject);
    }
}
