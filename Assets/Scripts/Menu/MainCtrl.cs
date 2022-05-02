using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCtrl : MonoBehaviour
{
    public FadeCtrl loginCanvas;
    public FadeCtrl mainMenu;

    //Cambiar por funciones luego
    public Image[] stationImages;

    // Start is called before the first frame update
    void Start()
    {
        //loginCanvas.gameObject.SetActive(true);
        //loginCanvas.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu() {
        loginCanvas.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        mainMenu.FadeIn();
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
