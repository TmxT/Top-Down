using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames.Object
{
    [CreateAssetMenu(fileName = "Food ", menuName = "Item/Food")]
    public class ObjectItemFood : ObjectItemBase
    {
        [Space]
        public int hungry;
    }
}