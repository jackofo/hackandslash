using UnityEngine;

public class SpellbookUI : MonoBehaviour
{
	public GameObject spellbookUI;

	void Start()
	{
		spellbookUI.SetActive(false);
	}

	void Update()
	{
		if (Input.GetButtonDown("Spellbook"))
		{
			spellbookUI.SetActive(!spellbookUI.activeSelf);
		}
	}
}