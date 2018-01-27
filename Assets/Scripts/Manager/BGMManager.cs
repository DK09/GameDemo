using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    private static BGMManager _instance;
    private AudioSource audioSource;
    public AudioClip[] clips;


    public static BGMManager Instance
    {
        get
        {
            return _instance;
        }
    }

	// Use this for initialization
	void Awake() {
        _instance = this;
        DontDestroyOnLoad(gameObject);
	}

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("BGMValue", 1);
    }

    public void SetValue(float f)
    {
        f = f > 0 ? f : 0;
        f = f < 1 ? f : 1;
        audioSource.volume = f;
    }

    public void ChangeBGM(int index)
    {
        if (audioSource.clip != clips[index])
        {
            audioSource.clip = clips[index];
            audioSource.PlayDelayed(1f);
        }
    }
}
