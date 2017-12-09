using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    private void Awake()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Collision with Enemies");
        GameObject fx =  Instantiate(deathFX, gameObject.transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        Destroy(fx, fx.GetComponent<ParticleSystem>().main.duration);
    }
}
