using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item 
{
	public EquipmentSlot equipSlot;
	public int armor;
	public int damage;

	public override void Use()
	{
		base.Use();
		EquipmentManager.instance.Equip(this);
		Inventory.instance.RemoveItem(this);
	}
}

public enum EquipmentSlot { Head, Chest, Feet, Weapon }