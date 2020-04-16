using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public static UIManager instance;
	public RectTransform canvas;
	public RectTransform itemName;
	public RectTransform bottomActionBar;
	public Image hPBar;
	public Image mPBar;
	public Text enemyName;
	public Image enemyHPBar;
	//public Interactable target;
	public bool targetDestroyed;
	public bool itemPickedUp;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		targetDestroyed = false;
		itemPickedUp = false;
		itemName.gameObject.SetActive(false);
		enemyName.text = null;
		enemyHPBar.fillAmount = 0;
		enemyHPBar.enabled = false;
		enemyName.enabled = false;
	}

	private void Update()
	{
		if (targetDestroyed)
		{
			enemyName.text = null;
			enemyHPBar.fillAmount = 0;
			enemyHPBar.enabled = false;
			enemyName.enabled = false;
			targetDestroyed = false;
		}
		if(itemPickedUp)
		{
			itemName.gameObject.SetActive(false);
			itemPickedUp = false;
		}
	}


}
