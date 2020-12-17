using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager main;

    public float masterVolume;
    public AudioSource[] shortAudioSources;
        int shortSrcIndex;


    public enum SelectSound
    {
        DefaultClick,
        HardClick,
        GoBack
    }
    public AudioClip[] selectSounds;

    private void Awake()
    {
        if (main != null && main != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            main = this;
            DontDestroyOnLoad(this);
        }
    }


    public void PlaySelectSound(SelectSound selectSound, float vol)
    {
        shortSrcIndex = (shortSrcIndex + 1) % shortAudioSources.Length;
        shortAudioSources[shortSrcIndex].PlaySound(selectSounds[(int)selectSound], vol, .05f);
    }


    public void UpdateVolume()
    {
        masterVolume = SettingsManager.main.soundVolume;
    }

}
