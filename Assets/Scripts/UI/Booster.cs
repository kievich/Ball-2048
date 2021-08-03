using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class Booster : MonoBehaviour
    {
        [SerializeField] private Button _addButton;
        [SerializeField] private TMP_Text _counterText;
        [SerializeField] private BoosterType _boosterType;

        public Button Button { get; private set; }
        public TMP_Text CounterText => _counterText;
        public BoosterType BoosterType => _boosterType;

        public event Action<BoosterType> Click;
        public event Action<BoosterType> AddClick;

        private void Start()
        {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(onClick);
            _addButton.onClick.AddListener(onAddClick);
        }

        private void onClick()
        {
            Click?.Invoke(_boosterType);
        }

        private void onAddClick()
        {
            AddClick?.Invoke(_boosterType);
        }

        public void SetCount(int count)
        {
            _counterText.text = count.ToString();
        }

    }
}

