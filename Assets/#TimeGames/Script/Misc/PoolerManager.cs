using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Misc
{
    public class PoolerManager : MonoBehaviour
    {
        public static PoolerManager Instance;

        public PoolerContainer[] listPoolerContainer;

        private void Awake()
        {
            Instance = this;
        }

        public PoolerContainer GetPoolerContainer(EnumPoolerContainerName _containerName)
        {
            foreach(PoolerContainer _container in listPoolerContainer)
                if(_container.poolerName == _containerName)
                    return _container;

            return null;
        }
    }
}