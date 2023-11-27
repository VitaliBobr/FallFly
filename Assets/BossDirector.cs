using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

abstract public class BossDirector : MonoBehaviour
{
    public string name = "No Name";
    public List<(UnityAction, int)> bossAttacks = new();
    public void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        for (; true;)
        {
            int currentAttack = UnityEngine.Random.RandomRange(0, bossAttacks.Count);
            bossAttacks[currentAttack].Item1.Invoke();

            yield return new WaitForSeconds(bossAttacks[currentAttack].Item2);
        }
    }
}
