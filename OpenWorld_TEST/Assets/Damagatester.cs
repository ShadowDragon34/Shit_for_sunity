using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagatester : MonoBehaviour
{
    public Attributesmanager playerAtm;
    public Attributesmanager enemyAtm;

    private void Update()
    {
        //Deal player damage to the enemy health
        if (Input.GetKeyDown(KeyCode.F11))
        {
            playerAtm.DealDamage(enemyAtm.gameObject);
        }
        
        //Deal enemy damage to the player health
        if(Input.GetKeyDown(KeyCode.F12))
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
        }

    }
}
