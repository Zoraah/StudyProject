using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "TexturesList", menuName = "Assets/TexturesList", order = 0)]
public class TexturesList : ScriptableObject
{
    public AssetReference[] Textures;
}
