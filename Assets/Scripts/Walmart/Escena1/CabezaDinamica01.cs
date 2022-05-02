using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaDinamica01 : MonoBehaviour
{

    private bool rotating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateToPowerButton() {
        StartCoroutine(Rotate(new Vector3(0, -90,0), 2));
    }

    public void RotateToControl() {
        StartCoroutine(Rotate(new Vector3(0, 120,0), 2));
    }

     private IEnumerator Rotate( Vector3 angles, float duration )
    {
        rotating = true ;
        Quaternion startRotation = gameObject.transform.rotation;
        Quaternion endRotation = Quaternion.Euler( angles ) * startRotation ;
        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            gameObject.transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            yield return null;
        }
        gameObject.transform.rotation = endRotation  ;
        rotating = false;
    }
}
