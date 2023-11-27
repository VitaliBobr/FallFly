using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMoveWall : MonoBehaviour//При столкновении динамического блока с любым другим реверсирует направление
{
    private ConstantForce cf;
    private void Revers() {
        if (cf == null) {
            cf= GetComponent<ConstantForce>() ?? gameObject.AddComponent<ConstantForce>();
        }
        cf.force = cf.force * -1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Revers();
    }
    private void OnBecameInvisible()
    {
        Revers();
    }
}
