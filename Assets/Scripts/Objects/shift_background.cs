using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shift_background : MonoBehaviour
{
    Collider collider;
    private void Start()
    {
        this.collider = GetComponent<Collider>();
    }
    public void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<move>() != null) {
            Debug.Log("Shift");
            gameObject.transform.position += new Vector3(48, 0, 0);
        }
    }
}
