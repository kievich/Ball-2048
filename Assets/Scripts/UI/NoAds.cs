using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NoAds : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(onClick);
        }

        private void onClick()
        {

        }
    }
}