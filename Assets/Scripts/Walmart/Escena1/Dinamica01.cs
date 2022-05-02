using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dinamica01 : MonoBehaviour
{

    public string[] steps;
    public AudioClip[] audios;
    public BotonDinamica01[] buttons;
    public UnityEvent[] events;
    public UnityEvent finalEvent;
    public Text instruction;
    public Text title;
    private AudioSource audio_src;
    private int actual_step;

    // Start is called before the first frame update
    void Start()
    {
        actual_step = 0;
        instruction.text = steps[actual_step];
        title.text = "Paso 1 de " + steps.Length;
        audio_src = GetComponent<AudioSource>();
        audio_src.clip = audios[actual_step];
        if(events[actual_step] != null) events[actual_step].Invoke();
        audio_src.Play();
        StartCoroutine(StartInteraction(audios[actual_step].length));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStep()
    {
        actual_step ++;
        title.text = "Paso " + (actual_step + 1) + " de " + steps.Length;
        instruction.text = steps[actual_step];
        audio_src.clip = audios[actual_step];
        audio_src.Play();
        if(events[actual_step] != null) events[actual_step].Invoke();
        StartCoroutine(StartInteraction(audios[actual_step].length));
    }

    IEnumerator StartInteraction(float t)
    {
        yield return new WaitForSeconds(t);
        if (actual_step < buttons.Length)
        {
            buttons[actual_step].Activate();
        }
        else
        {
            finalEvent.Invoke();
        }
    }
}
