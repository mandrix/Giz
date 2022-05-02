using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class UI_VR_Editor : EditorWindow
{
    public List<GameObject> templates;    
    private GameObject foo;
    [MenuItem("VR UI/VR UI Creator")]
    static void OpenWindow()
    {
        UI_VR_Editor window = (UI_VR_Editor)GetWindow(typeof(UI_VR_Editor));
        window.minSize = new Vector2(400, 300);
        window.Show();
       
    }

    //Como el start
    private void OnEnable()
    {
        templates = new List<GameObject>();
        templates = Resources.LoadAll<GameObject>("TemplatePrefabs").ToList();
    }

    private void OnGUI()
    {
        //Titulo
        GUIStyle selectedGO = GUI.skin.GetStyle("label");
        selectedGO.alignment = TextAnchor.LowerCenter;
        selectedGO.fontStyle = FontStyle.Bold;
        GUILayout.Label("VR UI CREATOR", selectedGO);
        GUILayout.Space(30);

        /*ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty templatesProperty = so.FindProperty("templates");

        EditorGUILayout.PropertyField(templatesProperty, true); // True means show children
        so.ApplyModifiedProperties(); // Remember to apply modified properties

        GUILayout.Space(30);*/

        if (templates.Count > 0)
        {
            for (int i = 0; i < templates.Count; i++)
            {
                if (templates[i] != null) {
                    GUI.backgroundColor = Color.green;
                    if (GUILayout.Button("Add new: " + templates[i].name))
                    {
                        GameObject obj = Instantiate(templates[i], Vector3.zero, Quaternion.identity) as GameObject;
                        Selection.activeGameObject = obj;
                    }
                }
            }
        }
        else {
            GUILayout.Label("No templates assigned", selectedGO);
        }
    }
}
