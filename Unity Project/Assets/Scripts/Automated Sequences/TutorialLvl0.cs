using UnityEngine;
using System.Collections;

public class TutorialLvl0 : MonoBehaviour
{
    public GameObject datafile;
    public GameObject endTrigger;
    public GameObject center;
    public Texture stepBackButton;
    public Texture resetButton;
    float timer = 6f;
    byte case1 = 0;
    bool timerOn = true;
    byte state = 0;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                state++;
                if (state == 6)
                {
                    Application.LoadLevel(0);
                }
            }
        }
    }

    void OnGUI()
    {
        switch (state)
        {
            case 0:

                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
                GUI.Label(new Rect(20, 30, 400, 20), "Welcome to the Tutorial Level");
                GUI.Label(new Rect(20, 50, 400, 20), "Here we will teach the controls and basic objective.");
                GUI.Label(new Rect(20, 70, 400, 20), "First you must select the datafile you wish to move,");
                GUI.Label(new Rect(20, 90, 400, 20), "than push the arrow you wish to move it, like this!");

                if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), resetButton))
                {

                }

                if (GUI.Button(new Rect(480, Screen.height - 100, 100, 100), stepBackButton))
                {

                }

                break;


            case 1:
                if (case1 == 0)
                {
                    StartCoroutine("MoveLeft");
                    case1++;
                }
                if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), resetButton))
                {

                }

                if (GUI.Button(new Rect(480, Screen.height - 100, 100, 100), stepBackButton))
                {

                }
                break;

            case 2:
                timerOn = true;
                GUI.Box(new Rect(0, 0, 480, Screen.height), "");
                GUI.Label(new Rect(20, 30, 400, 20), "Reseting the Level");
                GUI.Label(new Rect(20, 50, 400, 20), "Sometimes you will get stuck and will need to restart the puzzle.");
                GUI.Label(new Rect(20, 70, 400, 20), "At those times you may use the 'reset' button to start over!");

                if (Time.time % 2 < 1)
                {
                    if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), resetButton))
                    {
                    }
                }

                if (GUI.Button(new Rect(480, Screen.height - 100, 100, 100), stepBackButton))
                {

                }

                if (case1 == 1)
                {
                    StartCoroutine("ResetData");
                    case1++;
                }

                break;

            case 3:
                GUI.Box(new Rect(0, 0, 480, Screen.height), "");
                GUI.Label(new Rect(20, 30, 400, 20), "Stepping Back");
                GUI.Label(new Rect(20, 50, 400, 20), "Sometimes you may want to try a move but not like the results.");
                GUI.Label(new Rect(20, 70, 400, 20), "At those times you may use the 'undo-move' button to move the last");
                GUI.Label(new Rect(20, 90, 400, 20), "datafile back to it's previous position!");

                if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), resetButton))
                {

                }

                if (Time.time % 2 < 1)
                {
                    if (GUI.Button(new Rect(480, Screen.height - 100, 100, 100), stepBackButton))
                    {
                    }
                }
                if (case1 == 2)
                {
                    StartCoroutine("BadMove");
                    case1++;
                }

                break;

            case 4:
                GUI.Box(new Rect(0, 0, 480, Screen.height), "");
                GUI.Label(new Rect(20, 30, 400, 20), "End Goal");
                GUI.Label(new Rect(20, 50, 400, 20), "The Goal is to move the datafile to the highlighted square.");

                 if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), resetButton))
                {

                }

                if (GUI.Button(new Rect(480, Screen.height - 100, 100, 100), stepBackButton))
                {

                }

                if (case1 == 3)
                {
                    StartCoroutine("FinalMove");
                    case1++;
                }

                break;

            case 5:
                timer = 60;
                GUI.Box(new Rect(0, 0, 480, Screen.height), "");
                GUI.Label(new Rect(20, 30, 400, 20), "Replay");
                GUI.Label(new Rect(20, 50, 400, 20), "To replay the tutorial hit the 'Reset' button.");
                GUI.Label(new Rect(20, 70, 400, 20), "To return to the menu hit the undo button.");

                 if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), resetButton))
                {
                    state = 0;
                    case1 = 0;
                    timer = 6f;
                    datafile.GetComponent<datafileObject>().ResetToPreviousPostion();
                }

                if (GUI.Button(new Rect(480, Screen.height - 100, 100, 100), stepBackButton))
                {
                    Application.LoadLevel(0);
                }
                break;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    IEnumerator MoveLeft()
    {
        timer = 8.5f;
        center.GetComponent<datafileCenter>().setObject(datafile);
        center.GetComponent<MeshRenderer>().material = datafile.GetComponent<MeshRenderer>().material;
        yield return new WaitForSeconds(2.5f);
        center.GetComponent<datafileCenter>().MoveDataFile("Left");
        yield return new WaitForSeconds(3f);
        center.GetComponent<datafileCenter>().MoveDataFile("Right");
        yield return new WaitForSeconds(3f);
    }

    IEnumerator ResetData()
    {
        timer = 6.5f;
        yield return new WaitForSeconds(5f);
        datafile.GetComponent<datafileObject>().ResetToOpeningPosition();
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator BadMove()
    {
        timer = 6.5f;
        yield return new WaitForSeconds(1.5f);
        center.GetComponent<datafileCenter>().MoveDataFile("Up");
        yield return new WaitForSeconds(2.5f);
        datafile.GetComponent<datafileObject>().ResetToPreviousPostion();
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator FinalMove()
    {
        timer = 6.5f;
        endTrigger.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(2.5f);
        center.GetComponent<datafileCenter>().MoveDataFile("Down");
    }
}
