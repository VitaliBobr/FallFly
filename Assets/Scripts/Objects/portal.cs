using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] private GameObject point_teleportation;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Player_effects pl;
        if ((pl = collision.GetComponent<Player_effects>()) != null) {
            pl.effects_list[1].Play();
        }
        collision.transform.position = point_teleportation.transform.position;
    }
}
