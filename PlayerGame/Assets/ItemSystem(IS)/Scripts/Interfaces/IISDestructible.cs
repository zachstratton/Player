using UnityEngine;
using System.Collections;

namespace Triangle.ItemSystem
{
    public interface IISDestructible
    {
        int Durability { get; }
        int MaxDurability { get; }
        void TakeDamage(int amount);
        void Repair();
        void Break();
    }
}
