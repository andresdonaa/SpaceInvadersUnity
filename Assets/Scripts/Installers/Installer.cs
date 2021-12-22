using UnityEngine;

public class Installer : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefsAdapter playerPrefsAdapter = new PlayerPrefsAdapter();
        ServiceLocator.Instance.RegisterService<IDataSaver>(playerPrefsAdapter);
    }
}