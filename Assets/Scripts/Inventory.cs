using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	public static Inventory instance;
	public int space;
	public List<Item> items = new List<Item>();

	public delegate void onItemChanged();
	public onItemChanged onItemChangedCallback;

	private void Awake()
	{
		instance = this;
	}

	public bool AddItem(Item item)
	{
		if (items.Count < space)
		{
			items.Add(item);
			onItemChangedCallback();
			return true;
		}
		return false;

	}
	public void RemoveItem(Item item)
	{
		items.Remove(item);
		onItemChangedCallback();
	}
}
