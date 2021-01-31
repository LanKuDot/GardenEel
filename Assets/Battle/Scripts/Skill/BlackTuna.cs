using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackTuna : Skill
{
    public string[] skillCommand = { "BTUNA", "TAILATK", "CAUDAL" };
    float damage = 14;
    float coolDown = 10;
    public override void DoSkill(ICharacter self, ICharacter target)
    {
        target.TakeDamage(damage);
        Debug.Log(this.ToString());
    }

    public override float GetCoolDown()
    {
        return coolDown;
    }

    public override string GetSkillCommand()
    {
        return skillCommand[Random.Range(0, skillCommand.Length)];
    }
    public void setdamage(ref float damage)
    {
        this.damage = damage;
    }

}
