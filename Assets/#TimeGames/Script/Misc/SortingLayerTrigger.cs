using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames.Misc
{
    public class SortingLayerTrigger : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;

        private void OnTriggerEnter2D(Collider2D _col)
        {
            if(_col.CompareTag(EnumTag.Player.ToString()) || _col.CompareTag(EnumTag.Seller.ToString()) || _col.CompareTag(EnumTag.Villager.ToString()))
                spriteRenderer.sortingOrder = 1;
        }

        private void OnTriggerExit2D(Collider2D _col)
        {
            if (_col.CompareTag(EnumTag.Player.ToString()) || _col.CompareTag(EnumTag.Seller.ToString()) || _col.CompareTag(EnumTag.Villager.ToString()))
                spriteRenderer.sortingOrder = 0;
        }
    }
}