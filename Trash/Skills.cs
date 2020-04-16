using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour 
{
    public GameObject skillBar;
    public Image skillSlot;
    public List<Spell> spells;
    public List<Image> slots;


	void Update () 
	{
        SpellCast();
        Cooldowns();
    }

    public void BarUpdate()
    {
        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i] != null)
            {
                slots[i].transform.Find("Spell").GetComponent<Image>().sprite = spells[i].icon;
                slots[i].transform.Find("Spell").GetComponent<Image>().color = Color.white;
            }
        }
    }
    void Cooldowns()
    {
        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i] != null)
            {
                slots[i].GetComponentInChildren<Text>().text = System.Convert.ToInt32(spells[i].cooldownTimer).ToString();
                slots[i].transform.Find("Cooldown").GetComponent<Image>().fillAmount = spells[i].cooldownTimer / spells[i].cooldown;
                if (spells[i].cooldownTimer <= 0)
                {
                    spells[i].casted = false;
                    slots[i].GetComponentInChildren<Text>().text = "";
                    spells[i].cooldownTimer = 0;
                }
                else
                {
                    spells[i].cooldownTimer -= Time.deltaTime;
                }
            }
        }
    }

	void SpellCast()
    {
        int buttonNumber = -1;
        
        if(Input.GetKeyUp(KeyCode.Alpha1))
            buttonNumber = 0;
        else if (Input.GetKeyUp(KeyCode.Alpha2))
            buttonNumber = 1;
        else if (Input.GetKeyUp(KeyCode.Alpha3))
            buttonNumber = 2;
        else if (Input.GetKeyUp(KeyCode.Alpha4))
            buttonNumber = 3;
        else if (Input.GetKeyUp(KeyCode.Alpha5))
            buttonNumber = 4;

        if (buttonNumber > -1 && spells[buttonNumber] != null && spells[buttonNumber].casted == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                Vector3 direction = hit.point - transform.position;
                direction.y = 0;
                direction.Normalize();
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
            }

            spells[buttonNumber].Cast(gameObject);
            buttonNumber = -1;
        }
    }
}