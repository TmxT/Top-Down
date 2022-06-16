using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            GameObject sameObject = GameObject.Find(gameObject.name);

            DontDestroyOnLoad(gameObject);

            if (sameObject)
                Destroy(gameObject);
        }
    }
}