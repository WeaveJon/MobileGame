using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour 
{
    public Texture stepBackButton;
    public Texture resetButton;
    public GameObject datafile;
    public GameObject audioObject;
    bool selectPiece = false;
    bool pauseMenu = false;
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
            pauseMenu = true;
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

        if (pauseMenu == true)
        {
            Time.timeScale = 0;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            if (GUI.Button(new Rect((Screen.width / 4) - 100, (Screen.height * .45f), 200, 40), "Unpause"))
            {
                pauseMenu = false;
                Time.timeScale = 1.0f;
            }
            if (GUI.Button(new Rect(((Screen.width / 4) * 3) - 100, (Screen.height * .45f), 200, 40), "Main Menu"))
            {
                Application.LoadLevel(0);
            }
        }

    }
    public void SelectAPiece()
    {
        selectPiece = true;
    }
}
