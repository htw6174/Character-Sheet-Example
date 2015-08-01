using UnityEngine;
using System.Collections;

public class PlayerSheet : MonoBehaviour {

    //Stats
    public PlayerStats stats;

    //Held Item
    public PlayerEquipment equipment;

    public void CheckStats()
    {
        Debug.Log(stats.totalStrength);
        Debug.Log(stats.totalStamina);
    }

    public void Equip(Item newItem)
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        stats.AddItemStats();
    }
}
