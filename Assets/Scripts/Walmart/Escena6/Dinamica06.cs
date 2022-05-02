using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace Dinamicas
{
    public class Dinamica06 : MonoBehaviour
    {

        private Basura selectedTrash;
        public int trashCount;
        public UnityEvent finalEvent;
        public AudioClip correct;
        public AudioClip wrong;
        private AudioSource audio_src;
        public float throwAnimationDuration;
        public float throwBackAnimationDuration;
        // Start is called before the first frame update
        void Start()
        {
            audio_src = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SetSelectedTrash (Basura obj) {
            if(selectedTrash != null) selectedTrash.Deselect();
            selectedTrash = obj;
        }

        private void CompletedTrash() {
            audio_src.clip = correct;
            audio_src.Play();
            trashCount -= 1;
            if(trashCount == 0) StartCoroutine(Finish());
        }

        private void WrongTrashCan() {
            audio_src.clip = wrong;
            audio_src.Play();
        }

        public void ThrowToTrashCan (Basurero obj) {
            if(selectedTrash != null) {
                if(selectedTrash.tipo == obj.tipo) {
                    selectedTrash.gameObject.transform.DOJump(obj.apertura.transform.position,2,1,throwAnimationDuration,false).OnComplete(
                        CompletedTrash
                    );
                    selectedTrash.gameObject.transform.DORotate(new Vector3(-90,0,0),throwAnimationDuration);
                    selectedTrash.Deselect();
                    selectedTrash = null;
                }
                else{
                    Sequence jumpSequence = DOTween.Sequence();
                    jumpSequence.Append(selectedTrash.gameObject.transform.DOJump(obj.apertura.transform.position,2,1,throwAnimationDuration,false).OnComplete(
                        WrongTrashCan
                    ));
                    jumpSequence.Append(selectedTrash.gameObject.transform.DOJump(selectedTrash.initialPosition,2,1,throwBackAnimationDuration,false));
                    
                    Sequence rotationSequence = DOTween.Sequence();
                    rotationSequence.Append(selectedTrash.gameObject.transform.DORotate(new Vector3(-90,0,0),throwAnimationDuration));
                    rotationSequence.Append(selectedTrash.gameObject.transform.DORotate(selectedTrash.initialRotation,throwBackAnimationDuration));
                }
                
            }
        }

        IEnumerator Finish() {
            yield return new WaitForSeconds(2);
            finalEvent.Invoke();
        }
    }

    public enum tipos{
        plastico,
        madera,
        carton,
    }
}