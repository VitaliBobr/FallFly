using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class rotate_to_object : MonoBehaviour
{
    [SerializeField]private GameObject gameobj;
    static bool canPlayerControll = false;
    [SerializeField]  bool CanPlayerControll { get { return canPlayerControll; } set { canPlayerControll = value;} }
    private void Start()
    {
        if (gameobj == null)
        {
            gameobj = FindObjectOfType<move>().gameObject;
        }
    }

    public void Update() {
        transform.LookAt(gameobj.transform,Vector3.forward);
    }
}
