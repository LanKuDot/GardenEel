using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricEel : Skill
{
    public string[] skillCommand = { "FROG", "BASS", "EEL", "COD", "CARP", "CRAB" };
    float coolDown = 23;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.SetSpeed(2, 0.85f);
        target.SetDamageOverTime(2, 2);
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
