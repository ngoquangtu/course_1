using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public enum SoundType
    {
        BackgroundMusic,
        ButtonClick,
        GameOver,
        RightColorBox
    }
    public AudioSource backgroundMusicAudioSource;
    public AudioSource buttonClickAudioSource;
    public AudioSource gameOverAudioSource;
    public AudioSource RightColorBoxSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
           
        }
    }

    public void playSound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.BackgroundMusic:
                if (backgroundMusicAudioSource != null)
                {
                    backgroundMusicAudioSource.Play();
                }
                break;
            case SoundType.ButtonClick:
                if (buttonClickAudioSource != null)
                {
                    buttonClickAudioSource.Play();
                }
                break;
            case SoundType.GameOver:
                if (gameOverAudioSource != null)
                {
                    gameOverAudioSource.Play();
                }
                break;
            case SoundType.RightColorBox:
                if (gameOverAudioSource != null)
                {
                    RightColorBoxSource.Play();
                }
                break;
            default:
                break;
        }
    }
    public void stopSound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.BackgroundMusic:
                if (backgroundMusicAudioSource != null)
                {
                    backgroundMusicAudioSource.Stop();
                }
                break;
            case SoundType.ButtonClick:
                if (buttonClickAudioSource != null)
                {
                    buttonClickAudioSource.Stop();
                }
                break;
            case SoundType.GameOver:
                if (gameOverAudioSource != null)
                {
                    gameOverAudioSource.Stop();
                }
                break;
            case SoundType.RightColorBox:
                if (gameOverAudioSource != null)
                {
                    RightColorBoxSource.Stop();
                }
                break;
            default:
                break;
        }

    }
}
