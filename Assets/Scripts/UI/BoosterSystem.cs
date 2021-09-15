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
                booster.SetTextColor(_disabledTextColor, _enabledTextColor);
            }
            UpdateBusterNumber();

            _ballGun = FindObjectOfType<BallGun>();
            _ballGun.BusterPushed += onBoosterPushed;
        }

        private void UpdateBusterNumber()
        {
            foreach (var booster in _boosters)
            {
                booster.SetCount(AppData.GetBoosterNumber(booster.BoosterType));
            }
        }

        public void AddBuster(BoosterType boosterType, int number)
        {
            AppData.AddBooster(boosterType, number);
            UpdateBusterNumber();
        }

        public void onClick(BoosterType boosterType)
        {
            if (AppData.GetBoosterNumber(boosterType) > 0)
            {
                AppData.DecreaseBooster(boosterType, 1);
                UpdateBusterNumber();
                _ballGun.SpawnBooster(boosterType);
                DisableButtons();
            }

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
                booster.Disable();
        }

        private void EnableButtons()
        {
            foreach (var booster in _boosters)
                booster.Enable();
        }


    }

}
