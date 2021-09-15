using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AdID
{
    public AdType AdType;
    public string ID;
}


[CreateAssetMenu(menuName = "ScriptableObject/AdsUnitID", fileName = "AdsUnitID")]
public class AdsUnitID : ScriptableObject
{
    [SerializeField] private AdID[] _ids;

    public string GetID(AdType type)
    {
        foreach (var item in _ids)
            if (item.AdType == type)
                return item.ID;

        throw new System.Exception("No ID for this type of ad:" + type.ToString());

    }
}
