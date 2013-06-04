using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour
{
    public GUISkin MenuSkin;
    float screenWidth;
    float screenHeight;
    byte buttonWidth = 100;
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
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .35f), buttonWidth, 20), "Play"))
                {
                    menuState = "Play";
                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .40f), buttonWidth, 20), "Options"))
                {

                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .45f), buttonWidth, 20), "Credits"))
                {

                }
                break;

            case "Play":
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .35f), buttonWidth, 20), "New Game"))
                {

                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .40f), buttonWidth, 20), "Select Level"))
                {

                }
                if (GUI.Button(new Rect((screenWidth * .45f), (screenHeight * .45f), buttonWidth, 20), "Back"))
                {
                    menuState = "Default";
                }
                break;

            case "Options":
                break;

            case "Credits":
                break;
        }
    }
}