using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private EnemyGenerator _enemyGenerator;
        [SerializeField] private StartGameWindow _startGameWindow;
        [SerializeField] private EndGameWindow _endGameWindow;

        private void OnEnable()
        {
            _startGameWindow.PlayButtonClicked += OnPlayButtonClicked;
            _endGameWindow.RestartButtonClicked += OnRestartButtonClicked;
            _player.Died += OnGameOver;
        }

        private void OnDisable()
        {
            _startGameWindow.PlayButtonClicked -= OnPlayButtonClicked;
            _endGameWindow.RestartButtonClicked -= OnRestartButtonClicked;
            _player.Died -= OnGameOver;
        }

        private void Start()
        {
            Time.timeScale = 0;
            _startGameWindow.Open();
        }

        private void OnRestartButtonClicked()
        {
            _endGameWindow.Close();
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            _player.Reset();
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
            _endGameWindow.Open();
        }

        private void OnPlayButtonClicked()
        {
            _startGameWindow.Close();
            StartGame();
        }
    }
}