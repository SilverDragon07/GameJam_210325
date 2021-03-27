using UnityEngine;
using System.Collections.Generic;

public class SoundController : SingletonMonoBehaviour<SoundController>
{
    Dictionary<string, AudioClip> BGMDic = new Dictionary<string, AudioClip>()
    {
        {"Title", null },
        {"Battle", null }
    };
    Dictionary<string, AudioClip> SEDic = new Dictionary<string, AudioClip>()
    {
        {"KomaHit", null }
    };
    [SerializeField] AudioSource BGMAudioSource = null;
    [SerializeField] AudioSource SEAudioSource = null;


    private void Start()
    {
        AudioClip audioClip;
        audioClip = Resources.Load<AudioClip>("Sounds/Title");
        BGMDic["Title"] = audioClip;
        audioClip = Resources.Load<AudioClip>("Sounds/Battle");
        BGMDic["Battle"] = audioClip;
        audioClip = Resources.Load<AudioClip>("Sounds/Komahit");
        SEDic["KomaHit"] = audioClip;
    }

    public void PlayBGM(string soundName)
    {
        BGMAudioSource.clip = BGMDic[soundName];
        BGMAudioSource.Play();
    }

    public void PlaySE(string soundName)
    {
        SEAudioSource.PlayOneShot(SEDic[soundName], 0.15f);
    }
}
