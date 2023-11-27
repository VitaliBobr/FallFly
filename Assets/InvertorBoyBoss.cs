using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InvertorBoyBoss : BossDirector
{
    public Animation animator = null;
    private void Awake()
    {
        animator = GetComponent<Animation>();
        name = "INVERTOR";
        base.bossAttacks.Add((ComboAttack,5));
        base.bossAttacks.Add((AccurateStrike, 5));
    }

    private void ComboAttack() {
        animator.Play("INVERTORRightARMSplash");
    }
    private void AccurateStrike()
    {
        animator.Play("INVERTORACCURATESTRIKE");
    }
}
