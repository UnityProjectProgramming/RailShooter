using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] AudioClip splashClip;

    AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();       
        StartCoroutine(StartSplashMusic());
	}
	
    IEnumerator StartSplashMusic()
    {
        audioSource.PlayOneShot(splashClip);
        yield return new WaitForSeconds(3.0f);  //TODO parametarize
        SceneManager.LoadScene(1);
    }

	void Update ()
    {
		
	}
}
