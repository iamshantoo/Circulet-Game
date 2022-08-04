using UnityEngine;

public static class GamePreferences
{
    private const string SOUND = "Sound";
    private static int _sound;
    public static int Sound
    {
        get { return PlayerPrefs.GetInt(SOUND); }
        set { _sound = value; PlayerPrefs.SetInt(SOUND, _sound); }
    }

    private const string MUSIC = "Music";
    private static int _music;
    public static int Music
    {
        get { return PlayerPrefs.GetInt(MUSIC); }
        set { _music = value; PlayerPrefs.SetInt(MUSIC, _music); }
    }

	private const string HIGH_SCORE= "High Score";
	private static int _HighScore;
	public static int HighScore
	{
		get { return PlayerPrefs.GetInt(HIGH_SCORE); }
		set { _HighScore= value; PlayerPrefs.SetInt(HIGH_SCORE, _HighScore); }
	}
}