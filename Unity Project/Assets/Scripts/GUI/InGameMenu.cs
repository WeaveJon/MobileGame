using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour 
{
    public Texture stepBackButton;
    public Texture resetButton;
    public GameObject datafile;
    bool selectPiece = false;
    float timer = 3f;

    void Update()
    {

        if (selectPiece == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                selectPiece = false;
                timer = 3f;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), resetButton))
        {
            datafile.GetComponent<datafileObject>().ResetToOpeningPosition();
        }

        if (GUI.Button(new Rect(480, Screen.height - 100, 100, 100), stepBackButton))
        {
            datafile.GetComponent<datafileObject>().ResetToPreviousPostion();
        }

        if (selectPiece == true)
        {
            GUI.Box(new Rect(Screen.width - 250, Screen.height - 260, 200, 40), "Please Select a Datafile...");
        }

    }
    public void SelectAPiece()
    {
        selectPiece = true;
    }
}
