using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour {
    private PlayerCharacter _toon;
    private const int StartingPoints = 350;
    private const int MinStartingAttributeValue = 10;
    private const int StartValue = 50;
    private int pointsLeft;

    private const int OFFSET = 5;
    private const int LINE_HEIGHT = 20;

    private const int STAT_LABEL_WIDTH = 100;
    private const int BASEVALUE_LABEL_WIDTH = 30;

    private const int BUTTON_WIDTH = 25;
    private const int BUTTON_HEIGHT = 25;

    private int statStartingPos = 40;

    public GUISkin mySkin;

    public GameObject playerPrefab;

    // Use this for initialization
    void Start () {
        GameObject pc = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        pc.name = "pc";

        _toon = pc.GetComponent<PlayerCharacter>();

        pointsLeft = StartingPoints;
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            _toon.GetPrimaryAttribute(cnt).BaseValue = StartValue;
            pointsLeft -= (StartValue - MinStartingAttributeValue);
        }
        _toon.StatUpdate();

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {

        DisplayName();
        DisplayPointLeft();
        DisplayAttributes();
        DisplayVitals();
        DisplaySkills();

        if(_toon.Name == "" || pointsLeft > 0)
            DisplayCreateLabel();
        else
            DisplayCreateButton();

    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name:");
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
    }

    private void DisplayAttributes()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            GUI.Label(new Rect( OFFSET,                                 //x
                                statStartingPos + (cnt * LINE_HEIGHT),  //y
                                STAT_LABEL_WIDTH,                       //width
                                LINE_HEIGHT                             //height
                                ), ((AttributeName)cnt).ToString());

            GUI.Label(new Rect( STAT_LABEL_WIDTH + OFFSET,              //x
                                statStartingPos + (cnt * LINE_HEIGHT),  //y
                                BASEVALUE_LABEL_WIDTH,                  //width
                                LINE_HEIGHT),                           //height
                                _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());

            if(GUI.Button(new Rect( OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH,  //x
                                    statStartingPos + (cnt * BUTTON_HEIGHT),            //y
                                    BUTTON_WIDTH,                                       //width                                      
                                    BUTTON_HEIGHT),                                     //height
                                    "-"))
            {
                if (_toon.GetPrimaryAttribute(cnt).BaseValue > MinStartingAttributeValue)
                {
                    _toon.GetPrimaryAttribute(cnt).BaseValue--;
                    pointsLeft++;
                    _toon.StatUpdate();
                }
            }
            if(GUI.Button(new Rect( STAT_LABEL_WIDTH + OFFSET + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH,   //xx
                                    statStartingPos + (cnt * BUTTON_HEIGHT),                            //y
                                    BUTTON_WIDTH,                                                       //width
                                    BUTTON_HEIGHT),                                                     //height
                "+"))
            {
                if(pointsLeft > 0)
                {
                    _toon.GetPrimaryAttribute(cnt).BaseValue++;
                    pointsLeft--;
                    _toon.StatUpdate();
                }
            }
        }
    }

    private void DisplayVitals()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
        {
            GUI.Label(new Rect(OFFSET, statStartingPos + ((cnt + 9) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalName)cnt).ToString());
            GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH, statStartingPos + ((cnt + 9) * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetVital(cnt).AdjustedBaseValue.ToString());
        }
    }

    private void DisplaySkills()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++)
        {
            GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2, statStartingPos + (cnt * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName)cnt).ToString());
            GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2 + STAT_LABEL_WIDTH, statStartingPos + (cnt * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetSkill(cnt).AdjustedBaseValue.ToString());
        }
    }
    
    private void DisplayPointLeft()
    {
        GUI.Label(new Rect(250, 10, 100, 25), "Points left: " + pointsLeft.ToString());
    }

    private void DisplayCreateLabel()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50,                               //x
                        statStartingPos + (10 * LINE_HEIGHT),                   //y
                        100,                                                    //width
                        LINE_HEIGHT                                             //height
                   ), "Create Character", "Button");
    }

    private void DisplayCreateButton()
    {
        if(GUI.Button(new Rect( Screen.width/ 2 - 50,                                   //x
                                statStartingPos + (10 * LINE_HEIGHT),                   //y
                                100,                                                    //width
                                LINE_HEIGHT                                             //height
                           ), "Create Character"))
        {
            GameObject gs = GameObject.Find("__GameSettings");
            GameSettings gsScript = GameObject.Find("__GameSettings").GetComponent<GameSettings>();

            UpdateCurVitalValues();

            gsScript.SaveCharaterData();
            Application.LoadLevel("Player");
        }           
    }

    private void UpdateCurVitalValues()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
        {
            _toon.GetVital(cnt).CurValue = _toon.GetVital(cnt).AdjustedBaseValue;
        }
    }
}
