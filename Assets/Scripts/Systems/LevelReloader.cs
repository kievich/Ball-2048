using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    private void Start()
    {

    }


    public void Reload()
    {
        AppData.ResetToReload();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
