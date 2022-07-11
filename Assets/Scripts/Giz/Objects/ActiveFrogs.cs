using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFrogs : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Frog"))
        {
            other.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Frog"))
        {
            other.gameObject.SetActive(true);
        }
    }
}
