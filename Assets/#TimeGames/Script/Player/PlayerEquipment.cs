using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Object;
using TimeGames.Misc;

namespace TimeGames
{
    public class PlayerEquipment : Singleton<PlayerEquipment>, IEventGame
    {
        public Equipment weapon { get; set; }
        public Equipment helmet { get; set; }
        public Equipment armor { get; set; }
        public Equipment boots { get; set; }
        public Equipment gloves { get; set; }

        [Header("New Game")]
        public ObjectItemEquipment initWeapon;
        public ObjectItemEquipment initHelmet;
        public ObjectItemEquipment initArmor;
        public ObjectItemEquipment initBoots;
        public ObjectItemEquipment initGloves;

        private void NewGame()
        {
            weapon = new Equipment(
                initWeapon.GetListStat(),
                initWeapon.icon,
                initWeapon.rank,
                initWeapon.type,
                initWeapon.itemName,
                initWeapon.desc,
                initWeapon.maxStrength
                );

            helmet = new Equipment(
                initHelmet.GetListStat(),
                initHelmet.icon,
                initHelmet.rank,
                initHelmet.type,
                initHelmet.itemName,
                initHelmet.desc,
                initHelmet.maxStrength
                );
            
            armor = new Equipment(
                initArmor.GetListStat(),
                initArmor.icon,
                initArmor.rank,
                initArmor.type,
                initArmor.itemName,
                initArmor.desc,
                initArmor.maxStrength
                );

            boots = new Equipment(
                initBoots.GetListStat(),
                initBoots.icon,
                initBoots.rank,
                initBoots.type,
                initBoots.itemName,
                initBoots.desc,
                initBoots.maxStrength
                );

            gloves = new Equipment(
                initGloves.GetListStat(),
                initGloves.icon,
                initGloves.rank,
                initGloves.type,
                initGloves.itemName,
                initGloves.desc,
                initGloves.maxStrength
                );
        }

        public void ChangeEquipment(EnumEquipmentType _type, Equipment _equipment)
        {
            switch (_type)
            {
                case EnumEquipmentType.Weapon:
                    weapon = _equipment;
                    break;

                case EnumEquipmentType.Helmet:
                    helmet = _equipment;
                    break;

                case EnumEquipmentType.Armor:
                    armor = _equipment;
                    break;

                case EnumEquipmentType.Boots:
                    boots = _equipment;
                    break;

                case EnumEquipmentType.Gloves:
                    gloves = _equipment;
                    break;
            }
        }

        public void OnEventGame(EnumGame _game)
        {
            if (_game == EnumGame.New)
                NewGame();
        }

        private void OnEnable()
        {
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventGame.Instance.RemoveListener(OnEventGame);
        }
    }
}