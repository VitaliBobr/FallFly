using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("TurretName =" + other.transform.gameObject.name);
        //Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.forward*20, Color.green,3);
        Ray ray = new Ray(transform.position, Vector3.forward*20);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,30,64)) {
            Debug.Log("TurretName =" + hit.transform.gameObject.name);
            Destroy(hit.transform.gameObject,1);
            hit.transform.parent = null;
            hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(gameObject.GetComponent<Rigidbody>().velocity*10, hit.point);
            hit.transform.GetComponentInChildren<shoot_any_time>().enabled= true;
            
            //GameObject ragdoll = Instantiate(new GameObject(),hit.transform.position,hit.transform.rotation);
            //ragdoll.AddComponent<Rigidbody>().AddForce((transform.position - hit.transform.position).normalized * 10, ForceMode.Impulse); ;
            //ragdoll.AddComponent<MeshFilter>().mesh = hit.transform.GetComponent<MeshFilter>().mesh;
            //ragdoll.AddComponent<MeshRenderer>().material = hit.transform.GetComponent<MeshRenderer>().material;
            Destroy(gameObject);
        } 
    }
}
