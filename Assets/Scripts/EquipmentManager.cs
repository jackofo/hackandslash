using UnityEngine;

public class EquipmentManager : MonoBehaviour 
{
	public static EquipmentManager instance;
	public Equipment[] equipment;

	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;

	void Awake () 
	{
		instance = this;
	}
	
	void Start () 
	{
		int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		equipment = new Equipment[numberOfSlots];

	}

	public void Equip(Equipment newItem)
	{
		int slotIndex = (int)newItem.equipSlot;
		Equipment oldItem = null;

		if(equipment[slotIndex] != null)
		{
			oldItem = equipment[slotIndex];
			Inventory.instance.AddItem(oldItem);

		}

		if (onEquipmentChanged != null)
		{
			onEquipmentChanged.Invoke(newItem, oldItem);
		}

		equipment[slotIndex] = newItem;
	}

	public void Unequip(int slotIndex)
	{
		if(equipment[slotIndex] != null)
		{
			Equipment item = equipment[slotIndex];
			Inventory.instance.AddItem(item);
			equipment[slotIndex] = null;

			if (onEquipmentChanged != null)
			{
				onEquipmentChanged(null, item);
			}
		}

	}
}
