using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkDestroyer : MonoBehaviour//Помечаем объекты которые могут уничтожить игрока
{
    [SerializeField] bool can_destroy_from_camera;
    [SerializeField] bool can_destroy_from_wall;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MarkWall>() != null && can_destroy_from_wall == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        if (can_destroy_from_camera)
        {
            Destroy(gameObject);
        }
    }
}
