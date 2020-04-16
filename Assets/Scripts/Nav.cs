using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Nav : MonoBehaviour 
{
	public bool uiBlock;
    Interactable focus;
    public LayerMask movementLM;
    Camera cam;
    NavMeshAgent agent;

    void Start () 
	{
		uiBlock = false;
        cam = Camera.main;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
	void Update ()
	{
		if (focus != null)
		{
			agent.SetDestination(focus.transform.position);
        }

		if (uiBlock)
			return;

		if (Input.GetMouseButton(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100, movementLM))
			{
				agent.SetDestination(hit.point);
				RemoveFocus();
			}
		}

		if (Input.GetMouseButtonUp(1))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			{
				Interactable interactable = hit.collider.GetComponent<Interactable>();
				if (interactable != null)
				{
					SetFocus(interactable);
				}
			}
		}
	}

    void SetFocus(Interactable newFocus)
    {
		if (newFocus != focus)
		{
			if (focus != null)
				focus.isFocused = false;

			focus = newFocus;
			agent.stoppingDistance = focus.radius;
		}

		focus.isFocused = true;
    }

    void RemoveFocus()
    {
		if (focus != null)
			focus.isFocused = false;

		focus = null;
		agent.stoppingDistance = 0f;
    }
	
}
