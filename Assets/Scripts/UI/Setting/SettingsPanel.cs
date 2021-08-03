using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{

    private void Start()
    {

    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }

}
