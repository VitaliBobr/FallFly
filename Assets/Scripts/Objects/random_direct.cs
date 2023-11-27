using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_direct : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Obsolete]
    void Start()
    {
        transform.rotation.SetEulerRotation(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
