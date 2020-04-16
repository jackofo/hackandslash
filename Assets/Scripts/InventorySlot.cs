using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour 
{
	Image icon;
	Item item;

	private void Awake()
	{
		icon = transform.Find("Icon").GetComponent<Image>();
		icon.enabled = false;
	}

	public void AddItem(Item newItem)
	{
		item = newItem;
		icon.sprite = item.icon;
		icon.enabled = true;
	}

	public void ClearItem()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;
	}

	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}
}
