using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InventoryPickupForWeapon : MonoBehaviour
{
    public double numberAmount = 0;
    public long multiplierAmount = 0;
    public InventoryWeaponData ItemData;

    private BoxCollider2D myCollider;

    private void Awake() {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.isTrigger = true;
    }

    private void Start() {
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().sprite = ItemData.Icon;
        GetComponent<Transform>().localScale = new Vector3(0.07f,0.07f,0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var inventory = other.transform.GetComponent<InventoryAllHolder>();

        if(!inventory) return;
        
        if(inventory.InventoryAllItemSystem.AddToInventoryWeapon(ItemData, numberAmount, multiplierAmount))
        {   
            inventory.UpdateDisplaySlotFromHolder();
            inventory.InventoryAllItemSystem.UpdateAllPopUP();
            Destroy(this.gameObject);
        }
    }

    private void Delete()
    {
        Destroy(this.gameObject);
    }
}
