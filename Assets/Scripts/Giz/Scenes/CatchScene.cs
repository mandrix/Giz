using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchScene : MonoBehaviour
{
    [SerializeField]
    private LevelManager LvlManager;
    [SerializeField]
    private Sprite[] images;
    [SerializeField]
    private GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
        screen.GetComponent<Image>().sprite = images[Random.Range(0, images.Length)];
        StartCoroutine(ActivateScene());
    }

    private IEnumerator ActivateScene()
    {
        yield return new WaitForSeconds(0.2f);
        LvlManager = GameObject.Find("LvlManager").transform.GetComponent<LevelManager>();
        LvlManager.LoadScene();
    }
}
