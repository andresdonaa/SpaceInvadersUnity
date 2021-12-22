using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;

    private DifficultyController difficulty;
    private LivesController lives;

    private void Awake()
    {
        difficulty = new DifficultyController(gameSettings.increaseDifficultyFactor);
        lives = new LivesController(gameSettings.lives);

        RegisterServices();
    }

    private void RegisterServices()
    {
        PlayerPrefsAdapter playerPrefsAdapter = new PlayerPrefsAdapter();
        ServiceLocator.Instance.RegisterService<IDataSaver>(playerPrefsAdapter);
    }

    private void OnDestroy()
    {
        lives.Dispose();
        difficulty.Dispose();
    }
}

// TO DO:
// Add listener on click menues
// Sólo los enemigos de la primer fila pueden disparar
// Límites de wave para distintos aspect ratio
// Musica
// Icono para build
// Compatibilidad con mando
// Unit testing

// BUGS
// A veces el wave se sale del boundary intercambiando 2 veces la dirección en la que tiene que ir

// IMPROVEMENTS
// Object pooling (enemies, player bullets, enemy bullets)