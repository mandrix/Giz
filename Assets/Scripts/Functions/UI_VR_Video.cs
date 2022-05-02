using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class UI_VR_Video : MonoBehaviour
{
    //public int videoIndex;
    private VideoPlayer video;
    public GameObject videoPanelButtons;

    // Start is called before the first frame update
    void Start()
    {
        video = this.GetComponent<VideoPlayer>();
        //video.clip = UI_VR_Ctrl.Instance.videosTemplate.videos[videoIndex];
        //video.Play();
        video.loopPointReached += EndReached;
        ClearOutRenderTexture(video.targetTexture);
    }

    private void ClearOutRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture rt = RenderTexture.active;
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = rt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(){
        video.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        this.GetComponent<Image>().enabled = false;
        this.transform.GetChild(0).gameObject.SetActive(true);

        videoPanelButtons.transform.GetChild(0).gameObject.SetActive(false);
        videoPanelButtons.transform.GetChild(1).gameObject.SetActive(true);
        videoPanelButtons.transform.GetChild(2).gameObject.SetActive(false);        
    }
}
