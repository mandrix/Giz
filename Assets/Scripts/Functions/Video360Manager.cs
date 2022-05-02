using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class Video360Manager : MonoBehaviour
{
    public GameObject video360;
    public VideoPlayer video;

    public GameObject [] uiObjects;
    public UnityEvent onVideoFinish;
    //public GameObject [] menuItems;

    private int currentVideoIndex;
    private int currentSelectedVideos;

    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += CheckOver;
    }
 
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("sirve a la verga");
        onVideoFinish.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open360Video() {
        for (int i = 0; i < uiObjects.Length; i++)
        {
            uiObjects[i].SetActive(false);
        }

        video360.SetActive(true);
        video360.GetComponent<VideoPlayer>().Play();
    }
}
