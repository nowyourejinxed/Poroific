using UnityEngine;
using UnityEngine.UIElements;

public class PauseListener : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;
    private bool _isPaused;

    // Attempt to pause the game.
    // If the game is already paused, then unpause it.
    void Update()
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

                this.gameObject.SetActive(false);
            }
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;

        _isPaused = false;
        _pauseMenu.SetActive(false);

        this.gameObject.SetActive(true);
    }
}
