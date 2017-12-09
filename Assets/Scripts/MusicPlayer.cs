using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour {

    [SerializeField] AudioClip splashClip;

    AudioSource audioSource;
    SceneLoader sceneLoader;
    //Using Singlton pattern
    private void Awake()
    {
        var musicPlayers = FindObjectsOfType<MusicPlayer>();
        if(musicPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start ()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(splashClip);
        StartCoroutine(sceneLoader.LoadLevelOne());
	}
	
}
