using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_scale : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float min_scale=1;
    [SerializeField] private float max_scale=3;
    void Start()
    {
        float scale = Random.Range(min_scale, max_scale);
        Debug.Log("Random_scale = " + scale);
        transform.localScale.Set(scale,scale,scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
