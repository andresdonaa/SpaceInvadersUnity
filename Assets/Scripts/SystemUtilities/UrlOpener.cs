using UnityEngine;
using UnityEngine.UI;

public class UrlOpener : MonoBehaviour
{
    [SerializeField] private string Url;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(OpenUrl);
    }

    private void OpenUrl()
    {
        Application.OpenURL(Url);
    }
}