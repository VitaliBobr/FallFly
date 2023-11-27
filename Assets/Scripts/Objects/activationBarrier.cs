using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class activationBarrier : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AHahah");
        List<MonoBehaviour> mbl = new List<MonoBehaviour>();
        mbl.AddRange(other.GetComponents<MonoBehaviour>());
        mbl.AddRange(other.GetComponentsInChildren<MonoBehaviour>());
        foreach (var item in mbl)
        {
            Debug.Log("Components names = " + item.name + ",ObjectNames =" + item.gameObject.name);
            item.enabled = true;
        }
    }
}
