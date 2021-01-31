using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : Skill
{
    string cmd = "sharrrrrrrrrrrk";
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.TakeDamage(12);
    }

    public override string GetSkillCommand()
    {
        return cmd;
    }
    public override float GetCoolDown()
    {
        throw new System.NotImplementedException();
    }
}
