using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : Player
{
    [SerializeField]
    private float range;    //습득 가능한 최대 거리

    private bool isPickup = false;  //습득 가능한지 못하는지

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
                text.text = other.transform.GetComponent<Item>().itmeInfo.itemName + " 획득 (G) ";
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
        //text.gameObject.SetActive(false);
    }


}
