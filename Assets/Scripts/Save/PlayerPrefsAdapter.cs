using UnityEngine;

public class PlayerPrefsAdapter : IDataSaver
{
    public int GetInt(string key, int defaultValue = default)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }
}