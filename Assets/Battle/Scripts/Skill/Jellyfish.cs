using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Skill
{
    public string[] skillCommand = { "FROG", "BASS", "EEL", "COD", "CARP", "CRAB" };
    float coolDown = 14;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.SetDamageOverTime(4, 5);
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
