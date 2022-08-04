using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Sound Manager")]
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] SoundSprite;

    [SerializeField]
    Sprite[] MusicSprite;

    public AudioSource[] allAudio;

    public AudioSource bgMusic;

    MenuController menuController;

    private void OnEnable()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSoundSprites();
        ManageAudioVolume();
        SetMusicSprites();
        ManageBGVolume();
    }
    
    public void ChangeSoundPreference()
    {
        if(GamePreferences.Sound==0)
        {
            GamePreferences.Sound = 1;
        }
        else
        {
            GamePreferences.Sound = 0;
        }
        SetSoundSprites();
        ManageAudioVolume();
    }

    public void ChangeMusicPreference()
    {
        if (GamePreferences.Music == 0)
        {
            GamePreferences.Music = 1;
        }
        else
        {
            GamePreferences.Music = 0;
        }
        SetMusicSprites();
        ManageBGVolume();
    }

    public void SetSoundSprites()
    {
        menuController.Sound.sprite = SoundSprite[GamePreferences.Sound];
    }

    public void SetMusicSprites()
    {
        menuController.Music.sprite = MusicSprite[GamePreferences.Music];
    }

    public void ManageAudioVolume()
    {
        if (GamePreferences.Sound == 0)
        {
            foreach (AudioSource _AS in allAudio)
            {
                _AS.mute = true;
            }
        }
        else if(GamePreferences.Sound==1)
        {
            foreach (AudioSource _AS in allAudio)
            {
                _AS.mute = false;
            }
        }
    }

    public void ManageBGVolume()
    {
        if (GamePreferences.Music == 0)
        {
            bgMusic.mute = true;
        }
        else if (GamePreferences.Music == 1)
        {
            bgMusic.mute = false;
        }
    }
}