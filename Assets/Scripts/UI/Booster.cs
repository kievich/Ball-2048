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

        [SerializeField] private Color _disabledTextColor;
        [SerializeField] private Color _enabledTextColor;

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

        public void SetTextColor(Color disabledTextColor, Color enabledTextColor)
        {
            _disabledTextColor = disabledTextColor;
            _enabledTextColor = enabledTextColor;
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
            if (count == 0)
                Disable();
            else
                Enable();

            _counterText.text = count.ToString();
        }

        public void Disable()
        {
            Button.interactable = false;
            CounterText.color = _disabledTextColor;
        }

        public void Enable()
        {
            if (AppData.GetBoosterNumber(_boosterType) > 0)
            {
                Button.interactable = true;
                CounterText.color = _enabledTextColor;
            }

        }
    }
}

