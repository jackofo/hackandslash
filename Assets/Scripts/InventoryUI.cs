using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	GraphicRaycaster m_Raycaster;			//===================================================//
	PointerEventData m_PointerEventData;	//# Objects used to check if mouse pointer is over UI #//
	EventSystem m_EventSystem;				//===================================================//

	public GameObject inventoryUI;
	public Transform itemsPanel;
	InventorySlot[] slots;

	private void Start()
	{
		m_Raycaster = GetComponent<GraphicRaycaster>(); // used for checking if mouse pointer is over UI
		m_EventSystem = GetComponent<EventSystem>();    // used for checking if mouse pointer is over UI

		Inventory.instance.onItemChangedCallback += RefreshUI;
		slots = itemsPanel.GetComponentsInChildren<InventorySlot>();
		inventoryUI.SetActive(false);
	}

	private void Update()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Nav>().uiBlock = IsPointerOverUI();	//Sending info to player navigation

		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}

	public void RefreshUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < Inventory.instance.items.Count)
			{
				slots[i].AddItem(Inventory.instance.items[i]);
			}
			else
			{
				slots[i].ClearItem();
			}
		}
	}

	public bool IsPointerOverUI()
	{
		m_PointerEventData = new PointerEventData(m_EventSystem);
		m_PointerEventData.position = Input.mousePosition;
		List<RaycastResult> results = new List<RaycastResult>();
		m_Raycaster.Raycast(m_PointerEventData, results);

		foreach (RaycastResult result in results)
			return true;

		return false;
	}
}
