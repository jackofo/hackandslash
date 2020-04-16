﻿using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject  
{
	public string ItemName;
	public Sprite icon;

	public virtual void Use()
	{
	}
}
