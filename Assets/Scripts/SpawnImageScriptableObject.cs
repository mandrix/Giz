using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Image_template", menuName = "VRStructure/Create image template", order = 2)]
public class SpawnImageScriptableObject : ScriptableObject
{
    public List<Sprite> images;
}