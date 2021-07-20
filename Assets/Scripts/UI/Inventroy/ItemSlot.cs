using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

public class ItemSlot : MonoBehaviour
{
	public Item item;   //획득한 아이템
	public int itemCount;   //회득한 아이템의 개수
	public Image itemImage; //아이템의 이미지

	public SlotType slotType;
	public string slotTypeName;

	[SerializeField]
	private Text text_count;
	[SerializeField]
	private GameObject go_countImgae;

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
		if(slotType == SlotType.Stuff)
        {
			item = _item;
			itemCount = _count;
			
			Sprite[] sprites = Resources.LoadAll<Sprite>("item");
			for(int i = 0; i < sprites.Length; i++)
            {
				if(sprites[i].name == _item.itmeInfo.itemImageName)
                {
					itemImage.sprite = sprites[i];
				}
				
			}
			//
			Debug.Log("이미지 이름 " + _item.itmeInfo.itemImageName);

			if (item.itmeInfo.itemType == "Used")
			{
				go_countImgae.SetActive(true);
				text_count.text = itemCount.ToString();
				SetColor(1);

			}
			else
			{
				text_count.text = "0";
				go_countImgae.SetActive(false);
				SetColor(1);
			}
		}

		else if(slotType != SlotType.Stuff)
        {
			item = _item;
			if(slotType.ToString() == item.itmeInfo.itemType)
            {
				Sprite[] sprites = Resources.LoadAll<Sprite>("item");
				for (int i = 0; i < sprites.Length; i++)
				{
					if (sprites[i].name == _item.itmeInfo.itemImageName)
					{
						itemImage.sprite = sprites[i];
						SetColor(1);
					}

				}
				text_count.text = "0";
				go_countImgae.SetActive(false);
			}
			else
            {
				item = null;
            }
			

		}

		
	}

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

}
