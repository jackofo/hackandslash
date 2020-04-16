using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public Stat strength;	
	public Stat agility;
	public Stat inteligence;
	public int maxHealth = 100;
	public int currentHealth { get; private set; }
	public Stat damage;
	public Stat armor;

	void Awake()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(int damage)
	{
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);
		currentHealth -= damage;
		if(currentHealth <= 0)
		{
			Die();	
		}
	}

	public virtual void Die()
	{
		Debug.Log("died");
	}
}
