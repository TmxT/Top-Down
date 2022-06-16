using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class Follow : MonoBehaviour
    {
        private Transform target;

        private void Start()
        {
            //target = GameManager.Instance.GetObjPlayer().transform;
        }

        private void Update()
        {
            transform.position = target.position;
        }
    }
}