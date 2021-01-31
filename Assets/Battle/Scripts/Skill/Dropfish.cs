﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropfish : Skill
{
    public string[] skillCommand = { "FROG", "BASS", "EEL", "COD", "CARP", "CRAB" };
    float coolDown = 30;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.SetSpeed(3, 0.8f);

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
