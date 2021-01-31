using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deterrence : Skill
{
    string cmd = "sharrrrrrrrrrrk";
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.TakeDamage(10);
        self.Purify();
    }

    public override float GetCoolDown()
    {
        throw new System.NotImplementedException();
    }

    public override string GetSkillCommand()
    {
        return cmd;
    }



}
