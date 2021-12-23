using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;

    [Header("Views")]
    [SerializeField] private PauseMenuView pauseMenuViewPrefab;
    [SerializeField] private GameOverMenuView gameOverMenuViewPrefab;
    [SerializeField] private GameObject canvasParentViews;

    private DifficultyController difficulty;
    private LivesController lives;

    private void Start()
    {
        PauseMenuViewModel pauseMenuViewModel = new PauseMenuViewModel();
        IPauseMenuView pauseMenuViewInstance = Instantiate(pauseMenuViewPrefab, canvasParentViews.transform);
        IPauseMenuPresenter pauseMenuPresenter = new PauseMenuPresenter(pauseMenuViewInstance, pauseMenuViewModel);
        pauseMenuViewInstance.Configure(pauseMenuViewModel, pauseMenuPresenter);

        GameOverMenuViewModel gameOverMenuViewModel = new GameOverMenuViewModel();
        IGameOverMenuView gameOverMenuViewInstance = Instantiate(gameOverMenuViewPrefab, canvasParentViews.transform);
        IGameOverMenuPresenter gameOverMenuPresenter = new GameOverMenuPresenter(gameOverMenuViewInstance, gameOverMenuViewModel);
        gameOverMenuViewInstance.Configure(gameOverMenuViewModel, gameOverMenuPresenter);

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