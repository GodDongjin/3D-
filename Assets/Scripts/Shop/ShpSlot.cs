using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShpSlot : MonoBehaviour
{
	public Item item;   //획득한 아이템
	public int itemCount;   //회득한 아이템의 개수
	public string itemName;
	public int itemGold;
	public Image itemImage; //아이템의 이미지

	[SerializeField]
	private Text text_count;
	[SerializeField]
	private Text text_name;
	[SerializeField]
	private Text text_glod;
	[SerializeField]
	private GameObject go_countImgae;
	[SerializeField]
	private GameObject go_nameImgae;
	[SerializeField]
	private GameObject go_glodImgae;
	[SerializeField]
	private GameObject go_countImage;

	[SerializeField]
	private Button button;

	private void Start()
	{
		button = this.gameObject.GetComponent<Button>();
		button.onClick.AddListener(OnClickButton);
	}
	// Update is called once per frame
	void Update()
	{

	}

	public void OnClickButton()
	{
		ClearSlot();
	}

	// Start is called before the first frame update
	private void SetColor(float _alpha)
	{
		Color color = itemImage.color;
		color.a = _alpha;
		itemImage.color = color;
	}

	public void AddItem(Item _item, int _count = 1)
	{
		//if(slotType == SlotType.Stuff)
		//      {
		item = _item;
		itemCount = _count;
		itemName = _item.itmeInfo.itemName;
		itemGold = _item.itmeInfo.itemBuyGold;


		Sprite[] sprites = Resources.LoadAll<Sprite>("item");
		for (int i = 0; i < sprites.Length; i++)
		{
			if (sprites[i].name == _item.itmeInfo.itemImageName)
			{
				itemImage.sprite = sprites[i];
				text_name.text = itemName;
				text_glod.text = itemGold.ToString();
				text_count.text = itemCount.ToString();
				go_nameImgae.SetActive(true);
				go_glodImgae.SetActive(true);
				go_countImage.SetActive(true);
				SetColor(1);
			}
			

		}
	}

	public void SetSlotCount(int _count)
	{
		itemCount += _count;
		text_count.text = itemCount.ToString();

		if (itemCount <= 0)
		{
			ClearSlot();
		}
	}

	public void ClearSlot()
	{
		item = null;
		itemCount = 0;
		itemImage.sprite = null;
		SetColor(0);

		text_count.text = "0";

		go_nameImgae.SetActive(false);
		go_glodImgae.SetActive(false);
		go_countImage.SetActive(false);
	}


}
