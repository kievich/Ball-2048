using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BusterSprite
{
    [SerializeField] public BoosterType Buster;
    [SerializeField] public Texture Sprite;
}

[CreateAssetMenu(menuName = "ScriptableObject/BusterSprites", fileName = "BusterSprites")]
public class BusterSprites : ScriptableObject
{
    public BusterSprite[] List;

    public Texture GetSprite(BoosterType buster)
    {
        Texture texture = default;
        bool isFound = false;

        foreach (var item in List)
            if (item.Buster == buster)
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
