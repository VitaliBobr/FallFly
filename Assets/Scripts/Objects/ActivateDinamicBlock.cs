using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateDinamicBlock : MonoBehaviour//���������� ������������ ����� � ������� ��������� ����������� ���������� ����
{
    Rigidbody rb;
    ConstantForce cf;
    public Transform AnchorDirection;
    public int KPDSpeed = 10;
    private Vector3 Direction;// ����������� �������� �������, �� ��������� �������� anchor 
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Direction = AnchorDirection.transform.position-gameObject.transform.position;// ��������� ������ ����������� �������� �����
        Direction.Normalize();
        cf = GetComponent<ConstantForce>();
        cf.enabled = false;
    }

    private void OnBecameVisible()
    {
        if (cf != null) {
            cf.enabled = true;
        }
        cf.force = Direction*KPDSpeed;
    }
}
