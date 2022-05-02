using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Functions_template", menuName = "VRStructure/Create video template", order = 3)]
public class SpawnVideoScriptableObject : ScriptableObject
{
    public List<VideoClip> videos;
}

