using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    void TakeDamage(float value);//受傷害
    void Recover(float value);//受恢復
    void SetDamageOverTime(int time, float damagePerTime);//受持續傷害
    void SetBlind(int time);

    void Purify();
    void SetSpeed(int time, float speed);
    void SetReflectDamage(float time);
    void SetDodge(float time);

}
