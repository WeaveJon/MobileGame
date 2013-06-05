using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour
{
    public GUISkin MenuSkin;
    float screenWidth;
    float screenHeight;
    byte buttonWidth = 100;
    byte height = 40;
    string menuState = "Default";

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    void OnGUI()
    {
        GUI.skin = MenuSkin;
        switch (menuState)
        {
            case "Default":
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .35f), buttonWidth, height), "Play"))
                {
                    menuState = "Play";
                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .45f), buttonWidth, height), "Options"))
                {

                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .55f), buttonWidth, height), "Credits"))
                {

                }
                break;

            case "Play":
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .35f), buttonWidth, height), "New Game"))
                {
                    Application.LoadLevel(1);
                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .45f), buttonWidth, height), "Select Level"))
                {

                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .55f), buttonWidth, height), "Back"))
                {
                    menuState = "Default";
                }
                break;

            case "Options":
                break;

            case "Credits":
                break;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}