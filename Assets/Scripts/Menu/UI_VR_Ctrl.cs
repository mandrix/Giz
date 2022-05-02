using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_VR_Ctrl : Singleton<UI_VR_Ctrl>
{
    protected UI_VR_Ctrl() { }

    public SpawnTextScriptableObject textsTemplate;
    public SpawnImageScriptableObject imagesTemplate;
    public SpawnVideoScriptableObject videosTemplate;
    public Functions functions;
}
