using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    [SerializeField] private LevelPause _levelPause;
    public void Reload()
    {
        if (LevelPause.IsPause)
            _levelPause.ResumeGame();

        Ball.DestroyAll();
        AppData.ResetScore();
        AppData.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
