using UnityEngine;

public class Interactable : MonoBehaviour 
{
	public float radius = 12f;
	//[HideInInspector]
	public bool isFocused = false;
	bool isInteracted = false;
	Transform player;

	public virtual void Interact()
	{
	}
	
	private void Start() 
	{	
	}

	void Update () 
	{
		if (isFocused && !isInteracted)
		{
			player = PlayerManager.instance.player.transform;
			float distance = Vector3.Distance(transform.position, player.position);
			
			if (distance <= radius)
			{
				Interact();
				isInteracted = true;
				isFocused = false;
			}
		}
		else
		{
			isInteracted = false;
		}
	}
}
