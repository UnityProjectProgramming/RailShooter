using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour {

    [SerializeField] AudioClip splashClip;

    AudioSource audioSource;
    SceneLoader sceneLoader;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(splashClip);
        StartCoroutine(sceneLoader.StartSplashMusic());
	}
	
}
