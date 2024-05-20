using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributesmanager : MonoBehaviour
{
    public int health;
    public int attack;

    public void TakeDamage(int amount) 
    {
        health -= amount;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<Attributesmanager>();
        if(atm != null)
        {
            atm.TakeDamage(attack);
        }

    }

}
