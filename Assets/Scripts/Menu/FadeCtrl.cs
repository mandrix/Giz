using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeCtrl : MonoBehaviour
{
    public bool seDesactiva;

    // Use this for initialization
    void Awake()
    {
        AddColorReferenceToChilds(this.gameObject);        
    }

    

    public void FadeIn()
    {
        ColorReference fadeReference = this.GetComponent<ColorReference>();
        if (fadeReference != null) {
            fadeReference.FadeIn();
        }

        if (this.transform.childCount > 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                FadeIn(this.transform.GetChild(i).gameObject);
            }
        }

    }

    public void FadeIn(GameObject objectToFade)
    {        
        ColorReference fadeReference = objectToFade.GetComponent<ColorReference>();
        if (fadeReference != null)
        {
            fadeReference.FadeIn();
        }

        if (objectToFade.transform.childCount > 0)
        {
            for (int i = 0; i < objectToFade.transform.childCount; i++)
            {
                FadeIn(objectToFade.transform.GetChild(i).gameObject);
            }            
        }

    }

    public void FadeOut()
    {
        ColorReference fadeReference = this.GetComponent<ColorReference>();
        if (fadeReference != null)
        {
            fadeReference.FadeOut();
        }

        if (this.transform.childCount > 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                FadeOut(this.transform.GetChild(i).gameObject);
            }
        }
    }

    public void FadeOut(GameObject objectToFade)
    {
        ColorReference fadeReference = objectToFade.GetComponent<ColorReference>();
        if (fadeReference != null)
        {
            fadeReference.FadeOut();
        }

        if (objectToFade.transform.childCount > 0)
        {
            for (int i = 0; i < objectToFade.transform.childCount; i++)
            {
                FadeOut(objectToFade.transform.GetChild(i).gameObject);
            }
        }
    }


    private void AddColorReferenceToChilds(GameObject objeto) {
        Image imagenActual = objeto.GetComponent<Image>();
        if (imagenActual != null)
        {
            ColorReference originalReference = objeto.AddComponent<ColorReference>();           
        }
        Text textoActual = objeto.GetComponent<Text>();
        if (textoActual != null)
        {
            ColorReference originalReference = objeto.AddComponent<ColorReference>();            
        }
        RawImage rawImage = objeto.GetComponent<RawImage>();
        if (rawImage != null)
        {
            ColorReference originalReference = objeto.AddComponent<ColorReference>();            
        }

        if (objeto.transform.childCount > 0)
        {
            foreach (Transform hijo in objeto.transform)
            {
                AddColorReferenceToChilds(hijo.gameObject);
            }
        }
    }

}