using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCmdManager : MonoBehaviour
{
    public Text remainText;
    string whiteText = "";
    string redText = "";
    string currentText = "";
    [SerializeField] private int bigSize = 35;
    Player player;
    //Skill currentSkill;
    Shark shark;
    List<Skill> skills = new List<Skill>();
    int skillIndex = 1;
    public List<Image> coolDownImage = new List<Image>();
    public List<float> coolDownTime = new List<float>();
    private void OnGUI()
    {
        if (currentText == "")
        {
            return;
        }
        if (Event.current.type == EventType.KeyUp)
            if ((int)Event.current.keyCode >= 97 && (int)Event.current.keyCode <= 122)
            {
                InputCmd(Event.current.keyCode);

            }
    }

    void InputCmd(KeyCode keyCode)
    {

        if (currentText == keyCode.ToString())
        {
            redText = redText + currentText;
            if (whiteText != "")
            {
                currentText = whiteText[0].ToString();
                whiteText = whiteText.Remove(0, 1);
                UpdateText();
            }
            else
            {
                currentText = "";
                DoSkill();
            }
        }





    }
    private void Start()
    {
        //Debug.Log(KeyCode.O.ToString());
        remainText.text = "";
        UpdateText();
        player = gameObject.GetComponent<Player>();
        shark = GetComponent<Shark>();


        skills.Add(null);
        coolDownTime.Add(0);
        skills.Add(new NormalAttack());
        coolDownTime.Add(skills[1].GetCoolDown());
        skills.Add(new BlackTuna());
        coolDownTime.Add(skills[2].GetCoolDown());
        skills.Add(new Clownfish());
        coolDownTime.Add(skills[3].GetCoolDown());
        skills.Add(new DevouringEel());
        coolDownTime.Add(skills[4].GetCoolDown());
        skills.Add(new Dolphin());
        coolDownTime.Add(skills[5].GetCoolDown());


    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {


            skillIndex = 1;
            StartNewSkill();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {

            skillIndex = 2;
            StartNewSkill();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {

            skillIndex = 3;
            StartNewSkill();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {

            skillIndex = 4;
            StartNewSkill();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {

            skillIndex = 5;
            StartNewSkill();
        }

        for (int i = 1; i < coolDownTime.Count; i++)
        {
            if (coolDownTime[i] <= skills[i].GetCoolDown())
            {
                coolDownTime[i] += Time.deltaTime;
            }
            coolDownImage[i].fillAmount = 1f - (coolDownTime[i] / skills[i].GetCoolDown());
        }


    }
    void UpdateText()
    {
        string stringShown = "<color=#ff0000ff>" + redText + "</color>" + "<color=#000000ff>" + "<size=" + bigSize.ToString() + ">" + currentText + "</size>" + whiteText + "</color>";
        remainText.text = stringShown;
    }

    public void StartNewSkill()
    {
        if (coolDownImage[skillIndex].fillAmount > 0) return;

        redText = "";
        whiteText = skills[skillIndex].GetSkillCommand();

        currentText = whiteText[0].ToString();
        whiteText = whiteText.Remove(0, 1);

        UpdateText();
    }

    public void DoSkill()
    {
        skills[skillIndex].DoSkill(player, shark);
        whiteText = "";
        redText = "";
        currentText = "";
        UpdateText();
        coolDownTime[skillIndex] = 0;
    }

}
