using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
	RectTransform ui;
	RectTransform uiInst;
	public Vector3 itemNameOffset;
	public Item item;
	private void Start()
	{
		ui = UIManager.instance.itemName;
	}

	public override void Interact()
	{
		if (Inventory.instance.AddItem(item))
			Destroy(gameObject);
	}

	private void OnMouseOver()
	{
		ui.GetComponent<Text>().text = name;
		ui.position = Camera.main.WorldToScreenPoint(transform.position + itemNameOffset);
		ui.gameObject.SetActive(true);
	}

	private void OnMouseExit()
	{
		ui.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		UIManager.instance.itemPickedUp = true;
	}
}