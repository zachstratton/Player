﻿public class Attribute : BaseStat
{
    private string _name;

    public Attribute()
    {
        _name = "";
        ExpToLevel = 50;
        LevelModifier = 1.05f;
    }

    public string Name
{
    get { return _name; }
    set { _name = value; }

}
}

public enum AttributeName
{
    Accuracy,
    Defense,
    Vitality,
    Intellect,
    Dexterity,
    Strength,
    Endurance,
    Crit
}
