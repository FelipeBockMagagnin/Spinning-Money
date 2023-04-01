using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSoundManager : MonoBehaviour
{
    public bool PlaySounds = true;
    public Image image;
    public Sprite soundON, soundOFF;



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
            image.sprite = soundON;
        }
        else
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("Audio", 0);
            image.sprite = soundOFF;
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
