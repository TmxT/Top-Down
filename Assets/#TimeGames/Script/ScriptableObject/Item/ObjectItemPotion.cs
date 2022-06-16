using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames.Object
{
    [CreateAssetMenu(fileName = "Potion ", menuName = "Item/Potion")]
    public class ObjectItemPotion : ObjectItemBase
    {
        public EnumPotionType type;

        [Space]
        public bool antiPoison;
    }
}