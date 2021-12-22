using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameRules gameRules;

    private DifficultyController difficulty;
    private LivesController lives;

    private void Awake()
    {
        difficulty = new DifficultyController(gameRules.increaseDifficultyFactor);
        lives = new LivesController(gameRules.lives);
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

// IMPROVEMENTS
// Object pooling (enemies, player bullets, enemy bullets)