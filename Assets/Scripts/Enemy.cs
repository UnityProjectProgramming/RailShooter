using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Serlialized
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    //Private
    ScoreBoard scoreBoard;


    private void Start()
    {
        AddBoxCollider();

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }


    void AddBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, gameObject.transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        Destroy(fx, fx.GetComponent<ParticleSystem>().main.duration);
    }
}
