using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
{
	public float lookRadius = 10f;
	Transform target;
	NavMeshAgent agent;
	CharacterCombat combat;

	void Start () 
	{
		combat = GetComponent<CharacterCombat>();
		agent = GetComponent<NavMeshAgent>();
		target = PlayerManager.instance.player.transform;
	}
	
	void Update () 
	{
		float distance = Vector3.Distance(transform.position, target.position);
		if (distance <= lookRadius)
		{
			agent.SetDestination(target.position);
			gameObject.GetComponentInChildren<Animator>().Play("run");
			if(distance <= agent.stoppingDistance)
			{
				CharacterStats targetStats = target.GetComponent<CharacterStats>();
				if (targetStats != null)
				{
					combat.Attack(targetStats);
					//gameObject.GetComponentInChildren<Animator>().Play("jumpBite");
				}

				Vector3 direction = (target.position - transform.position).normalized;
				Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
				transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
			}
		}
	}
}
