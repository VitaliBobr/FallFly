
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextTutorial : MonoBehaviour
{
    TimeController timeController;
    // Start is called before the first frame update
    void Start()
    {
        timeController = gameObject.AddComponent<TimeController>();
        timeController.TurnOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            timeController.ResetTime();
            Destroy(gameObject);
        }
    }
}
