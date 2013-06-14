using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour 
{
    public AudioClip moveSFX;
    public AudioClip endSFX;
	// Use this for initialization
    public void MovementSFX()
    {
       this.audio.clip = moveSFX;
       this.audio.Play();
    }

    public void EndLevelSFX()
    {
        this.audio.clip = endSFX;
        this.audio.Play();
    }

}
