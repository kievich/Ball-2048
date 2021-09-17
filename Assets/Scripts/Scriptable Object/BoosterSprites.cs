using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoosterSprite
{
    [SerializeField] public BoosterType Booster;
    [SerializeField] public Texture Sprite;
}

[CreateAssetMenu(menuName = "ScriptableObject/BoosterSprites", fileName = "BoosterSprites")]
public class BoosterSprites : ScriptableObject
{
    public BoosterSprite[] List;

    public Texture GetSprite(BoosterType booster)
    {
        Texture texture = default;
        bool isFound = false;

        foreach (var item in List)
            if (item.Booster == booster)
            {
                texture = item.Sprite;
                isFound = true;
                break;
            }

        if (isFound)
            return texture;
        else
            throw new System.Exception("Texture not found");
    }

}
