using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SlotType
{
	HeadArmor,
	ShoulderArmor,
	PantsArmor,
	TopArmor,
	GlovesArmor,
	ShoesArmor,
	Stuff
}

public class ItemSlot : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	[SerializeField]
	private Item item = new Item();   //획득한 아이템
	public float imteId;
	public string itemName;
	public string itemType;
	public int itemCount;   //회득한 아이템의 개수
	public Image itemImage; //아이템의 이미지

	public Camera uiCamera;

	public SlotType slotType;
	public string slotTypeName;

	[SerializeField]
	private Text text_count;
	[SerializeField]
	private GameObject go_countImgae;

	[SerializeField]
	private Button button;

	[SerializeField]
	private InventoryUI InventoryUI;
	[SerializeField]
	private Shop shopUI;
	[SerializeField]
	PlayerInfo player;


	public bool isCilck;


	private void Start()
	{
		//uiCamera = GameObject.Find("UiCamera").GetComponent<Camera>();
		player = GameObject.Find("Player").GetComponent<PlayerInfo>();

	}

	private void Update()
	{

		if (isCilck)
		{
			if (item != null)
			{
				if (item.itmeInfo.itemType == "Stuff")
				{
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						if (InventoryUI.equipmentInventoryBase.activeSelf == true)
						{

							InventoryUI.SlotCheck(this, 0, itemCount);

						}
					}
					else if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						if (InventoryUI.equipmentInventoryBase.activeSelf == true)
						{

							InventoryUI.SlotCheck(this, 1, itemCount);

						}
					}
				}
				if (item.itmeInfo.itemType != "Stuff")
				{
					if (InventoryUI.equipmentInventoryBase.activeSelf == true)
					{
						InventoryUI.SlotCheck(this);
						isCilck = false;
						return;

					}
					else if (shopUI.shopBase.activeSelf == true)
					{
						player.UseGold(-item.itmeInfo.itemSellGold);
						SetSlotCount(-1);


					}

				}
			}

		}

		//if(item.itmeInfo.itemId == 0)
		//{
		//	item.itmeInfo.itemImageName = null;
		//	item.itmeInfo.itemName = null;
		//	item.itmeInfo.itemBuyGold = 0;
		//	item.itmeInfo.itemType = null;
		//	item.itmeInfo.itemValue = 0;
		//	item.itmeInfo.itemSellGold = 0;
		//}

	}

	public Item GetItem()
	{
		return item;
	}
	public void SetItem(Item _item, int count = 1)
	{
		item = _item;
		itemCount = count;

		Sprite[] sprites = Resources.LoadAll<Sprite>("item");
		for (int i = 0; i < sprites.Length; i++)
		{
			if (sprites[i].name == _item.itmeInfo.itemImageName)
			{
				itemImage.sprite = sprites[i];
				SetColor(1);

			}
			if (item.itmeInfo.itemType == "Stuff")
			{
				go_countImgae.SetActive(true);
				text_count.text = itemCount.ToString();
			}
			

		}
	}

	// 이미지의 투명도 조절
	private void SetColor(float _alpha)
	{
		Color color = itemImage.color;
		color.a = _alpha;
		itemImage.color = color;
	}

	//아이템 획득
	public void AddItem(Item _item, int _count = 1)
	{
		//if(slotType == SlotType.Stuff)
		//      {

		item.itmeInfo.itemId = _item.itmeInfo.itemId;
		item.itmeInfo.itemImageName = _item.itmeInfo.itemImageName;
		item.itmeInfo.itemName = _item.itmeInfo.itemName;
		item.itmeInfo.itemType = _item.itmeInfo.itemType;
		item.itmeInfo.itemValue = _item.itmeInfo.itemValue;
		item.itmeInfo.itemBuyGold = _item.itmeInfo.itemBuyGold;
		itemCount = _count;
		itemName = _item.itmeInfo.itemName;
		itemType = _item.itmeInfo.itemType;

		Sprite[] sprites = Resources.LoadAll<Sprite>("item");
		for (int i = 0; i < sprites.Length; i++)
		{
			if (sprites[i].name == _item.itmeInfo.itemImageName)
			{
				itemImage.sprite = sprites[i];
				SetColor(1);

			}
			if (item.itmeInfo.itemType == "Stuff")
			{
				go_countImgae.SetActive(true);
				text_count.text = itemCount.ToString();

				//	SetColor(1);
			}
			//}
			//else
			//{
			//	text_count.text = "0";
			//	go_countImgae.SetActive(false);
			//	SetColor(1);
			//}

		}
	}
	//item = _item;
	//if (slotType.ToString() == item.itmeInfo.itemType)
	//{
	//	Sprite[] sprites = Resources.LoadAll<Sprite>("item");
	//	for (int i = 0; i < sprites.Length; i++)
	//	{
	//		if (sprites[i].name == _item.itmeInfo.itemImageName)
	//		{
	//			itemImage.sprite = sprites[i];
	//			SetColor(1);
	//		}

	//	}
	//	text_count.text = "0";
	//	go_countImgae.SetActive(false);
	//}
	//if (item.itmeInfo.itemType == "Stuff")
	//{
	//	go_countImgae.SetActive(true);
	//	text_count.text = itemCount.ToString();
	//	SetColor(1);

	//}
	//else
	//{
	//	text_count.text = "0";
	//	go_countImgae.SetActive(false);
	//	SetColor(1);
	//}
	//}

	//else if(slotType != SlotType.Stuff)
	//      {

	//}


	//아이템 개수 조정
	public void SetSlotCount(int _count)
	{
		itemCount += _count;
		text_count.text = itemCount.ToString();

		if (itemCount <= 0)
		{
			ClearSlot();
		}
	}

	//슬롯 초기화
	public void ClearSlot()
	{
		item = null;
		itemCount = 0;
		itemImage.sprite = null;
		SetColor(0);

		text_count.text = "0";
		go_countImgae.SetActive(false);
	}

	public void OnPointerUp(PointerEventData eventData)
	{

		isCilck = false;


	}
	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			isCilck = true;
		}
	}
	public void PlayerInfoUpdate(Item item, float value)
	{
		if (item.itmeInfo.itemType == "HeadArmor")
		{
			player.ItemMpUp(value);
		}
		if (item.itmeInfo.itemType == "ShoulderArmor")
		{
			player.ItemDamegeUp(value);
		}
		if (item.itmeInfo.itemType == "TopArmor")
		{
			player.ItemHpUp(value);
		}
		if (item.itmeInfo.itemType == "GlovesArmor")
		{
			player.ItemDamegeUp(value);
		}
		if (item.itmeInfo.itemType == "PantsArmor")
		{
			player.ItemHpUp(value);
		}
		if (item.itmeInfo.itemType == "ShoesArmor")
		{
			player.ItemMoveSpeedUp(value);
		}


	}

	//public void SlotCheck(int index = 0)
	//{
	//	if (InventoryUI.equipmentSlots[6 + index].item.itmeInfo.itemId > 0)
	//	{
	//		
	//		if (InventoryUI.equipmentSlots[6 + index].item.itmeInfo.itemId == item.itmeInfo.itemId)
	//		{
	//			InventoryUI.equipmentSlots[6 + index].AddItem(item, itemCount);
	//			//InventoryUI.equipmentSlots[6 + index].SetSlotCount(itemCount);
	//			ClearSlot();
	//			return;
	//		}
	//		else if(InventoryUI.equipmentSlots[6 + index].item.itmeInfo.itemId != item.itmeInfo.itemId)
	//		{
	//			Item tempItem = new Item();
	//			tempItem = item;
	//			int tempCoumt = itemCount;
	//
	//			AddItem(tempItem);
	//			InventoryUI.equipmentSlots[6 + index].AddItem(item, itemCount);
	//			
	//			return;
	//		}
	//	}
	//	else if (InventoryUI.equipmentSlots[6 + index].item.itmeInfo.itemId == 0)
	//	{
	//		InventoryUI.equipmentSlots[6 + index].AddItem(item, itemCount);
	//		ClearSlot();
	//		return;
	//	}
	//}

	//public void OnDrag(PointerEventData eventData)
	//{
	//	//transform.position = eventData.position;
	//
	//	var ScreenPoint = Input.mousePosition;
	//
	//	ScreenPoint.z = 10f;
	//
	//	itemImage.transform.position = uiCamera.ScreenToWorldPoint(ScreenPoint);
	//}
}
