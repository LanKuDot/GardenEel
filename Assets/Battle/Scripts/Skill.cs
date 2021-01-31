using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Skill
{

    public abstract void DoSkill(ICharacter self, ICharacter target);
    public abstract string GetSkillCommand();
    public abstract float GetCoolDown();
}
