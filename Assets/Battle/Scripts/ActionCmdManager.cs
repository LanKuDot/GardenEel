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
    Dictionary<int, Skill> skillDictionary = new Dictionary<int, Skill>();
    public List<Sprite> skillSprites = new List<Sprite>();
    public List<Image> skillIconImages = new List<Image>();
    public List<GameObject> effectList = new List<GameObject>();
    int[] skillNumbers;
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
        var normal = new NormalAttack();
        skillDictionary.Add(-1, normal);
        skillDictionary.Add(0, normal);
        skillDictionary.Add(1, new Dodge());
        skillDictionary.Add(2, new Swordfish());
        skillDictionary.Add(3, new Octopus());
        skillDictionary.Add(4, new Dropfish());
        skillDictionary.Add(5, new DevouringEel());
        skillDictionary.Add(6, new Dolphin());
        skillDictionary.Add(7, new Clownfish());
        skillDictionary.Add(8, new BlackTuna());
        skillDictionary.Add(9, new Pufferfish());
        skillDictionary.Add(10, new ElectricEel());
        skillDictionary.Add(11, new SeaUrchin());
        skillDictionary.Add(12, new Jellyfish());



        //Debug.Log(KeyCode.O.ToString());

        Time.timeScale = 1;
        remainText.text = "";
        UpdateText();
        player = gameObject.GetComponent<Player>();
        shark = GetComponent<Shark>();
        Debug.Log(Investigate.GardenEelComponent.Instance.componentIDs[0]);
        Debug.Log(Investigate.GardenEelComponent.Instance.componentIDs[1]);

        Debug.Log(Investigate.GardenEelComponent.Instance.componentIDs[2]);



        skills.Add(null);
        coolDownTime.Add(0);
        skills.Add(skillDictionary[0]);
        coolDownTime.Add(skills[1].GetCoolDown());
        skillIconImages[0].sprite = skillSprites[0];


        skills.Add(skillDictionary[1]);
        coolDownTime.Add(skills[2].GetCoolDown());
        skillIconImages[1].sprite = skillSprites[1];

        skills.Add(skillDictionary[Investigate.GardenEelComponent.Instance.componentIDs[0]]);
        coolDownTime.Add(skills[3].GetCoolDown());
        skillIconImages[2].sprite = skillSprites[Mathf.Max(Investigate.GardenEelComponent.Instance.componentIDs[0], 0)];


        skills.Add(skillDictionary[Investigate.GardenEelComponent.Instance.componentIDs[1]]);
        coolDownTime.Add(skills[4].GetCoolDown());
        skillIconImages[3].sprite = skillSprites[Mathf.Max(Investigate.GardenEelComponent.Instance.componentIDs[1], 0)];


        skills.Add(skillDictionary[Investigate.GardenEelComponent.Instance.componentIDs[2]]);
        coolDownTime.Add(skills[5].GetCoolDown());
        skillIconImages[4].sprite = skillSprites[Mathf.Max(Investigate.GardenEelComponent.Instance.componentIDs[2], 0)];


        skillNumbers = new int[]{
            0,
            1,
            Mathf.Max(Investigate.GardenEelComponent.Instance.componentIDs[0], 1),
            Mathf.Max(Investigate.GardenEelComponent.Instance.componentIDs[1], 1),
            Mathf.Max(Investigate.GardenEelComponent.Instance.componentIDs[2], 1)
        };

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
        StartCoroutine(ShowEffect(skillIndex));
        whiteText = "";
        redText = "";
        currentText = "";
        UpdateText();
        coolDownTime[skillIndex] = 0;

    }

    IEnumerator ShowEffect(int index)
    {
        index -= 1;
        effectList[skillNumbers[index]].SetActive(true);
        yield return new WaitForSeconds(1);
        effectList[skillNumbers[index]].SetActive(false);
    }

}
