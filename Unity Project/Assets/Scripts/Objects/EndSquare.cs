using UnityEngine;
using System.Collections;

public class EndSquare : MonoBehaviour 
{
    bool isInTrigger = false;
    float timer = .5f;
	
	// Update is called once per frame
	void Update () 
    {
        if (isInTrigger == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                EndLevel();
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
        timer = 2;
    }

    void EndLevel()
    {
        Debug.Log("Level Complete");
        Application.LoadLevel(0);
    }
}