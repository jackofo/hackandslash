using UnityEngine;

public class MinimapController : MonoBehaviour 
{
	Transform player;
	public Vector3 offset;

	private void Start()
	{
		player = PlayerManager.instance.player.transform;
	}

	void LateUpdate()
	{
		transform.position = player.position + offset;
	}
}
