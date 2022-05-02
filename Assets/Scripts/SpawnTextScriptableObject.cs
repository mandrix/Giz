using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;



[CreateAssetMenu(fileName = "Text_template", menuName = "VRStructure/Create text template", order = 1)]
public class SpawnTextScriptableObject : ScriptableObject
{
    public List<string> texts;
}

