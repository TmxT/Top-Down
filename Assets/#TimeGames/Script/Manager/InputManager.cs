using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;

namespace TimeGames
{
    public class InputManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                EventKeyboard.Instance.Invoke(EnumKeyboardAction.Up);

            if (Input.GetKeyDown(KeyCode.DownArrow))
                EventKeyboard.Instance.Invoke(EnumKeyboardAction.Down);

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                EventKeyboard.Instance.Invoke(EnumKeyboardAction.Left);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                EventKeyboard.Instance.Invoke(EnumKeyboardAction.Right);

            if (Input.GetKeyDown(KeyCode.Space))
                EventKeyboard.Instance.Invoke(EnumKeyboardAction.Space);

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
                EventKeyboard.Instance.Invoke(EnumKeyboardAction.Enter);

            if (Input.GetKeyDown(KeyCode.Escape))
                EventKeyboard.Instance.Invoke(EnumKeyboardAction.Escape);
        }
    }
}