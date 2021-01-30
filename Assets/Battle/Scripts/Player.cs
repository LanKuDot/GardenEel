using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    public CharacterUIController characterUI;
    public float hp = 100;
    int dodgeChance;


    public void Recover(float value)
    {
        hp += value;
        hp = Mathf.Min(100, hp);
        characterUI.SetHp(hp);
    }

    public void TakeDamage(float value)
    {
        hp -= value;
        hp = Mathf.Max(hp, 0);
        characterUI.SetHp(hp);

    }




}
