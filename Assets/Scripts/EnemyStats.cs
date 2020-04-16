using UnityEngine;

public class EnemyStats : CharacterStats
{
	public int experience;
	public override void Die()
	{
		base.Die();
		gameObject.GetComponentInChildren<Animator>().Play("death");
		PlayerManager.instance.player.GetComponent<PlayerStats>().experience.GainExp(experience);
		Destroy(gameObject);
	}
}
