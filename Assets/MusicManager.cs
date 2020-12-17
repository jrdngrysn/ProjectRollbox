using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager main;

    public AudioSource[] aSrcs;
    public float masterVolume;

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

    

    public void UpdateMusicVolume()
    {
        masterVolume = SettingsManager.main.musicVolume;
        foreach (var src in aSrcs)
        {
            src.volume = masterVolume;
        }
    }
}
