using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : Spell 
{
    public new void Cast(GameObject caster)
    {
        GameObject spell = Instantiate(gameObject, caster.transform.position, caster.transform.rotation);
        spell.GetComponent<Rigidbody>().velocity = caster.transform.TransformDirection(Vector3.forward * velocity);
        casted = true;
        cooldownTimer = cooldown;
        Destroy(spell, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Terrain")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<ParticleSystem>().Stop();
            GetComponentInChildren<Light>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Stop();
        }
    }
}