using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    public CharacterUIController characterUI;
    public float hp = 100;
    int dodgeChance;
    float reflectTime;
    Shark shark;
    float dodgeTime;

    public void Purify()
    {
        throw new System.NotImplementedException();
    }

    public void Recover(float value)
    {
        hp += value;
        hp = Mathf.Min(100, hp);
        characterUI.SetHp(hp);
    }

    public void SetBlind(int time)
    {

    }

    public void SetDamageOverTime(int time, float damagePerTime)
    {

    }

    public void SetDodge(float time)
    {
        dodgeTime = time;
    }

    public void SetReflectDamage(float time)
    {
        reflectTime = time;
    }

    public void SetSpeed(int time, float speed)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float value)
    {

        float damageRate = 1;
        if (dodgeTime > 0)
        {
            damageRate = Mathf.Min(damageRate, 0.2f);
        }

        if (reflectTime > 0)
        {
            shark.TakeDamage(value * 0.5f);
            damageRate = Mathf.Min(damageRate, 0.5f);
        }


        hp -= value * damageRate;
        hp = Mathf.Max(hp, 0);
        characterUI.SetHp(hp);

        if (hp == 0)
        {
            Debug.Log("鯊魚贏");
        }
    }
    private void Start()
    {
        shark = GetComponent<Shark>();
    }
    private void Update()
    {
        if (reflectTime > 0)
        {
            reflectTime -= Time.deltaTime;
        }
        if (dodgeTime > 0)
        {
            dodgeTime -= Time.deltaTime;

        }

    }



}
