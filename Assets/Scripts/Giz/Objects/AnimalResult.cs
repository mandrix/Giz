using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalResult : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioManager;
    [SerializeField]
    private DinamicAudios audioList;
    static bool ready = false;
    [SerializeField]
    private bool isCorrect = false;

    private void Start()
    {
        ready = false;
    }
    private void OnMouseUp()
    {
        if (ready)
        {
            ready = false;
            if (isCorrect)
            {
                ready = false;
                audioManager.clip = audioList.AudiosList[0];
                audioManager.Play();
            }
            else
            {
                audioManager.clip = audioList.AudiosList[1];
                audioManager.Play();
            }
        }
        else
        {
            ready = true;
        }
        
    }

    public void SetReady()
    {
        ready = true;
    }
}
