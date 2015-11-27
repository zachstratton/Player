using UnityEngine;
using System.Collections;


namespace Triangle.ItemSystem
{
    [System.Serializable]
    public class ISQuality : IISQuality
    {
        [SerializeField]
        Sprite _icon;
        [SerializeField]
        string _name;


        public ISQuality()
        {
            _icon = new Sprite();
            _name = "";
        }

        public ISQuality(string name, Sprite icon)
        {
            _name = name;
            _icon = icon;
        }

        public Sprite Icon
        {
            get { return _icon; }

            set { _icon = value; }
        }


        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }
    }
}
