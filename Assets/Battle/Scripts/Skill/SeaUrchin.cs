using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaUrchin : Skill
{
    public string[] skillCommand = { "SPI", "TIP", "TOP", "POKE" };
    float coolDown = 10;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        self.SetReflectDamage(5f);
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
