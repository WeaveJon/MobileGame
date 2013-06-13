using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour
{
    public GUISkin MenuSkin;
    float screenWidth;
    float screenHeight;
    byte buttonWidth = 200;
    byte height = 40;
    string menuState = "Default";
    private int selectionGridInt = 0;
    private string[] selectionStrings = { "Level 1", "Level 2", "Level 3", "Level 4" };

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width - 250;
    }

    void Update()
    {
        if (selectionGridInt != 0)
        {
           int level = selectionGridInt + 1;
           Application.LoadLevel(level);
        }
    }

    void OnGUI()
    {
        GUI.skin = MenuSkin;
        switch (menuState)
        {
            case "Default":
                if (GUI.Button(new Rect((Screen.width - 250), (screenHeight * .35f), buttonWidth, height), "Play"))
                {
                    menuState = "Play";
                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .45f), buttonWidth, height), "Options"))
                {

                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Credits"))
                {

                }
                break;

            case "Play":
                if (GUI.Button(new Rect((Screen.width - 250), (screenHeight * .35f), buttonWidth, height), "Tutorial"))
                {
                    Application.LoadLevel(1);
                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .45f), buttonWidth, height), "Select Level"))
                {
                    menuState = "Level Menu";
                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Back"))
                {
                    menuState = "Default";
                }
                break;

            case "Level Menu" :

                selectionGridInt = GUI.SelectionGrid(new Rect(25, 25, 300, 100), selectionGridInt, selectionStrings, 1);

                 if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Back"))
                {
                    menuState = "Default";
                }
                break;

            case "Options":
                 if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Back"))
                {
                    menuState = "Default";
                }
                break;

            case "Credits":
                 if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Back"))
                {
                    menuState = "Default";
                }
                
                break;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}