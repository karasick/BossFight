using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem FireParticle;

    [SerializeField]
    private ParticleSystem ExplosionParticle;

    private bool IsInCollision = false;

    private float FireballSpeed = 10;
    private float FireballTime = 3;

    private void Start()
    {
        ExplosionParticle.Stop();
        Destroy(gameObject, FireballTime);
    }

    void OnTriggerEnter(Collider other)
    {
        IsInCollision = true;
        FireballSpeed = 1;

        ExplosionParticle.Play();
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0.5f);
        int onHitTime = 1;
        Destroy(gameObject, onHitTime);
    }

    private void Update()
    {
        transform.position += transform.forward * (FireballSpeed * Time.deltaTime);
    }
}
