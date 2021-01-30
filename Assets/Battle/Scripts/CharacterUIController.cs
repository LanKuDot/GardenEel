using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour
{
    public Image image;
    private float hp = 1f;
    public void SetHp(float value)
    {
        hp = value / 100f;
    }
    private void Update()
    {
        image.fillAmount = Mathf.Lerp(image.fillAmount, hp, Time.deltaTime * 0.9f);
    }

}
