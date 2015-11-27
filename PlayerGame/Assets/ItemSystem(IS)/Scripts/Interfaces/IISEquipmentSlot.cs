using UnityEngine;
using System.Collections;

namespace Triangle.ItemSystem
{
    public interface IISEquipmentSlot
    {
	    string Name { get; set; }
        Sprite Icon { get; set; }
	}
}
