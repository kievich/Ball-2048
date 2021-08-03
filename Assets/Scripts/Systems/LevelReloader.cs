using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    public void Reload()
    {

        Ball.DestroyAll();
        AppData.ResetScore();
        AppData.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
