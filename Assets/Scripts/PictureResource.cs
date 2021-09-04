using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pictures", menuName = "ScriptableObjects/Pictures", order = 2)]
public class PictureResource : ScriptableObject
{
    public List<Sprite> sprites;

    public Sprite GetSprite(string name)
    {
        return sprites.Find((sprite) => sprite.name == name);
    }
}
