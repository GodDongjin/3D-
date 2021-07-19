using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
	public Item item;   //ȹ���� ������
	public int itemCount;   //ȸ���� �������� ����
	public Image itemImage; //�������� �̹���

	[SerializeField]
	private Text text_count;
	[SerializeField]
	private GameObject go_countImgae;

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
		item = _item;
		itemCount = _count;
		itemImage.sprite = Resources.Load<Sprite>(_item.itmeInfo.itemImageName);

		if (item.itmeInfo.itemType != "Equipment")
		{
			go_countImgae.SetActive(true);
			text_count.text = itemCount.ToString();

		}
		else
		{
			text_count.text = "0";
			go_countImgae.SetActive(false);
		}

		SetColor(1);
	}

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
	private void ClearSlot()
	{
		item = null;
		itemCount = 0;
		itemImage.sprite = null;
		SetColor(0);

		text_count.text = "0";
		go_countImgae.SetActive(false);
	}

}
