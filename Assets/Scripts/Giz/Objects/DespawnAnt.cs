using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAnt : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("fff");
        if (other.CompareTag("Ant"))
        {
            
            other.gameObject.SetActive(false);
        }
    }
}
