using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class BoosterSystem : MonoBehaviour
    {
        [SerializeField] private UI.Booster[] _boosters;
        [SerializeField] private Color _disabledTextColor;
        [SerializeField] private Color _enabledTextColor;
        [SerializeField] private float _enableButtonsDelay;

        private BallGun _ballGun;

        private void Start()
        {
            foreach (var booster in _boosters)
            {
                booster.Click += onClick;
                booster.AddClick += onAddClick;
                booster.SetCount(AppData.GetBoosterNumber(booster.BoosterType));
            }
            _ballGun = FindObjectOfType<BallGun>();
            _ballGun.BusterPushed += onBoosterPushed;
        }


        public void onClick(BoosterType boosterType)
        {
            _ballGun.SpawnBooster(boosterType);
            DisableButtons();
        }

        public void onAddClick(BoosterType boosterType)
        {
            Debug.Log("onAddClick - " + boosterType.ToString());

        }

        private void onBoosterPushed()
        {
            Invoke(nameof(EnableButtons), _enableButtonsDelay);
        }

        private void OnDisable()
        {
            foreach (var booster in _boosters)
            {
                booster.Click -= onClick;
                booster.AddClick -= onAddClick;
            }
            _ballGun.BusterPushed -= EnableButtons;

        }

        private void DisableButtons()
        {
            foreach (var booster in _boosters)
            {
                booster.Button.interactable = false;
                booster.CounterText.color = _disabledTextColor;
            }
        }

        private void EnableButtons()
        {
            foreach (var booster in _boosters)
            {
                booster.Button.interactable = true;
                booster.CounterText.color = _enabledTextColor;
            }
        }


    }

}
