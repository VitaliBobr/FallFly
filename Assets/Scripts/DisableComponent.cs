using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponent : MonoBehaviour
{
    [SerializeField] private MonoBehaviour [] components;
    [SerializeField] private int timeToFix;
    IEnumerator Disable() {
        foreach (var component in components)
        {
            component.enabled = false;
            yield return new WaitForSeconds(timeToFix);
            component.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<move>() != null) {
            Debug.Log("HI " + other.name);
            StartCoroutine(Disable());
        }
    }
}
