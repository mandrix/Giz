using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dinamicas
{
    public class Basurero : MonoBehaviour
    {
        public tipos tipo;
        public GameObject apertura;
        public Dinamica06 dinamica;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void InitGazeInteraction () {
            TryToSelect();
        }

        void TryToSelect() {
            dinamica.ThrowToTrashCan(this);
        }

        void OnMouseDown()
        {
            TryToSelect();
        }
    }

}