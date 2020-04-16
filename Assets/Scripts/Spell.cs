using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Spellbook/Spell")]
public class Spell : ScriptableObject 
{
	public string SpellName;
	public Sprite icon;
	public int manaCost;
	public float cooldown;
	public float currentCooldown;

	public void Cast()
	{

	}
}
