using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class lSpell : MonoBehaviour
{
    public Sprite icon;
    public float lifeTime;
    public float velocity;
    //public GameObject obj;
    public float cooldown;
    public float cooldownTimer;
    public bool casted = false;
    public bool learned = true;

    public void Cast(GameObject caster)
    {
        GameObject spell = Instantiate(gameObject, caster.transform.position, caster.transform.rotation);
        spell.GetComponent<Rigidbody>().velocity = caster.transform.TransformDirection(Vector3.forward * velocity);
        this.casted = true;
        this.cooldownTimer = this.cooldown;
        Destroy(spell, this.lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Terrain")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponentInChildren<ParticleSystem>().Stop();
        }
    }
}
