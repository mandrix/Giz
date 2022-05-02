using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDinamica01 : MonoBehaviour
{
    public Dinamica01 dinamica;
    private GameObject highlight;
    private MeshCollider m_collider;
    private AudioSource audio_src;
    public float timeToActivate;
    private Coroutine triggerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        highlight = transform.GetChild(0).gameObject;
        m_collider = GetComponent<MeshCollider>();
        audio_src = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if(gameObject.tag == "Interactive")
        {
            triggerCoroutine = StartCoroutine(TriggerEvent());
            audio_src.Play();
        }
    }

    public void InitGazeInteraction() {
        if(gameObject.tag == "Interactive")
        {
            triggerCoroutine = StartCoroutine(TriggerEvent());
            audio_src.Play();
        }
    }

    void OnMouseUp()
    {
        if (gameObject.tag == "Interactive")
        {
            StopCoroutine(triggerCoroutine);
        }
    }

    public void FinishGazeInteraction() {
        if (gameObject.tag == "Interactive")
        {
            StopCoroutine(triggerCoroutine);
        }
    }

    public void Activate()
    {
        gameObject.tag = "Interactive";
        highlight.SetActive(true);
        m_collider.enabled = true;
    }

    public void Deactivate()
    {
        gameObject.tag = "Untagged";
        highlight.SetActive(false);
        m_collider.enabled = false;
    }

    IEnumerator TriggerEvent()
    {
        yield return new WaitForSeconds(timeToActivate);
        dinamica.NextStep();
        Deactivate();
    }
}
