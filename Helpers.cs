using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using Audio;

namespace Utilities {
    public class Helpers : MonoBehaviour {
        private static Camera _camera;
        [SerializeField] static public DamagePopup damagePopup;
        public static Camera Camera { get => _camera; private set => _camera = value; }

        private void Awake() {
            _camera = Camera.main;
        }

        public static void CreateDamagePopup(float damage, Vector2 position, DisplayMode displayMode = DisplayMode.Normal) {
            Instantiate(damagePopup).Init(damage, position, displayMode);
        }

        public static AudioMixerGroup GetMixerGroupFromChannel(SoundChannel channel) {
            return channel switch {
                SoundChannel.BGM => Globals.I.bgmMixer,
                SoundChannel.NORMAL => Globals.I.sfxMixer,
                SoundChannel.GLOBAL => Globals.I.globalMixer,
                _ => Globals.I.globalMixer
            };
        }
    }

    public enum DisplayMode { Normal, Impact }
}
