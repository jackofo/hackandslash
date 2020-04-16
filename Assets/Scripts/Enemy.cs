using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable 
{
	PlayerManager playerManager;
	CharacterStats stats;

	private void Start()
	{
		stats = GetComponent<CharacterStats>();
		playerManager = PlayerManager.instance;
	}

	public override void Interact()
	{
		base.Interact();
		CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

		if (playerCombat != null)
		{
			playerCombat.Attack(stats);
		}
	}
	private void OnMouseOver()
	{
		UIManager.instance.enemyName.text = name;
		UIManager.instance.enemyHPBar.fillAmount = (float)GetComponent<EnemyStats>().currentHealth / (float)GetComponent<EnemyStats>().maxHealth;
		UIManager.instance.enemyHPBar.enabled = true;
		UIManager.instance.enemyName.enabled = true;
	}

	private void OnMouseExit()
	{
		UIManager.instance.enemyName.text = null;
		UIManager.instance.enemyHPBar.fillAmount = 0;
		UIManager.instance.enemyHPBar.enabled = false;
		UIManager.instance.enemyName.enabled = false;
	}
	private void OnDestroy()
	{
		UIManager.instance.targetDestroyed = true;
	}
}
