using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class Equipment
    {
        public int[] listStat { get; private set; }

        public Sprite icon { get; private set; }

        public EnumItemRank rank { get; private set; }

        public EnumEquipmentType type { get; private set; }

        public string itemName { get; private set; }
        public string desc { get; private set; }

        public int strength { get; private set; }

        public int maxStrength { get; private set; }

        public Equipment(int[] _listStat, Sprite _icon, EnumItemRank _rank, EnumEquipmentType _type, string _itemName, string _desc, int _strength)
        {
            listStat = _listStat;
            icon = _icon;
            rank = _rank;
            type = _type;
            itemName = _itemName;
            desc = _desc;
            strength = _strength;
            maxStrength = _strength;
        }
    }
}