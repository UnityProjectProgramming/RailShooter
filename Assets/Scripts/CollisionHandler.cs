﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] float levelLoadDelay = 3.0f;

    SceneLoader sceneLoader;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
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
        yield return new WaitForEndOfFrame();
        StartCoroutine(sceneLoader.LoadLevelOne());
    }
}
