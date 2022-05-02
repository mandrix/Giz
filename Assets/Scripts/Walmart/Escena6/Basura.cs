using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dinamicas
{
    public class Basura : MonoBehaviour
    {
        public Vector3 initialPosition;
        public Vector3 initialRotation;
        public tipos tipo;
        public GameObject highlight;
        public Dinamica06 dinamica;
        // Start is called before the first frame update
        void Start()
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation.eulerAngles;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Deselect() {
            highlight.SetActive(false);
        }

        public void InitGazeInteraction () {
            TryToSelect();
        }

        void TryToSelect() {
            dinamica.SetSelectedTrash(this);
            highlight.SetActive(true);
        }

        void OnMouseDown()
        {
            TryToSelect();
        }

    }

}