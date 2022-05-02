using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Silhouette", menuName = "Silhouette", order = 2)]
public class Silhouette : ScriptableObject
{
    [InspectorName("Silhouette")]
    public string groupName;

    public string description;
    public int idGroups;
    public Sprite shade;
} 