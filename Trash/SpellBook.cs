using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour 
{
    public GameObject scrollViewContent;
    public Image slot;
    public GameObject scrollView;
    public List<Spell> spells;

    void Start ()
    {
        SpellsUpdate();
		
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
            Time.timeScale = scrollView.active == true ? 1 : 0;
            scrollView.SetActive(!scrollView.active);
        }
	}

    void SpellsUpdate()
    {
        slot.enabled = true;
        for (int i = 0; i < spells.Count; i++)
        {
            Image spell = Instantiate(slot, slot.rectTransform.position, Quaternion.identity, scrollViewContent.transform);
            spell.sprite = spells[i].icon;
            spell.GetComponent<DragHandler>().spell = spells[i];
        }
        slot.enabled = false;
        scrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollViewContent.GetComponent<RectTransform>().sizeDelta.x, 8 * spells.Count);
    }
}
