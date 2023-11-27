using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Camera.main.gameObject.GetComponent<PositionConstraint>().enabled = false ;

    }

    private void OnCollisionExit(Collision collision)
    {
        SceneManager.LoadScene(0);
    }
}
