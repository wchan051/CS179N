using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickup : MonoBehaviour
{
   // public enum pickupObject { LOOT, MESO}; // if we want to count loot pickup
   // public PickupObject currentObject;
   // public int pickupQuantity;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "CharacterRobotBoy")
        {
            Destroy(gameObject);
        }
    }
}
