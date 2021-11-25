using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseContainer;

    private void Update()
    {
        if (PauseController.isGamePaused && !pauseContainer.activeSelf)
            pauseContainer.SetActive(true);
        else if(!PauseController.isGamePaused && pauseContainer.activeSelf)
            pauseContainer.SetActive(false);
    }

    public void GoToMenu()
    {
        PauseController.TogglePause();
        SceneController.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        PauseController.TogglePause();
        pauseContainer.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}