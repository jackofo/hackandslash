using UnityEngine;

public class PlayerStats : CharacterStats
{
	public Experience experience;
	public override void Die()
	{
		base.Die();
	}

	void Start () 
	{
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	public void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			armor.AddModifier(newItem.armor);
			damage.AddModifier(newItem.damage);
		}

		if (oldItem != null)
		{
			armor.RemoveModifier(oldItem.armor);
			damage.RemoveModifier(oldItem.damage);
		}
	}
}
