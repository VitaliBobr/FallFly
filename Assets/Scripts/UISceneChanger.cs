using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneChanger : MonoBehaviour
{
    public void LoadScene(int number) { 
        SceneManager.LoadScene(number);
    }
    public void LoadMainMenu() {
        LoadScene(0);
    }

}
