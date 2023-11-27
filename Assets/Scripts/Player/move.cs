using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Timer = System.Timers.Timer;

public class move : MonoBehaviour//Отвечает за передвижение путем изменение угла и механики завязанные на передвижении
{
    private Rigidbody rb;
     private int speed = 8;
    [SerializeField] private int torque_speed;//Скорость изменения угла
    [SerializeField] private float y_start;//Установка начальной координаты высоты для рассчёта скоростей на разных высотах
    static public int angle_rotate;//Угол
    [SerializeField] private float speed_min;//Минимальная скорость при максимальной высоте
    [SerializeField]private int inversion = 0;//При столкновении с некоторыми объектами меняет управление наоборот на 3 секунды
    [SerializeField] private float degrePerPressLMB = 0;//Считает угол при удержании лкм от которого заряжается пушка
    [SerializeField] private float degrePerPressRMB = 0;
    [SerializeField] private GameObject CrosshairAnchoir;//Вектор направления выстрела
    [SerializeField] private LineRenderer Crosshair;//Прицел и мушка для выстрела
    [SerializeField] private Transform player_gun;//Позиция установки начальной точки стрельбы и прицела
    [SerializeField] private bool GunIsMultishoot=true;//Может ли пушка стрелять несколькими пулями
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
    public void InverseControlOnTime(int time) {//Инверсирует управление на time секунд
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
            SceneManager.LoadScene(0);//Выход в меню
        }
        float temp_speed = speed * speed_min;// Рассчёт скорости
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))){//Изменение направления
            float final_rotate = -angle_rotate * inversion * torque_speed * Time.deltaTime;
            //Стандартное изменение угла за секунду * на коэффициект инверсии от -1 до 1 * скорость изменения угла * время 1-го кадра
            transform.Rotate(Vector3.right, final_rotate);//Вращаем самолёт
            player_effects.effects_list[0].Emit(1);// Проигрываем огонь из турбин
            if (degrePerPressRMB >= 360)// Если при удержании лкм самолёт сделал круг и отпустили клавишу тогда
            {
                ShootPlayers[1].Shoot();//Стреляем
                degrePerPressRMB = 0;//Сбрасываем счёт угла
            }
            else {
                degrePerPressRMB = 0;
            }

            if (degrePerPressLMB <= -360)
            {
                if (GunIsMultishoot) { degrePerPressLMB += final_rotate; }// Если есть сделан круг то рассчитываем количество выстрелов
                player_effects.effects_list[3].Emit(1);//Эффект зарядки лазера
                Crosshair.enabled = true;
                Crosshair.SetPosition(0, player_gun.position);//Установка прицела 1
                Crosshair.SetPosition(1, CrosshairAnchoir.transform.position);//2
            }
            else
            {
                degrePerPressLMB += final_rotate;//Если круг не сделан просчитываем удержания мыши
            }
        }
        else {//Если кнопка не нажимается самолёт летит вниз
            float final_rotate = angle_rotate * inversion * torque_speed * Time.deltaTime;
            transform.Rotate(Vector3.right, final_rotate);
            //Далее идёт рассчёт кругов ненажимания клавиши что вызывает свой свой выстрел при круге
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
        if (transform.position.y <= y_start)//Рассчёт скорости в зависимости от высоты
        {
            temp_speed = speed + Mathf.Abs(transform.position.y);
        }
        else {
            temp_speed = speed - transform.position.y;
        }
        */
        transform.Translate(Vector3.forward * (temp_speed + speed_min) * Time.deltaTime);//, ForceMode.VelocityChange);
    }

    private IEnumerator ShootParallel(int count)//Стрельба очередью
    {
        for (int i = 0; i < count; i++)
        {
            ShootPlayers[0].Shoot();
            yield return new WaitForSeconds(0.1f); // продолжить примерно через 100ms
        }
    }
}
