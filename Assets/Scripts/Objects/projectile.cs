using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField]public Vector3 target;

    private void Start()
    {
        transform.LookAt(target, Vector3.forward);
    }
}
