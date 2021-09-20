using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    [SerializeField] private LevelPause _levelPause;
    [SerializeField] private DefautBallPositions _defautPositions;
    public void Reload()
    {
        if (LevelPause.IsPause)
            _levelPause.ResumeGame();

        Ball.DestroyAll();
        AppData.ResetScore();
        AppData.SetDefaultBallPosition(_defautPositions);
        AppData.SetShouldBeRestarted(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
