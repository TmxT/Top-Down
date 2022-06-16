using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames.Object
{
    [CreateAssetMenu(fileName = "Equipment ", menuName = "Item/Equipment")]
    public class ObjectItemEquipment : ObjectItemBase
    {
        [Space]
        public EnumEquipmentType type;

        [Space]
        public EnumItemRank rank;

        [Space]
        public int maxStrength;

        public void Generate()
        {
            switch (rank)
            {
                case EnumItemRank.A:
                    price = Random.Range(80, 100);
                    maxQty = Random.Range(1, 2);
                    maxStrength = Random.Range(800, 1000);
                    GenerateStat(80, 100);
                    break;

                case EnumItemRank.B:
                    price = Random.Range(60, 80);
                    maxQty = Random.Range(3, 4);
                    maxStrength = Random.Range(600, 800);
                    GenerateStat(60, 80);
                    break;

                case EnumItemRank.C:
                    price = Random.Range(40, 60);
                    maxQty = Random.Range(5, 6);
                    maxStrength = Random.Range(400, 600);
                    GenerateStat(40, 60);
                    break;

                case EnumItemRank.D:
                    price = Random.Range(20, 40);
                    maxQty = Random.Range(7, 8);
                    maxStrength = Random.Range(200, 400);
                    GenerateStat(20, 40);
                    break;

                case EnumItemRank.E:
                    price = Random.Range(1, 20);
                    maxQty = Random.Range(9, 10);
                    maxStrength = Random.Range(100, 200);
                    GenerateStat(1, 20);
                    break;
            }

            void GenerateStat(int _min, int _max)
            {
                ATK = Random.Range(_min, _max);
                AGI = Random.Range(_min, _max);
                INT = Random.Range(_min, _max);
                DEF = Random.Range(_min, _max);
                VIT = Random.Range(_min, _max);
                DEX = Random.Range(_min, _max);
                LUK = Random.Range(_min, _max);
            }
        }
    }
}