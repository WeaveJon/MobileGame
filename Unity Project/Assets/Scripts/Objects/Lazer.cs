using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour 
{
    public float duration;
    public float endX;
    public float endY;
    private float startX;
    private float startY;

	void Start () 
    {
        Time.timeScale = 1.0f;

        Debug.Log(this.name + "Fired");
        
        startX = this.transform.position.x;
        startY = this.transform.position.y;

        StartCoroutine("ShootLeft");
	}

    IEnumerator ShootLeft()
    {
        LeanTween.move(this.gameObject, new Vector3(endX, endY, 0), duration);
        yield return new WaitForSeconds(duration);
        StartCoroutine("ShootRight");
    }

    IEnumerator ShootRight()
    {
        LeanTween.move(this.gameObject, new Vector3(startX, startY, 0), duration);
        yield return new WaitForSeconds(duration);
        StartCoroutine("ShootLeft");
    }
}