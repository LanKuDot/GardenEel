using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalAttack : Skill
{
    public string[] skillCommand = { "ATK", "SHARK", "EEL" };

    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.TakeDamage(2);
    }

    public override string GetSkillCommand()
    {
        return skillCommand[Random.Range(0, skillCommand.Length)];
    }
}
