using UnityEngine;
using System.Collections;

public class datafileMovementButton : MonoBehaviour 
{
    public GameObject datafileCenterControl;
    public string direction;

    private void OnMouseDown()
    {
        datafileCenterControl.GetComponent<datafileCenter>().MoveDataFile(direction);
    }
}