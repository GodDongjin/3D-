using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : Player
{
    [SerializeField]
    private float range;    //���� ������ �ִ� �Ÿ�

    private bool isPickup = false;  //���� �������� ���ϴ���

    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject colliderObject;
    [SerializeField]
    private InventoryUI inventory;
    [SerializeField]
    private Item currentItem;

	private void Start()
	{
		//inventory = GameObject.Find("Inventory").GetComponent<InventoryUI>();
	}
	// Update is called once per frame
	void Update()
    {
        //TryAction();
        
    }

    private void TryAction()
	{
        //if(Input.GetKeyDown(KeyCode.G))
		//{
        //    Pickup();
		//}
	}

    private void Pickup()
	{
        if(isPickup)
		{
            inventory.AcquireItem(colliderObject.transform.GetComponent<Item>());
            Debug.Log(colliderObject.transform.GetComponent<Item>().itmeInfo.itemName + " ȹ���߽��ϴ�. ");
            Destroy(colliderObject.transform.gameObject);
            InfoDisappear();
		}
	}



    private void OnTriggerEnter(Collider other)
	{
	    if(other.tag == "Item")
		{
            if(other.transform != null)
			{
                colliderObject = other.gameObject;
                currentItem = other.gameObject.GetComponent<Item>();
                isPickup = true;
                text.gameObject.SetActive(true);
                text.text = other.transform.GetComponent<Item>().itmeInfo.itemName + " ȹ�� (G) ";
            }
        }
		else
		{
            InfoDisappear();
		}
	}

   // private void OnTriggerExit(Collider other)
   // {
   //     if (other.tag == "Item")
   //     {
   //         if (other.transform != null)
   //         {
   //             InfoDisappear();
   //         }
   //     }
   // }

	private void InfoDisappear()
	{
        isPickup = false;
        text.gameObject.SetActive(false);
    }


}
