using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Timer = System.Timers.Timer;

public class move : MonoBehaviour//�������� �� ������������ ����� ��������� ���� � �������� ���������� �� ������������
{
    private Rigidbody rb;
     private int speed = 8;
    [SerializeField] private int torque_speed;//�������� ��������� ����
    [SerializeField] private float y_start;//��������� ��������� ���������� ������ ��� �������� ��������� �� ������ �������
    static public int angle_rotate;//����
    [SerializeField] private float speed_min;//����������� �������� ��� ������������ ������
    [SerializeField]private int inversion = 0;//��� ������������ � ���������� ��������� ������ ���������� �������� �� 3 �������
    [SerializeField] private float degrePerPressLMB = 0;//������� ���� ��� ��������� ��� �� �������� ���������� �����
    [SerializeField] private float degrePerPressRMB = 0;
    [SerializeField] private GameObject CrosshairAnchoir;//������ ����������� ��������
    [SerializeField] private LineRenderer Crosshair;//������ � ����� ��� ��������
    [SerializeField] private Transform player_gun;//������� ��������� ��������� ����� �������� � �������
    [SerializeField] private bool GunIsMultishoot=true;//����� �� ����� �������� ����������� ������
    [SerializeField] private ShootPlayer[] ShootPlayers; 
    private Player_effects player_effects;
    private void Start()
    {
        ShootPlayers = GetComponentsInChildren<ShootPlayer>();
        player_gun = GetComponentInChildren<ShootPlayer>().gameObject.transform;
        Crosshair = CrosshairAnchoir.GetComponent<LineRenderer>();
        if (!PlayerPrefs.HasKey("angle"))
        {
            PlayerPrefs.SetInt("angle", 3);
        }
        angle_rotate = PlayerPrefs.GetInt("angle");
        player_effects = GetComponent<Player_effects>();
        //y_start = transform.position.y;
        rb = GetComponent<Rigidbody>();
        speed = 8;
       
    }
    // Update is called once per frame
    public void InverseControlOnTime(int time) {//����������� ���������� �� time ������
        player_effects.effects_list[2].Play();
        inversion = -1;
        Timer timer = new Timer(time);
        timer.Elapsed += (x, y) => { inversion = 1; };
        timer.AutoReset = false;
        timer.Start();
    }
    void Update()
    {
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*
        if (Input.backButtonLeavesApp || Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene(0);//����� � ����
        }
        float temp_speed = speed * speed_min;// ������� ��������
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))){//��������� �����������
            float final_rotate = -angle_rotate * inversion * torque_speed * Time.deltaTime;
            //����������� ��������� ���� �� ������� * �� ����������� �������� �� -1 �� 1 * �������� ��������� ���� * ����� 1-�� �����
            transform.Rotate(Vector3.right, final_rotate);//������� ������
            player_effects.effects_list[0].Emit(1);// ����������� ����� �� ������
            if (degrePerPressRMB >= 360)// ���� ��� ��������� ��� ������ ������ ���� � ��������� ������� �����
            {
                ShootPlayers[1].Shoot();//��������
                degrePerPressRMB = 0;//���������� ���� ����
            }
            else {
                degrePerPressRMB = 0;
            }

            if (degrePerPressLMB <= -360)
            {
                if (GunIsMultishoot) { degrePerPressLMB += final_rotate; }// ���� ���� ������ ���� �� ������������ ���������� ���������
                player_effects.effects_list[3].Emit(1);//������ ������� ������
                Crosshair.enabled = true;
                Crosshair.SetPosition(0, player_gun.position);//��������� ������� 1
                Crosshair.SetPosition(1, CrosshairAnchoir.transform.position);//2
            }
            else
            {
                degrePerPressLMB += final_rotate;//���� ���� �� ������ ������������ ��������� ����
            }
        }
        else {//���� ������ �� ���������� ������ ����� ����
            float final_rotate = angle_rotate * inversion * torque_speed * Time.deltaTime;
            transform.Rotate(Vector3.right, final_rotate);
            //����� ��� ������� ������ ����������� ������� ��� �������� ���� ���� ������� ��� �����
            if (degrePerPressRMB >= 360)
            {
                player_effects.effects_list[4].Emit(1);
            }
            else {
                degrePerPressRMB += final_rotate;
            }
            if (degrePerPressLMB <= -360)
            {
                int count_shoot = (int)(degrePerPressLMB * -1 - 360) / 90 + 1;
                if (count_shoot > 5) count_shoot = 5;
                Debug.Log("Count shoot laser =" + count_shoot);
                degrePerPressLMB = 0;
                StartCoroutine(ShootParallel(count_shoot));
                Crosshair.enabled = false;
            }
            else {
                degrePerPressLMB = 0;
            }
            //if (!player_effects.effects_list[0].isStopped) player_effects.effects_list[0].Stop();
        }
        if (transform.position.y <= y_start)//������� �������� � ����������� �� ������
        {
            temp_speed = speed + Mathf.Abs(transform.position.y);
        }
        else {
            temp_speed = speed - transform.position.y;
        }
        */
        transform.Translate(Vector3.forward * (temp_speed + speed_min) * Time.deltaTime);//, ForceMode.VelocityChange);
    }

    private IEnumerator ShootParallel(int count)//�������� ��������
    {
        for (int i = 0; i < count; i++)
        {
            ShootPlayers[0].Shoot();
            yield return new WaitForSeconds(0.1f); // ���������� �������� ����� 100ms
        }
    }
}
