using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : Skill
{
    public string[] skillCommand = { "COD", "CARP", "CRAB" };

    float coolDown = 1;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        self.SetDodge(5f);
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
