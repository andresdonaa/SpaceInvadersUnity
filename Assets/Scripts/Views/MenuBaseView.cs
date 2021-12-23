using UnityEngine;

public abstract class MenuBaseView : MonoBehaviour
{
    protected void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}