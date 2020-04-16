using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
	[Range(0,4)]
    public int slotID = 0;
    /* {
		get
		{
            return null;
        }
		set
		{
            GameObject.FindGameObjectWithTag("Player").GetComponent<Skills>().spells[slotID] = value;
        }
	} */
    /* { 
		get
		{
            return null;
        }
		set
		{
            GameObject.FindGameObjectWithTag("Player").GetComponent<Skills>().slots[slotID] = value;
        }
	} */

    public void OnDrop(PointerEventData eventData)
    {
        Skills player = GameObject.FindGameObjectWithTag("Player").GetComponent<Skills>();
        player.spells[slotID] = eventData.pointerDrag.gameObject.GetComponent<DragHandler>().spell;
        player.BarUpdate();
    }
}
