using UnityEngine;

[CreateAssetMenu(fileName = "SpellInv", menuName = "Inventory/SpellInv")]
public class SpellInv : Item
{
	public GameObject prefab;
	public int damage = 5;
	public float speed = 1.25f;

	public override void Use()
	{
		base.Use();
		GameObject f = Instantiate(prefab, PlayerManager.instance.player.transform.position, PlayerManager.instance.player.transform.rotation);
		f.transform.position += new Vector3(0, 2, 0);
		f.transform.Rotate(Vector3.left * 90);
		f.GetComponent<Rigidbody>().AddForce(PlayerManager.instance.player.transform.forward * speed);
		Destroy(f, 10);
	}
}
