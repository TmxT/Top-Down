using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using TimeGames.Misc;

namespace TimeGames
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Space]
        public AudioMixer audioMixerBgm;
        public AudioMixer audioMixerSfx;

        private float lastBgmVolume;
        private float lastSfxVolume;

        private bool isBgmMuted;
        private bool isSfxMuted;

        [Space]
        public string paramBgmMixer = "BgmMixer";
        public string paramSfxMixer = "SfxMixer";

        /// <summary>
        /// value%
        /// </summary>
        public float AudioBgm
        {
            get
            {
                audioMixerBgm.GetFloat(paramBgmMixer, out float _value);
                return ToPercent(_value);
            }
            set
            {
                lastBgmVolume = FromPercent(value);
                audioMixerBgm.SetFloat(paramBgmMixer, lastBgmVolume);

                MuteBgm = lastBgmVolume == 0;
            }
        }

        /// <summary>
        /// value%
        /// </summary>
        public float AudioSfx
        {
            get
            {
                audioMixerSfx.GetFloat(paramSfxMixer, out float _value);
                return ToPercent(_value);
            }
            set
            {
                lastSfxVolume = FromPercent(value);
                audioMixerSfx.SetFloat(paramSfxMixer, lastSfxVolume);

                MuteSfx = lastSfxVolume == 0;
            }
        }

        public bool MuteBgm
        {
            get
            {
                return isBgmMuted;
            }
            set
            {
                isBgmMuted = value;

                if (isBgmMuted)
                {
                    lastBgmVolume = AudioBgm;
                    AudioBgm = 0;
                }
            }
        }

        public bool MuteSfx
        {
            get
            {
                return isSfxMuted;
            }
            set
            {
                isSfxMuted = value;

                if (isSfxMuted)
                {
                    lastSfxVolume = AudioSfx;
                    AudioSfx = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_value">Range 0 - 100</param>
        /// <returns></returns>
        private float ToPercent(float _value)
        {
            if (_value >= 80)
                return _value - 80;
            else
                return -80 + _value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_value">Range 0 - 100</param>
        /// <returns></returns>
        private float FromPercent(float _value)
        {
            return _value - 80;
        }

        public void Save()
        {
            //SaveSettings
        }
    }
}