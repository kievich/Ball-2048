using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _bombTemplate;
    [SerializeField] private Doubler _doublerTemplate;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _ballCluster;

    private Dictionary<BoosterType, Booster> _boosterMap = new Dictionary<BoosterType, Booster>();
    private void Start()
    {
        _boosterMap.Add(BoosterType.Bomb, _bombTemplate);
        _boosterMap.Add(BoosterType.Doubler, _doublerTemplate);

    }

    public Booster SpawnBooster(BoosterType boosterType)
    {
        Booster booster = Instantiate(_boosterMap[boosterType], _spawnPoint.position, Quaternion.identity, _ballCluster);
        booster.State.Set(BoosterStates.OnSpawnPoint);
        return booster;
    }
}
