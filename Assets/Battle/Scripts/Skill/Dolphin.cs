using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : Skill
{
    public string[] skillCommand = { "TAIL", "DOLL", "SMART" };

    float coolDown = 12;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        for (int i = 0; i < 7; i++)
        {
            target.TakeDamage(Random.Range(2, 6));
        }



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
