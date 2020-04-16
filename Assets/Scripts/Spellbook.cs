using UnityEngine;

public class Spellbook : MonoBehaviour
{
	public static Spellbook instance;

	private void Start()
	{
		instance = this;
	}
}
