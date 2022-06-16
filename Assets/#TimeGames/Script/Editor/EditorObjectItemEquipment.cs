using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using TimeGames.Object;

namespace TimeGames.CustomEditor
{
    [UnityEditor.CustomEditor(typeof(ObjectItemEquipment))]
    public class EditorObjectItemEquipment : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ObjectItemEquipment equipment = (ObjectItemEquipment)target;

            GUILayout.Space(25f);
            if (GUILayout.Button("Generate"))
            {
                equipment.Generate();
                Save(equipment);
            }
        }

        private void Save(ObjectItemEquipment _target)
        {
            EditorUtility.SetDirty(_target);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}