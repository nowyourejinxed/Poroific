using UnityEngine;
using UnityEngine.UIElements;

public class PauseListener : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;

    [SerializeField]
    private UIDocument _UIDocument;

    public bool _isPaused { get; private set; }

    // Attempt to pause the game.
    // If the game is already paused, then unpause it.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                resumeGame();
            }
            else
            {
                Time.timeScale = 0;

                _isPaused = true;
                _pauseMenu.SetActive(true);

                _UIDocument.enabled = false;
            }
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;

        _isPaused = false;
        _pauseMenu.SetActive(false);

        _UIDocument.enabled = true;
    }
}
