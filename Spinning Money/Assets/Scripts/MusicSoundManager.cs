using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundManager : MonoBehaviour
{
    public bool PlaySounds = true;



    public void StartGame(int play)
    {
        if(play == 0)
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
        if (PlaySounds)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }


    public void SetVolumeMute()
    {
        if(PlaySounds == true)
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
