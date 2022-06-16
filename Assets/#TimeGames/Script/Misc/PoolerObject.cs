using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames.Misc
{
    public class PoolerObject : MonoBehaviour
    {
        public PoolerContainer container { get; protected set; }

        public virtual void Init(PoolerContainer pool)
        {            
            container = pool;
            gameObject.SetActive(true);
        }

        protected virtual void OnEnable()
        {
            if (container)
                container.Remove(this);
        }

        protected virtual void OnDisable()
        {
            if (container)
                container.Add(this);
        }
    }
}