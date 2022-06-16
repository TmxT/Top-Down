using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TimeGames
{
    public class Director : MonoBehaviour
    {
        public EnumDirector director;

        [Space]
        public PlayableDirector[] listDirector;

        [Space]
        public bool loop;

        [Header("Reference")]
        private DirectorManager directorManager;

        private void Start()
        {
            directorManager = DirectorManager.Instance;
        }

        public IEnumerator CoroutinePlay()
        {
            float duration;

            foreach (PlayableDirector _director in listDirector)
            {
                duration = (float)_director.duration;

                _director.gameObject.SetActive(true);
                _director.Play();

                while (duration > 0)
                {
                    duration -= Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}