using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : Skill
{
    public string[] skillCommand = { "FROG", "BASS", "EEL", "COD", "CARP", "CRAB" };
    float coolDown = 10;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.SetBlind(1);
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
