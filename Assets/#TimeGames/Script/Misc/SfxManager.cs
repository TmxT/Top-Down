using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TimeGames.Misc
{

    public enum EnumSfx
    {
        BtnClick
    }

    public class SfxManager : Singleton<SfxManager>
    {
        public AudioMixerGroup sfxMixerGroup;

        [Space]
        private List<EnumSfx> listEnumSfx = new List<EnumSfx>();
        public Sfx[] listSfx;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            foreach (Sfx _sfx in listSfx)
            {
                _sfx.Initialize();
                _sfx.audioSource.transform.parent = transform;

                listEnumSfx.Add(_sfx.sfx);
            }
        }

        public void Play(EnumSfx _sfx)
        {
            listSfx[listEnumSfx.IndexOf(_sfx)].Play();
        }
    }

    [System.Serializable]
    public class Sfx
    {
        public EnumSfx sfx;

        [Space]
        public AudioClip audioClip;

        [Header("Settings")]
        public bool playOnAwake;
        public bool loop;

        [HideInInspector]
        public AudioSource audioSource;

        public void Initialize()
        {
            audioSource = new GameObject().AddComponent<AudioSource>();
            audioSource.name = string.Format($"SFX - {sfx}");

            audioSource.clip = audioClip;
            audioSource.playOnAwake = playOnAwake;
            audioSource.loop = loop;
            audioSource.outputAudioMixerGroup = SfxManager.Instance.sfxMixerGroup;
        }

        public void Play()
        {
            audioSource.Play();
        }

        public void Pause()
        {
            audioSource.Stop();
        }
    }
}