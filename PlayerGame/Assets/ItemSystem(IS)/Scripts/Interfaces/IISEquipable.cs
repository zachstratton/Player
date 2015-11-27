using UnityEngine;
using System.Collections;

namespace Triangle.ItemSystem
{
    public interface IISEquipable
    {
        ISEquipmentSlot EquipmentSlot { get; }
        bool Equip();
	}
}
