using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Wall_Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.gameObject.layer == 128) { 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
