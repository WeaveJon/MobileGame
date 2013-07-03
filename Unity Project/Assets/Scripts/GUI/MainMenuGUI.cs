using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour
{
    public GUISkin MenuSkin;
    public GameObject AudioObject;
    float screenWidth;
    float screenHeight;
    byte buttonWidth = 250;
    byte height = 80;
    string menuState = "Default";
    private int selectionGridInt = -1;
    private string[] selectionStrings = { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5" };

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width - 300;
    }

    void Update()
    {
        if (selectionGridInt != -1)
        {
           int level = selectionGridInt + 2;
           GameObject MusicBox = GameObject.Find("ThemeSongDevice");
           MusicBox.GetComponent<AudioSongController>().PlayInGameMusic();
           Application.LoadLevel(level);
        }
    }

    void OnGUI()
    {
        GUI.skin = MenuSkin;
        GUIStyle Play = MenuSkin.customStyles[0];
        GUIStyle Options = MenuSkin.customStyles[1];
        GUIStyle Credits = MenuSkin.customStyles[2];
        switch (menuState)
        {
            case "Default":
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .25f), buttonWidth, height), "", Play))
                {
                    AudioObject.audio.Play();
                    menuState = "Play";
                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .45f), buttonWidth, height), "", Options))
                {
                    AudioObject.audio.Play();
                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .65f), buttonWidth, height), "", Credits))
                {
                    AudioObject.audio.Play();
                }
                break;

            case "Play":
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .25f), buttonWidth, height), "Tutorial"))
                {
                    AudioObject.audio.Play();
                    GameObject MusicBox = GameObject.Find("ThemeSongDevice");
                    MusicBox.GetComponent<AudioSongController>().PlayInGameMusic();
                    Application.LoadLevel(1);
                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .45f), buttonWidth, height), "Select Level"))
                {
                    AudioObject.audio.Play();
                    menuState = "Level Menu";
                }
                if (GUI.Button(new Rect((screenWidth), (screenHeight * .65f), buttonWidth, height), "Back"))
                {
                    AudioObject.audio.Play();
                    menuState = "Default";
                }
                break;

            case "Level Menu" :

                selectionGridInt = GUI.SelectionGrid(new Rect(25, 25, 300, 200), selectionGridInt, selectionStrings, 1);

                 if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Back"))
                 {
                    AudioObject.audio.Play();
                    menuState = "Default";
                }
                break;

            case "Options":
                 if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Back"))
                 {
                     AudioObject.audio.Play();
                    menuState = "Default";
                }
                break;

            case "Credits":
                 if (GUI.Button(new Rect((screenWidth), (screenHeight * .55f), buttonWidth, height), "Back"))
                 {
                     AudioObject.audio.Play();
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