using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Spell spell;
    GameObject canvas;
    GameObject inst;
	public void OnBeginDrag(PointerEventData eventData)
    {
        canvas = GameObject.Find("Canvas");
        inst = Instantiate(gameObject, transform.position, Quaternion.identity, canvas.transform);
        inst.GetComponent<RectTransform>().sizeDelta = new Vector2(27.76f, 27.76f);
        inst.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (inst != null)
        {
            inst.transform.position = eventData.position;
        }
    }

	public void OnEndDrag(PointerEventData eventData)
    {	
        Destroy(inst);
    }
}
