using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace NikolayTrofimovUnityVR
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private CharController _charController;
        [SerializeField] private LevelGenerator _levelGenerator;

        [SerializeField] private GameObject _menuObject;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;


        private void Start()
        {
            _charController.OnPlayerDead += OnLose;
            _levelGenerator.OnSegmentsToWin += OnWin;
            _levelGenerator.OnGameStatusChanged += _charController.OnGameStatusChanged;
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _startButton.onClick.AddListener(OnStartButtonClick);
            _levelGenerator.UpdateGameStatus();
        }

        private void OnWin()
        {
            SetEndGame("you win");
        }

        private void OnLose()
        {
            SetEndGame("you lose");
        }

        private void SetEndGame(string status)
        {
            _charController.StopMoving();
            _charController.OnGameStatusChanged(status);
            _menuObject.SetActive(true);
            _restartButton.gameObject.SetActive(true);
            _startButton.gameObject.SetActive(false);
        }

        private void OnStartButtonClick()
        {
            _menuObject.SetActive(false);
            _charController.StartMoving();
        }

        private void OnRestartButtonClick()
        {
            SceneManager.LoadScene("SampleScene");
        }

        private void OnDestroy()
        {
            _charController.OnPlayerDead -= OnLose;
            _levelGenerator.OnSegmentsToWin -= OnWin;
            _levelGenerator.OnGameStatusChanged -= _charController.OnGameStatusChanged;
            _restartButton.onClick.RemoveAllListeners();
            _startButton.onClick.RemoveAllListeners();
        }
    }
}