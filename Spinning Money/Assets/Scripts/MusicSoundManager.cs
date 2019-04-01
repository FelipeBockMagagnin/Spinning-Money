using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundManager : MonoBehaviour
{
    public bool PlaySounds = true;



    public void StartGame(int play)
    {
        if (play == 0)
        {
            PlaySounds = false;
        }
        else
        {
            PlaySounds = true;
        }
        CheckGameSounds();
    }


    public void CheckGameSounds()
    {
        if (PlaySounds == true)
        {
            AudioListener.pause = false;
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Audio", 1);
        }
        else
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("Audio", 0);
        }
    }


    public void SetVolumeMute()
    {
        if (PlaySounds == true)
        {
            PlaySounds = false;
        }
        else
        {
            PlaySounds = true;
        }
        CheckGameSounds();
    }


}
