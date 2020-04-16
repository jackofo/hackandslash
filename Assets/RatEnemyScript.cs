using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatEnemyScript : MonoBehaviour 
{
    public bool targetingPlayer;
    Animator anim;
    public float distance;
    GameObject player;
    NavMeshAgent agent;

    void Start ()
    {
        targetingPlayer = false;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
	
	void Update ()
    {
        //anim.SetBool("atac", targetingPlayer);
        if(Vector3.Distance(player.transform.position, transform.position) <= distance)
		{
            targetingPlayer = true;
            anim.SetFloat("movement", agent.remainingDistance - agent.stoppingDistance);
            agent.SetDestination(player.transform.position);
        }
		else
		{
            targetingPlayer = false;
        }
		/* if((int)(anim.GetCurrentAnimatorClipInfo(0).weight * (animationClip[0].clip.length * animationClip[0].clip.frameRate));)
		{
            Debug.Log("adsadasdasdas");
        } */

    }
}
