using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : Skill
{
    public string[] skillCommand = { "INK", "JET", "OCT" };
    float coolDown = 10;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.SetBlind(2);
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
