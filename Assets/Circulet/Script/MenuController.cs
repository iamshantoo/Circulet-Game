using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("UI/Menu Controller")]
public class MenuController : MonoBehaviour
{
    #region Public Variables
    [SerializeField]
    GameObject ExitPanel;

    [Header("UI Objects")]
    public Image Sound;
    public Image Music;
    public Text HighScoreText;
    #endregion

    #region Event Functions
    private void Awake()
    {
        GarbageCollectionManager.DisableGC();
        InitializeGameForFirstPlay();
    }
    private void OnEnable()
    {
        Time.timeScale = 1f;
        InitializeGame();
    }

    private void Update()
    {
        //Keep second condition, if your menu & gameplay are in the same scene
        //Debug.Log("Playing Mode " + TheGlobals.playingMode);
        if (Input.GetKeyDown(KeyCode.Escape) && !TheGlobals.playingMode)
        {
            //uncomment this when you are ready with your exit panel
            OnBackClick();
        }
    }
    #endregion

    #region Privtae Methods

    void InitializeGameForFirstPlay()
    {
        if (!PlayerPrefs.HasKey("Game1"))
        {
            PlayerPrefs.DeleteAll();
            GamePreferences.Sound = 1;
            GamePreferences.Music = 1;
            GamePreferences.HighScore = 0;
            PlayerPrefs.SetInt("Game1", 1);
        }
    }

    void InitializeGame()
    {
        //Assigning SoundManager
        if (FindObjectOfType<SoundManager>() != null)
        {
            TheGlobals.sManager = FindObjectOfType<SoundManager>();
        }
        DisplayScore();
    }

    void OnBackClick()
    {
        TheGlobals.sManager.allAudio[0].Play();
        if (!ExitPanel.activeInHierarchy)
        {
            OpenExitPanel();
        }
        else
        {
            CloseExitPanel();
        }
    }

    void DisplayScore()
    {
        HighScoreText.text = "High Score : " + GamePreferences.HighScore.ToString();
    }
    #endregion

    #region Public Methods
    public void PlayClickAudio(int index)
    {
        TheGlobals.sManager.allAudio[index].Play();
    }

    //Call this method on button from where you want to change sound preference
    public void ChangeSoundPref()
    {
        TheGlobals.sManager.ChangeSoundPreference();
    }

    ////Call this method on button from where you want to change music preference
    public void ChangeMusicPref()
    {
        TheGlobals.sManager.ChangeMusicPreference();
    }

    public void OpenExitPanel()
    {
        ExitPanel.SetActive(true);
    }

    public void CloseExitPanel()
    {
        ExitPanel.SetActive(false);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
    #endregion
}
