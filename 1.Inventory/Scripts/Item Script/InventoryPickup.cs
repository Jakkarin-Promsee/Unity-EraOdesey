using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class InventoryPickup : MonoBehaviour
{

    /// /////////////////////////////////
    public double numberAmount = 1;
    public long multiplierAmount = 0;

    /// /////////////////////////////////
    public InventoryMaterialData ItemData;

    private BoxCollider2D myCollider;

    private void Awake() {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.isTrigger = true;
    }

    private void Start() {
        
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().sprite = ItemData.Icon;
        GetComponent<Transform>().localScale = new Vector3(0.04f,0.04f,0f);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        var inventory = other.transform.GetComponent<InventoryAllHolder>();

        if(!inventory) return;
        
        if(inventory.InventoryAllItemSystem.AddToInventoryMaterial(ItemData, numberAmount, multiplierAmount))
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
