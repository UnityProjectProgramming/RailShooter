using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] float levelLoadDelay = 3.0f;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        StartCoroutine(DieAndLoadScene());
    }

    IEnumerator DieAndLoadScene()
    {
        deathFX.SetActive(true);
        yield return new WaitForSeconds(levelLoadDelay);
        SceneManager.LoadScene(1);
    }
}
