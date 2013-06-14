using UnityEngine;
using System.Collections;

public class EndStageGUI : MonoBehaviour 
{
    bool isOn = false;
    public int loadLevel;

    public void Activate()
    {
        isOn = true;
    }

    void OnGUI()
    {
        if (isOn == true)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Label(new Rect((Screen.width/2) - 50, Screen.height*.35f, 100, 20), "Level Complete!");
            if (GUI.Button(new Rect((Screen.width/4)-100, (Screen.height * .45f), 200, 40), "Next Level"))
            {
                Application.LoadLevel(loadLevel);
            }
            if (GUI.Button(new Rect(((Screen.width / 4)*3) - 100, (Screen.height * .45f), 200, 40), "Main Menu"))
            {
                Application.LoadLevel(0);
            }
        }
    }
}
