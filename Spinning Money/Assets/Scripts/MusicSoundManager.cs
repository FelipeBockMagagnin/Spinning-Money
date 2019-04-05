using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundManager : MonoBehaviour
{
    public bool PlaySounds = true;


    /// <summary>
    /// if = 1 play music
    /// if = 0 dont play
    /// </summary>
    /// <param name="play"></param>
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

    /// <summary>
    /// check if can play the music
    /// </summary>
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

    /// <summary>
    /// button function
    /// </summary>
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
