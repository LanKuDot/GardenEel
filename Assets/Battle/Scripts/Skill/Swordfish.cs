using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordfish : Skill
{
    public string[] skillCommand = { "SAO", "SWO" };
    float coolDown = 12;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.SetDamageOverTime(2, 20);
        target.TakeDamage(10);
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
