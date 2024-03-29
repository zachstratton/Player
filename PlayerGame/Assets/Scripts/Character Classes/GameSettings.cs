﻿using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour { 

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveCharaterData()
    {
        GameObject pc = GameObject.Find("pc");

        PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

        PlayerPrefs.DeleteAll();  //******** THIS IS DELETEING ALL PREFS AT START ***************

        PlayerPrefs.SetString("Player Name", pcClass.Name);

        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+ " - Base Value", pcClass.GetPrimaryAttribute(cnt).BaseValue);
            PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " - Exp To Level", pcClass.GetPrimaryAttribute(cnt).ExpToLevel);

        }

        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
        {
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Base Value", pcClass.GetVital(cnt).BaseValue);
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Exp To Level", pcClass.GetVital(cnt).ExpToLevel);
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Cur Value", pcClass.GetVital(cnt).CurValue);

            PlayerPrefs.SetString(((VitalName)cnt).ToString() + " - Mods", pcClass.GetSkill(cnt).GetModifyingAttributesString());

        }

        for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++)
        {
            PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " - Base Value", pcClass.GetSkill(cnt).BaseValue);
            PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " - Exp To Level", pcClass.GetSkill(cnt).ExpToLevel);

            PlayerPrefs.SetString(((SkillName)cnt).ToString() + " - Mods", pcClass.GetSkill(cnt).GetModifyingAttributesString());

        }
    }

     public void LoadCharacterData()
    {

    }
}
