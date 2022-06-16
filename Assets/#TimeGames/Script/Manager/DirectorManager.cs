using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class DirectorManager : MonoBehaviour
    {
        public static DirectorManager Instance { get; private set; }

        public Director[] listDirector;

        private void Awake()
        {
            Instance = this;
        }
    }
}