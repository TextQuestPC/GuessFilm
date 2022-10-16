using UnityEngine;
using System;
namespace Core
{
    [CreateAssetMenu(fileName = "SCRO_AudioManager", menuName = "Managers/AudioManager")]
    public class AudioManager : BaseManager
    {
        [SerializeField] private AudioClip[] audioClips;
        [SerializeField] private AudioSource source;



        private AuidoData data;
        private SaveLoadManager save;



        public void PlaySound(int index)
        {
            source.PlayOneShot(audioClips[index], 1);
        }
        public void MuteSound(int index)
        {
            source.clip = audioClips[index];
            source.Pause();
            source.mute = true;
        }

        public override void OnStart()
        {
            source = (new GameObject()).AddComponent<AudioSource>();
            source.gameObject.name = "Audio";
            PlaySound(0);
            save = BoxManager.GetManager<SaveLoadManager>();
            //data = save.Load<AuidoData>("AudioManager");
        }
        public override void OnInitialize()
        {
            base.OnInitialize();
        }
        private void OnDestroy()
        {
            //save.Save("AudioManager",data);
        }
    }

    [Serializable]
    public class AuidoData
    {
        public float volume;
        public int soundIndex;
        public float moment;

    }
}
