using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] public int PowerShoot;
    [SerializeField] public GameObject Bullet;
    [SerializeField] public GameObject target;
    public void Shoot()
    {
        GameObject temp_bullet = Instantiate(Bullet, transform.position, transform.rotation);
        temp_bullet.transform.LookAt(transform.position, Vector3.up);
        temp_bullet.GetComponent<Rigidbody>().AddForce((temp_bullet.transform.position - target.transform.position).normalized * -1000 * PowerShoot);
    }
}
