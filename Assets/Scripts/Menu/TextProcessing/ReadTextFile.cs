using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class ReadTextFile : MonoBehaviour
{

    public string filename;
    public List<string> textList;
    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(ReadFile(filename));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReadFile(string filename)
    {
        WWW www = new WWW(Path.Combine(Application.streamingAssetsPath, filename));
        yield return www;
        textList = www.text.Split('\n').ToList();
    }

    
}
