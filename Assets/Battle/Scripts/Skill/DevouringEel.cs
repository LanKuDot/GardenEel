using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevouringEel : Skill
{
    public string[] skillCommand = { "FROG", "BASS", "EEL", "COD", "CARP", "CRAB" };
    float coolDown = 20;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.TakeDamage(15);
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
