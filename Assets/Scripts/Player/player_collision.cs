using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class player_collision : MonoBehaviour
{
    public bool debug_god_mod = false;
    private bool can_restart= false;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MarkDestroyer>() != null)
        {
            if (!debug_god_mod) { Die(); }
        }
        else if (collision.gameObject.GetComponent<EndLevel>()!=null) {
            //SceneManager.LoadScene(0);
        }
    }
    
    private void OnBecameInvisible()
    {
        Die();
    }
    private void Die()
    {
        Player_effects player_effects = GetComponent<Player_effects>();
        {
            player_effects.effects_list[1].emissionRate = 1000;
            player_effects.effects_list[1].Play();
            Timer timerOfRestart = new Timer();
            timerOfRestart.Elapsed+=((x, y) => { can_restart = true; });
            timerOfRestart.AutoReset = false;
            timerOfRestart.Start();
        }
    }
    public void FixedUpdate()
    {
        if (can_restart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
