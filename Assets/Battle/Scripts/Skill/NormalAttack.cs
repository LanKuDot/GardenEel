﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalAttack : Skill
{
    public string[] skillCommand = { "FROG", "BASS", "EEL" };
    float coolDown = 1f;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.TakeDamage(2);
    }

    public override string GetSkillCommand()
    {
        return skillCommand[Random.Range(0, skillCommand.Length)];
    }
    public override float GetCoolDown()
    {
        return coolDown;
    }
}
