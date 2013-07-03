using UnityEngine;
using System.Collections;

public class AudioSongController : MonoBehaviour 
{
    public AudioClip InGameMusic;
    public AudioClip TitleTheme;
	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this);
	}

    public void PlayTitleMusic()
    {
        this.transform.position = new Vector3(0, 1, -10);
        this.audio.volume = 1;
        this.audio.clip = TitleTheme;
        this.audio.Play();
    }

    public void PlayInGameMusic()
    {
        this.transform.position = new Vector3(33.57249f, 0, -50);
        this.audio.volume = .5f;
        this.audio.clip = InGameMusic;
        this.audio.Play();
    }
}