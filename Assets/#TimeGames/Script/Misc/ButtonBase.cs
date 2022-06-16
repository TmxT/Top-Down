using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TimeGames.Misc
{
    public class ButtonBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private enum EnumAnimButton
        {
            Selected,
            Deselected
        }

        [Header("Button")]
        public Image imgTargetGraphic;

        public bool sprite;
        public Sprite spriteClick;
        public Sprite spriteHover;
        private Sprite spriteDefault;

        public bool color;
        public Color32 colorClick;
        public Color32 colorHover;
        public Color32 colorDefault;

        [Space]
        public OnClickTrigger onClick;

        [Space]
        public Animator anim;

        public int id { get; protected set; }

        protected virtual void Start()
        {
            if(!imgTargetGraphic)
                imgTargetGraphic = GetComponent<Image>();

            Initialize();
        }

        protected virtual void Initialize()
        {
            spriteDefault = imgTargetGraphic.sprite;
            colorDefault = imgTargetGraphic.color;
        }

        public void SetId(int _id)
        {
            id = _id;
        }

        public virtual void PointerClick()
        {
            ChangeSprite(spriteClick);
            ChangeColor(colorClick);

            PointerEnter();

            onClick?.Invoke();
        }

        public virtual void PointerEnter()
        {
            ChangeSprite(spriteHover);
            ChangeColor(colorHover);

            anim?.Play(EnumAnimButton.Selected.ToString());
        }

        public virtual void PointerExit()
        {
            ChangeSprite(spriteDefault);
            ChangeColor(colorDefault);

            anim?.Play(EnumAnimButton.Deselected.ToString());
        }

        public virtual void OnButtonSelected(ButtonBase _btn)
        {
            if (_btn == this)
                return;

            PointerExit();
        }

        private void ChangeSprite(Sprite _spriteChange)
        {
            if (!sprite)
                return;

            imgTargetGraphic.sprite = _spriteChange;
        }

        private void ChangeColor(Color32 _colorChange)
        {
            if (!color)
                return;

            imgTargetGraphic.color = _colorChange;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExit();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClick();
        }
    }

    [System.Serializable]
    public class OnClickTrigger : UnityEvent { }

    [CanEditMultipleObjects]
    [CustomEditor(typeof(ButtonBase), true)]
    public class EditorButtonBase : Editor
    {
        //Button
        private SerializedProperty sprite, spriteClick, spriteHover;

        private SerializedProperty color, colorClick, colorHover;

        private SerializedProperty imgTargetGraphic;
        private SerializedProperty anim;
        private SerializedProperty onClick;

        private void OnEnable()
        {
            sprite = serializedObject.FindProperty("sprite");
            spriteClick = serializedObject.FindProperty("spriteClick");
            spriteHover = serializedObject.FindProperty("spriteHover");

            color = serializedObject.FindProperty("color");
            colorClick = serializedObject.FindProperty("colorClick");
            colorHover = serializedObject.FindProperty("colorHover");

            imgTargetGraphic = serializedObject.FindProperty("imgTargetGraphic");
            anim = serializedObject.FindProperty("anim");
            onClick = serializedObject.FindProperty("onClick");
        }

        public override void OnInspectorGUI()
        {
            ButtonBase buttonBase = (ButtonBase)target;

            serializedObject.Update();

            EditorGUILayout.PropertyField(imgTargetGraphic);
            EditorGUILayout.PropertyField(anim);

            GUILayout.Space(10f);

            EditorGUILayout.PropertyField(sprite);
            if (buttonBase.sprite)
            {
                EditorGUILayout.PropertyField(spriteClick);
                EditorGUILayout.PropertyField(spriteHover);
            }

            GUILayout.Space(10f);

            EditorGUILayout.PropertyField(color);
            if (buttonBase.color)
            {
                EditorGUILayout.PropertyField(colorClick);
                EditorGUILayout.PropertyField(colorHover);
            }

            GUILayout.Space(10f);

            EditorGUILayout.PropertyField(onClick);

            serializedObject.ApplyModifiedProperties();
        }
    }
}