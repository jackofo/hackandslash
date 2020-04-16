using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour 
{
	CharacterStats stats;
	public float attackSpeed = 1f;
	public float attackCooldown = 0f;

	private void Start()
	{
		stats = GetComponent<CharacterStats>();
	}

	private void Update()
	{
		attackCooldown -= Time.deltaTime;
	}

	public void Attack(CharacterStats targetStats)
	{
		if (attackCooldown <= 0)
		{
			targetStats.TakeDamage(stats.damage.GetValue());
			attackCooldown = 1f / attackSpeed;
		}
	}
}
