using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField]
    private static string nextScene;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public async void LoadScene()
    {
        Debug.Log(2);
        var scene = SceneManager.LoadSceneAsync(nextScene);
    }
    public void ChangeScene(string sceneName)
    {
        Debug.Log(0);
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingPage");
        Debug.Log(1);
    }
}
