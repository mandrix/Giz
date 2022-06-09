using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Audios", menuName = "Audios", order = 1)]
public class Audios : ScriptableObject
{
    [InspectorName("Audios")]

    public AudioClip firstAudioInvertebrados;
    public AudioClip firstAudioEscarabajos;
    public AudioClip firstAudioFlora;
    public AudioClip finalAudioInvertebrados;
    public AudioClip finalAudioEscarabajos;
    public AudioClip finalAudioFlora;

    public AudioClip getFirstAudio(int index)
    {
        switch (index)
        {
            case 1:
                {
                    return firstAudioInvertebrados;
                }
            case 2:
                {
                    return firstAudioEscarabajos;
                }
            case 3:
                {
                    return firstAudioFlora;
                }
            case 4:
                {
                    return firstAudioFlora;
                }
            default:
                {
                    return firstAudioInvertebrados;
                }
        }
    }

    public AudioClip getFinalAudio(int index)
    {
        switch (index)
        {
            case 1:
                {
                    return finalAudioInvertebrados;
                }
            case 2:
                {
                    return finalAudioEscarabajos;
                }
            case 3:
                {
                    return finalAudioFlora;
                }
            case 4:
                {
                    return finalAudioFlora;
                }
            default:
                {
                    return finalAudioInvertebrados;
                }
        }
    }
}