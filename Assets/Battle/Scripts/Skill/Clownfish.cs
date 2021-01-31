using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clownfish : Skill
{
    public string[] skillCommand = { "FROG", "BASS", "EEL", "COD", "CARP", "CRAB" };
    float coolDown = 40;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        self.Recover(30);
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
