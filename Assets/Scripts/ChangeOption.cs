using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;
using System;

public class ChangeOption : MonoBehaviour
{
    public TMPro.TMP_Text tmpDisplay;
    public Slider sensor;
    public Options options;
    public enum Options
    {
        angle = 0,pixelmode = 1
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(options.ToString());
        if (PlayerPrefs.HasKey(options.ToString())){//ѕолучаем сохраненное значение если оно имеетс€ 
            tmpDisplay.text = PlayerPrefs.GetInt(options.ToString()).ToString();
        }
        else { 
            PlayerPrefs.SetInt(options.ToString(), 5);
        }
        sensor.onValueChanged.AddListener(delegate {
            int val= (int)sensor.value; 
            PlayerPrefs.SetInt(options.ToString(), val); 
            tmpDisplay.text = val.ToString();
            switch (options)
            {
                case Options.angle:
                    move.angle_rotate = val;
                    break;
                case Options.pixelmode:
                    CameraSaveableParams.isEnabled= (val == 0? false: true);
                    break;
                default:
                    break;
            }; 
        }); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
