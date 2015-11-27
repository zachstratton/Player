using UnityEngine;
using System.Collections;


namespace Triangle.ItemSystem
{
    public interface IISObject
    {

        //name
        //value
        //icon
        //burden
        //qualitylevel
        string Name { get; set; }
        int Value { get; set; }
        Sprite Icon { get; set; }
        int Burden { get; set; }
        ISQuality Quality { get; set; }



        //equip
        //questItem flag
        //durability
        //takedamage
        //prefab

    }
}
