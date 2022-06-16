using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using TMPro;

namespace TimeGames.Misc
{
    public class TextBase : MonoBehaviour
    {
        public TextMeshProUGUI text;

        [Space]
        public string bahasa;
        public string english;

        private void Start()
        {
            if(!text)
                text = GetComponent<TextMeshProUGUI>();
        }
    }

    [CanEditMultipleObjects]
    [CustomEditor(typeof(TextBase), true)]
    public class EditorTextBase : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            TextBase textBase = (TextBase)target;

            if (textBase.text)
                textBase.text.text = textBase.english;
        }
    }
}