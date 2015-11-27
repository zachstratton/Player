﻿using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour {
    private string _name;
    private int _level;
    private uint _freeExp;

    private Attribute[] _primaryAttribute;
    private Vital[] _vital;
    private Skill[] _skill;

    public void Awake()
    {
        _name = string.Empty;
        _level = 0;
        _freeExp = 0;

        _primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        _vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        _skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

        SetupPrimaryAttributes();
        SetupVitals();
        SetupSkills();
    }


    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public uint FreeExp
    {
        get { return _freeExp; }
        set { _freeExp = value; }
    }

    public void AddExp(uint exp)
    {
        _freeExp += exp;

        CalculateLevel();
    }

    //take avg of all skill = player level
    public void CalculateLevel()
    {

    }

    private void SetupPrimaryAttributes()
    {
        for(int cnt = 0; cnt < _primaryAttribute.Length; cnt++)
        {
            _primaryAttribute[cnt] = new Attribute();
            _primaryAttribute[cnt].Name = ((AttributeName)cnt).ToString();
        
        }
    }

    private void SetupVitals()
    {
        for (int cnt = 0; cnt < _vital.Length; cnt++)
            _vital[cnt] = new Vital();

        SetupVitalModifiers();
        
    }

    private void SetupSkills()
    {
        for (int cnt = 0; cnt < _skill.Length; cnt++)
        _skill[cnt] = new Skill();

        SetupSkillModifiers();
        
    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return _primaryAttribute[index];
    }

    public Vital GetVital(int index)
    {
        return _vital[index];
    }

    public Skill GetSkill(int index)
    {
        return _skill[index];
    }

    private void SetupVitalModifiers()
    {
        //health
        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute { attribute = GetPrimaryAttribute((int)AttributeName.Vitality), ratio = .5f });
        //energy
        GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute { attribute = GetPrimaryAttribute((int)AttributeName.Endurance), ratio = 1f });


    }

    private void SetupSkillModifiers()
    {
        //melee offence
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .33f));
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Accuracy), .33f));
        //melee defence
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .33f));
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Defense), .33f));
        //magic offence
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intellect), .33f));
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Accuracy), .33f));
        //magic defence
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vitality), .33f));
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intellect), .33f));
        //range offence
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .33f));
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .33f));
        //range defence
        GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .33f));
        GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .33f));
    }

    public void StatUpdate()
    {
        for (int cnt = 0; cnt < _vital.Length; cnt++)
            _vital[cnt].Update();

        for (int cnt = 0; cnt < _skill.Length; cnt++)
            _skill[cnt].Update();
    }
}
