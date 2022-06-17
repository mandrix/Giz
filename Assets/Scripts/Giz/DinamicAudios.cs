using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DinamicAudios", menuName = "DinamicAudios", order = 1)]
public class DinamicAudios : ScriptableObject
{
    [InspectorName("DinamicAudios")]

    public string Group;
    public AudioClip[] AudiosList;

}
