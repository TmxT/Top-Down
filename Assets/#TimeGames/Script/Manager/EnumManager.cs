using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public enum EnumGame
    {
        New,
        Load,
        Pause,
        Resume,
        Battle,
        CutScene
    }

    public enum EnumSettings
    {
        Language
    }

    public enum EnumWorldTime
    {
        Day,
        Night
    }

    public enum EnumGateCondition
    {
        None,

        Open,
        Locked,
        Forbiden
    }

    public enum EnumHealthAction
    {
        Healed,
        Damaged,
        MagicIncreased,
        MagicUsed
    }

    public enum EnumInventoryAction
    {
        Changed,
        Used
    }

    public enum EnumPlayerAction
    {
        Level,
        Coin
    }

    public enum EnumKeyboardAction
    {
        None,

        Up,
        Down,
        Left,
        Right,
        Space,
        Enter,
        Escape
    }

    public enum EnumCursorPosition
    {
        None,

        MainMenu,

        ProfileInventoryTopBar,
        ProfileLeftBar,
        ProfileInventory,
        ProfileInventoryAction,
        ProfileEquipment,
        ProfileEquipmentStatus,
        ProfileStatus,
        ProfileSubMenu,
        
        Settings,

        Information,

        ShopItem,
        ShopQty,
        ShopBuy
    }

    public enum EnumEquipmentType
    {
        Weapon,
        Helmet,
        Armor,
        Boots,
        Gloves
    }

    public enum EnumPotionType
    {
        Poison,
        Regeneration,
        Resistance, 
        Strength,
        Luck,
        Booster
    }

    public enum EnumPoolerContainerName
    {
        None,

        Sign,
        ButtonShop,
        BubbleChat
    }

    public enum EnumGates
    {
        None,

        //Maps
        Sindreg,
        Bouven,
        Boleamo,
        Rappanggi,
        Nagekko,
        Yakimohu,
        Kurtcane,
        Kragile,
        Louent,
        Solobo,
        Makaripur,
        Weyntirea,
        Trighile,

        //Interior
        Home,
        First,
        Second,
        Third,
        FirstFloor,
        SecondFloor
    }

    public enum EnumTransitionName
    {
        NewGame,
        LoadingGame,
        Battle
    }

    public enum EnumSpecialAction
    {
        None,

        CanDisappeared,
        CanInteract
    }

    public enum EnumDisappearedType
    {
        None,

        In,
        Out,

        Both
    }

    public enum EnumInteractType
    {
        None,

        WithSeller,
        WithGuardians,
        WithBoard,
        WithGuild,
        WithVillager
    }

    public enum EnumNpc
    {
        None,

        Enemy,
        Seller,
        Villager,
        Guardians
    }

    public enum EnumObjectivesRequirement
    {
        None,

        GuildMaster_Objectives1,

        Master_Objectives2,
        Student_Objectives2,

        Guardian0_Objectives2,
        Guardian1_Objectives3,
        Guardian2_Objectives3,
        Guardian3_Objectives3,
        Object0_Objectives3,
        Object1_Objectives3,
        Object2_Objectives3,
        Object3_Objectives3,

        Headman_Objectives4,
        Villager_Objectives4,

        //Objectives5 => Menang melawan Bandit
    }

    public enum EnumLanguage
    {
        English,
        Bahasa
    }

    public enum EnumTag
    {
        None,

        Untagged,
        Player,
        Props,
        SignTrigger,
        Zombie,
        Villager,
        Seller
    }

    public enum EnumWeaponType
    {
        Sword,
        Spear,
        Bow,
        WizardStaff
    }

    public enum EnumSortType
    {
        All, 

        Food,
        Potion,
        Equipment
    }

    public enum EnumAnimName_Button
    {
        Button_Selected,
        Button_Deselected,
        Button_Special_Deselected
    }

    public enum EnumAnimName_Player
    {
        Player_Idle,
        Player_Walk_Down,
        Player_Walk_Left,
        Player_Walk_Right,
        Player_Walk_Up
    }

    public enum EnumStat
    {
        Atk,
        Def,
        Agi,
        Vit,
        Int,
        Dex,
        Luk
    }

    public enum EnumDirector
    {
        MainMenu,
        Player,
        Objectives
    }

    public enum EnumItemRank
    {
        A,
        B,
        C,
        D,
        E
    }

    public enum EnumPanelProfileComponent
    {
        Equipment,
        EquipmentStatus,
        PlayerStatus,
        SubMenu,
        Settings,
        InventoryDetail
    }
}