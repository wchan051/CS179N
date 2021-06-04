using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickup : MonoBehaviour
{
   // public enum pickupObject { LOOT, MESO}; // if we want to count loot pickup
   // public PickupObject currentObject;
   // public int pickupQuantity;
   public Player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            player.pickuppassive(100);
            //player.pickuppassive(-0.5f);
            Debug.Log("picked up");
        }
    }
}
