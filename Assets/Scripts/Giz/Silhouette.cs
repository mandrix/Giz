using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Silhouette", menuName = "Silhouette", order = 2)]
public class Silhouette : ScriptableObject
{
    [InspectorName("Silhouette")]

    public string description;
    public int id;
    public string group; // + icono + description
    public string especie; // + icono + description
    public Sprite groupIcono; // + icono + description
    public Sprite especieIcono;
    public string groupDescription; // + icono + description
    public string especieDescription;
    public Sprite silhouette; 
}