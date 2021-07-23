using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SlotType
{
	HeadArmor,
	shoulderArmor,
	PantsArmor,
	TopArmor,
	GlovesArmor,
	ShoesArmor,
	Stuff
}

public class ItemSlot : MonoBehaviour, IPointerClickHandler//,  IDragHandler
{
	[SerializeField]
	public Item item;   //ȹ���� ������
	public int itemCount;   //ȸ���� �������� ����
	public Image itemImage; //�������� �̹���

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


	private void Start()
	{
		uiCamera = GameObject.Find("UiCamera").GetComponent<Camera>();
	}

	// �̹����� ���� ����
	private void SetColor(float _alpha)
	{
		Color color = itemImage.color;
		color.a = _alpha;
		itemImage.color = color;
	}

	//������ ȹ��
	public void AddItem(Item _item, int _count = 1)
	{
		//if(slotType == SlotType.Stuff)
		//      {
		item = _item;
		itemCount = _count;

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


	//������ ���� ����
	public void SetSlotCount(int _count)
	{
		itemCount += _count;
		text_count.text = itemCount.ToString();

		if (itemCount <= 0)
		{
			ClearSlot();
		}
	}

	//���� �ʱ�ȭ
	public void ClearSlot()
	{
		item = null;
		itemCount = 0;
		itemImage.sprite = null;
		SetColor(0);

		text_count.text = "0";
		go_countImgae.SetActive(false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if (item != null)
			{

				if (item.itmeInfo.itemType != "Stuff")
				{
					if (InventoryUI.equipmentInventoryBase.activeSelf == true)
					{
						InventoryUI.SlotCheck(this);
					}
				}
				else
				{
					SetSlotCount(-1);
				}
			}

		}
	}

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
