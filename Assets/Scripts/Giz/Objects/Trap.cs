using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private bool isCorrect;
    [SerializeField]
    private GameObject bug;
    [SerializeField]
    private GameObject zoom;
    [SerializeField]
    private SceneFlow flow;
    private void OnMouseUp()
    {
        if (isCorrect)
        {
            StartCoroutine(ActiveMovementInBug());
        }
    }

    private IEnumerator ActiveMovementInBug()
    {
        yield return new WaitForSeconds(2);
        bug.transform.SetParent(zoom.transform);
        bug.transform.position = new Vector3(0, 0, 0);
        bug.transform.localScale = new Vector3(1, 1, 1);
        bug.transform.rotation = new Quaternion(0, 0, 0, 0);
        flow.ActivateInfoUI();
        bug.transform.GetComponent<OnlyOneMove>().SetDestination(zoom.transform.position);
        bug.transform.GetComponent<AnimalRotateInfo>().RotateWithFunction();
        
    }
}
