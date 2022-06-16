using System;
using UnityEngine;

namespace TimeGames.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class GroupAttribute : PropertyAttribute
    {
        public string GroupName;
        public bool GroupAllFieldsUntilNextGroupAttribute;
        public int GroupColorIndex;

        public GroupAttribute(string _groupName, bool _groupAllFieldsUntilNextGroupAttribute = false, int _groupColorIndex = 24)
        {
            if (_groupColorIndex > 139)
                _groupColorIndex = 139;

            GroupName = _groupName;
            GroupAllFieldsUntilNextGroupAttribute = _groupAllFieldsUntilNextGroupAttribute;
            GroupColorIndex = _groupColorIndex;
        }
    }
}