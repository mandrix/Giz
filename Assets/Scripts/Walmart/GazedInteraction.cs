using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dinamicas
{
    public class GazedInteraction : MonoBehaviour
    {
        public GameObject pointerObject;
        Touch touch;
        bool interacting;
        Transform lastObject;
        string lastTag;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            /*if(Input.touchCount > 0 && !interacting){
                interacting = true;
                touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began){
                    RaycastHit hit;
                    lastTag = "";
                    if (Physics.Raycast(pointerObject.transform.position, pointerObject.transform.forward, out hit, 100)){
                        if (hit.transform.gameObject.tag == "Rotate") {
                            lastTag = "Rotate";
                            lastObject = hit.transform;
                            MouseRotateObject script = hit.transform.GetComponent<MouseRotateObject>();
                            script.InitGazeInteraction(hit.point);
                        }
                        else if (hit.transform.gameObject.tag == "Interactive") {
                            lastTag = "Interactive";
                            lastObject = hit.transform;
                            BotonDinamica01 script = hit.transform.GetComponent<BotonDinamica01>();
                            script.InitGazeInteraction();
                        }
                    }
                }
            }
            else if(Input.touchCount == 0 && interacting) {
                interacting = false;
                if(lastTag == "Rotate") {
                    MouseRotateObject script = lastObject.GetComponent<MouseRotateObject>();
                    script.FinishGazeInteraction();
                }
                else if(lastTag == "Interactive") {
                    BotonDinamica01 script = lastObject.GetComponent<BotonDinamica01>();
                    script.FinishGazeInteraction();
                }
            }*/


            if(Input.GetMouseButton(0) && !interacting){
                interacting = true;
                if(Input.GetMouseButton(0)){
                    RaycastHit hit;
                    if (Physics.Raycast(pointerObject.transform.position, pointerObject.transform.forward, out hit, 100)){
                        lastTag = hit.transform.gameObject.tag;
                        lastObject = hit.transform;
                        switch (lastTag) {
                            case "Rotate":
                                MouseRotateObject rotateScript = lastObject.GetComponent<MouseRotateObject>();
                                rotateScript.InitGazeInteraction(hit.point);
                                break;
                            case "Interactive":
                                BotonDinamica01 botonScript = lastObject.GetComponent<BotonDinamica01>();
                                botonScript.InitGazeInteraction();
                                break;
                            case "Pallet":
                                Pallet palletScript = lastObject.GetComponent<Pallet>();
                                palletScript.InitGazeInteraction();
                                MouseRotateObject palletRotateScript = lastObject.GetComponent<MouseRotateObject>();
                                palletRotateScript.InitGazeInteraction(hit.point);
                                break;
                            case "Cajas":
                                BoxBed boxScript = lastObject.GetComponent<BoxBed>();
                                boxScript.InitGazeInteraction();
                                break;
                            case "Basura":
                                Basura basuraScript = lastObject.GetComponent<Basura>();
                                basuraScript.InitGazeInteraction();
                                break;
                            case "Basurero":
                                Basurero basureroScript = lastObject.GetComponent<Basurero>();
                                basureroScript.InitGazeInteraction();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else if(!Input.GetMouseButton(0) && interacting) {
                interacting = false;
                switch (lastTag) {
                    case "Rotate":
                        MouseRotateObject rotateScript = lastObject.GetComponent<MouseRotateObject>();
                        rotateScript.FinishGazeInteraction();
                        break;
                    case "Interactive":
                        BotonDinamica01 botonScript = lastObject.GetComponent<BotonDinamica01>();
                        botonScript.FinishGazeInteraction();
                        break;
                    case "Pallet":
                        MouseRotateObject palletRotateScript = lastObject.GetComponent<MouseRotateObject>();
                        palletRotateScript.FinishGazeInteraction();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}