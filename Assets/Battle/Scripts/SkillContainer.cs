using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SkillContainer", menuName = "GardenEel/SkillContainer", order = 0)]

public class SkillContainer : ScriptableObject
{
    public List<Skill> skillList = new List<Skill>();

}
