using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames.Object
{
    public class ObjectItemBase : ScriptableObject
    {
        private List<int> listStat = new List<int>();

        public Sprite icon;

        [Space]
        public string itemName;
        [TextArea(2, 4)]
        public string desc;

        [Space]
        public int price;
        [Space]
        public int maxQty;
        [Space]
        public int ATK;
        public int DEF;
        public int AGI;
        public int VIT;
        public int INT;
        public int DEX;
        public int LUK;
        [Space]
        public int HP;
        public int MP;

        public int[] GetListStat()
        {
            if (listStat.Count == 0)
            {
                listStat.Add(ATK);
                listStat.Add(DEF);
                listStat.Add(AGI);
                listStat.Add(VIT);
                listStat.Add(INT);
                listStat.Add(DEX);
                listStat.Add(LUK);
            }

            return listStat.ToArray();
        }
    }
}