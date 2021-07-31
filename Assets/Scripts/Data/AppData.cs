using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public static class AppData
{
    private static int _defaulIntValue = 0;
    public static int Score { get; private set; }
    public static int MaxScore { get; private set; }

    private static Dictionary<BoosterType, int> _boosterNumber = new Dictionary<BoosterType, int>();

    private static PlayerPrefsSaveSystem _prefsSystem = new PlayerPrefsSaveSystem();

    private static JsonSaveSystem _saveSystem = new JsonSaveSystem();

    static AppData()
    {
        InitData();
    }

    private static void InitData()
    {
        Score = _prefsSystem.LoadInt(nameof(Score), _defaulIntValue);
        MaxScore = _prefsSystem.LoadInt(nameof(MaxScore), _defaulIntValue);
        _boosterNumber.Add(BoosterType.Boomb, _prefsSystem.LoadInt(BoosterType.Boomb.ToString(), _defaulIntValue));
        _boosterNumber.Add(BoosterType.Doubler, _prefsSystem.LoadInt(BoosterType.Doubler.ToString(), _defaulIntValue));
    }
    public static void Save()
    {
        SaveBallPosition();
        SaveGameData();
    }

    private static void SaveGameData()
    {
        _prefsSystem.SaveInt(nameof(Score), Score);
        _prefsSystem.SaveInt(nameof(MaxScore), MaxScore);
        _prefsSystem.SaveInt(BoosterType.Boomb.ToString(), _boosterNumber[BoosterType.Boomb]);
        _prefsSystem.SaveInt(BoosterType.Doubler.ToString(), _boosterNumber[BoosterType.Doubler]);
    }

    private static void SaveBallPosition()
    {
        var ballContainer = new BallContainer();
        ballContainer.FillUp();
        _saveSystem.SavePosition(ballContainer);
    }

    public static BallContainer LoadBallPosition()
    {
        return _saveSystem.LoadPosition();
    }
    private static void ClearBallPosition()
    {
        _saveSystem.ClearPosition();
    }

    public static void ResetToReload()
    {
        ResetScore();
        SaveGameData();
        ClearBallPosition();
    }



    public static void SetScore(int newScore)
    {
        if (newScore > Score)
        {
            Score = newScore;
            if (Score > MaxScore)
                MaxScore = Score;
        }
        else
        {
            throw new System.Exception("NewScore can't be less than Score, Score = " + Score + ", NewScore = " + newScore);
        }

    }

    private static void ResetScore()
    {
        Score = 0;
    }

    public static void AddBooster(BoosterType booster, int number)
    {
        if (_boosterNumber.ContainsKey(booster))
        {
            if (number > 0)
                _boosterNumber[booster] += number;
            else
                throw new System.Exception("AddBooster Value can't be less than 0");
        }
        else
        {
            throw new System.Exception("AppData doesn't cointain this type of Booster - " + booster.ToString());
        }
    }

    public static void DecreaseBooster(BoosterType booster, int number)
    {
        if (_boosterNumber.ContainsKey(booster))
        {
            if (_boosterNumber[booster] - number >= 0)
                throw new System.Exception("Booster Value can't be less than 0");

            if (number > 0)
                _boosterNumber[booster] -= number;
            else
                throw new System.Exception("DecreaseBooster Value can't be less than 0");
        }
        else
        {
            throw new System.Exception("AppData doesn't cointain this type of Booster - " + booster.ToString());
        }
    }

    public static int GetBoosterNumber(BoosterType booster)
    {
        if (_boosterNumber.ContainsKey(booster))
        {
            return _boosterNumber[booster];
        }
        else
        {
            throw new System.Exception("AppData doesn't cointain this type of Booster - " + booster.ToString());
        }
    }

}
