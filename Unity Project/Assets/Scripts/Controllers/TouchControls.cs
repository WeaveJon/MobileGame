using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour 
{
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    Vector2 deltaPositionStart;
    Vector2 deltaPositionEnd;
    bool startTouch;
    bool endTouch;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            deltaPositionStart = Input.GetTouch(0).deltaPosition;
            startTouch = true;
            /*
            if (touchDeltaPosition.x > 0)
            {
                left.GetComponent<datafileMovementButton>().MovePiece();
            }*/

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            deltaPositionEnd = Input.GetTouch(0).deltaPosition;
            endTouch = true;
        }

        if (startTouch == true && endTouch == true)
        {
            CalculateDirection();
        }
	
	}

    void CalculateDirection()
    {
       

        float x = deltaPositionEnd.x - deltaPositionStart.x;
        float y = deltaPositionEnd.y - deltaPositionStart.y;
        if (x > y)
        {
            if (deltaPositionStart.x > deltaPositionEnd.x)
            {
                left.GetComponent<datafileMovementButton>().MovePiece();
            }

            else if(deltaPositionEnd.x > deltaPositionStart.x)
            {
                right.GetComponent<datafileMovementButton>().MovePiece();
            }

        }
        else if (y > x)
        {
            if (deltaPositionStart.y > deltaPositionEnd.y)
            {
                down.GetComponent<datafileMovementButton>().MovePiece();
            }

            else if (deltaPositionEnd.y > deltaPositionStart.y)
            {
                up.GetComponent<datafileMovementButton>().MovePiece();
            }
        }
        startTouch = false;
        endTouch = false;
    }
}