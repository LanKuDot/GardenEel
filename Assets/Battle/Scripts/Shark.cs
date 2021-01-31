using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour, ICharacter
{
    [SerializeField] float timeBeforeAction = 7f;
    float timer;
    public CharacterUIController characterUI;
    public float hp = 100;
    public Player player;
    List<Skill> skills = new List<Skill>();
    int skillIndex = 0;
    float speed;
    int speedCount = 0;
    int blindCount = 0;
    class DOT
    {
        public float damage;
        public int time;

        public DOT(float damage, int time)
        {
            this.damage = damage;
            this.time = time;
        }
    }
    List<DOT> DOTs = new List<DOT>();
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
        Debug.Log("shark hp: " + hp);
        characterUI.SetHp(hp);

    }
    private void Start()
    {
        player = GetComponent<Player>();
        skills.Add(new Hit());
        skills.Add(new Flick());
        skills.Add(new Swallow());
        skills.Add(new Deterrence());
    }

    private void Update()
    {

        timer -= Time.deltaTime * speed;
        if (timer <= 0)
        {
            DoAction();

            StartNewAction();
        }
    }
    private void DoAction()
    {
        TakeDamageOverTime();
        if (speedCount > 0)
        {
            speedCount -= 1;
        }
        else
        {
            speed = 1.0f;
        }
        if (blindCount > 0)
        {
            blindCount -= 1;
            return;
        }
        skills[skillIndex].DoSkill(this, player);
    }

    private void TakeDamageOverTime()
    {

        foreach (DOT dot in DOTs)
        {
            this.TakeDamage(dot.damage);
            dot.time -= 1;

        }
        DOTs.RemoveAll((x) => { return x.time <= 0; });
    }


    void StartNewAction()
    {
        timer = timeBeforeAction;
    }

    public void SetDamageOverTime(int time, float damagePerTime)
    {
        DOTs.Add(new DOT(damagePerTime, time));
    }

    public void SetBlind(int time)
    {
        throw new System.NotImplementedException();
    }

    public void Purify()
    {
        DOTs.Clear();
    }

    public void SetSpeed(int time, float speed)
    {
        this.speed = speed;
        speedCount = time;
    }

    public void SetReflectDamage(float time)
    {
        throw new System.NotImplementedException();
    }

    public void SetDodge(float time)
    {
        throw new System.NotImplementedException();
    }
}
