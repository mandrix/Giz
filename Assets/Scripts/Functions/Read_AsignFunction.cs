using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Read_AsignFunction : MonoBehaviour
{

    public int textIndex;
    public int [] functions;
    
    public ReadTextFile readTxtFile;
    public Functions functionsScript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RadAndAsign());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RadAndAsign()
    {
        yield return new WaitForSeconds(0.5f);
        if (gameObject.GetComponent<Text>())
        {           
            gameObject.GetComponent<Text>().text = readTxtFile.textList.ElementAt(textIndex);
        }
        else if (gameObject.GetComponent<Button>())
        {
            foreach(int f in functions)
            {
                UnityEvent customEvent = functionsScript.EventList.ElementAt(f);
                gameObject.GetComponent<Button>().onClick.AddListener(() =>
                {
                    customEvent.Invoke();
                });
            }
            
        }
    }
}
