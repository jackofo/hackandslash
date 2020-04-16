using UnityEngine;

public class tupa : MonoBehaviour 
{
	public GameObject prefab;
	public bool tak = false;
	void Start () 
	{
		
	}
	
	void Update () 
	{

		if(tak)
		{
			GameObject f = Instantiate(prefab, transform.position, transform.rotation);
			f.transform.Rotate(Vector3.left * 90);
			f.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
			tak = false;
		}
	}
}
