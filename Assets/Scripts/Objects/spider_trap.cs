using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Babah");
        move player_movement;
        if ((player_movement = other.GetComponent<move>()) != null) {
            GetComponent<ParticleSystem>().Play();
            player_movement.InverseControlOnTime(3000);
        }
    }
}
