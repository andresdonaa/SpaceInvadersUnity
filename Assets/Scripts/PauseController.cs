using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private KeyCode pauseButton = KeyCode.Pause;
    
    public static bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {            
            TogglePause();
        }
    }

    public static void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;        
    }
}
