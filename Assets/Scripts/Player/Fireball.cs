using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem FireParticle;

    [SerializeField]
    private ParticleSystem ExplosionParticle;

    private void Start()
    {
        ExplosionParticle.Stop();
    }
    void OnTriggerEnter(Collider other)
    {
        ExplosionParticle.Play();
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0.5f);
    }
}
