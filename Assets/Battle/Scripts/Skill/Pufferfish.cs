using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : Skill
{
    public string[] skillCommand = { "TOXIN", "CRUEL", "PUFFER" };
    float coolDown = 15;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.TakeDamage(30);
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
