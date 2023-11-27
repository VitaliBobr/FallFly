using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using Timer = System.Timers.Timer;

public class shoot_any_time : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] int time_shoot = 1000;
    [SerializeField] int power_shoot = 1;
    bool can_shoot = true;
    GameObject target = null;
    // Update is called once per frame
    private void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<move>().gameObject;
        }
    }
    void Update()
    {
        if (can_shoot== true && Time.timeScale!= 0) {
            can_shoot = false;
            Timer timer = new Timer(time_shoot);
            timer.Elapsed += (x, y) => { can_shoot = true; };
            timer.AutoReset = false;
            timer.Start();
            
            GameObject temp_bullet = Instantiate (bullet,transform.position, transform.rotation);
            temp_bullet.transform.LookAt(transform.position, Vector3.up);
            temp_bullet.GetComponent<Rigidbody>().AddForce((temp_bullet.transform.position - target.transform.position).normalized * -1000 * power_shoot);
        }
    }
}
