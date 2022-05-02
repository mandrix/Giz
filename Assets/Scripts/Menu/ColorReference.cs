using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorReference : MonoBehaviour
{ 

    private bool onFadeIn;
    private bool onFadeOut;
    private float tiempoInicio;

    private Color colorAnimacion;
    private Color transparente;
    private Color originalColor;

    private MaskableGraphic objectReference;
    private float velocidadAnim = 2f;

    private void Start()
    {
        Image imagenActual = this.GetComponent<Image>();
        if (imagenActual != null)
        {
            objectReference = imagenActual;
            originalColor = imagenActual.color;
            //imagenActual.color = transparente;
        }
        Text textoActual = this.GetComponent<Text>();
        if (textoActual != null)
        {
            objectReference = textoActual;
            originalColor = textoActual.color;
            //textoActual.color = transparente;
        }
        RawImage rawImage = this.GetComponent<RawImage>();
        if (rawImage != null)
        {
            objectReference = rawImage;
            originalColor = rawImage.color;
            //rawImage.color = transparente;
        }

        colorAnimacion = transparente = new Color(1, 1, 1, 0);        
    }

    // Update is called once per frame
    void Update()
    {
        AnimarFade();
    }

    public void FadeIn()
    {
        onFadeOut = false;
        onFadeIn = true;
        tiempoInicio = Time.time;
    }

    public void FadeOut()
    {
        onFadeIn = false;
        onFadeOut = true;
        tiempoInicio = Time.time;
    }

    private void AnimarFade()
    {
        if (onFadeIn)
        {
            colorAnimacion = Color.Lerp(transparente, originalColor, (Time.time - tiempoInicio) * velocidadAnim);
            objectReference.color = colorAnimacion;
            if (colorAnimacion == originalColor)
            {
                onFadeIn = false;
            }
        }

        if (onFadeOut)
        {
            colorAnimacion = Color.Lerp(originalColor, transparente, (Time.time - tiempoInicio) * velocidadAnim);
            objectReference.color = colorAnimacion;
            if (colorAnimacion == transparente)
            {
                onFadeOut = false;                
            }
        }
    }
}
