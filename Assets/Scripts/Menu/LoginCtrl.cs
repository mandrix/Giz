using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginCtrl : MonoBehaviour
{
    public Button loginButton;
    public Button[] numberButtons;
    public Text[] pinNumbersText;
    public GameObject errorText;
    private List<int> pinNumbers;
    public AuthCtrl authorization;
    public MainCtrl main;

    public Text userNameText;

    // Start is called before the first frame update
    void Start()
    {
        pinNumbers = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNumber(int number) {
        errorText.SetActive(false);
        if (pinNumbers.Count < 4)
        {
            pinNumbers.Add(number);
            pinNumbersText[pinNumbers.Count - 1].text = "" + pinNumbers[pinNumbers.Count - 1];
            if (pinNumbers.Count == 4)
            {
                SetButtonNumbersState(false);
                loginButton.interactable = true;
            }           
        }       
    }

    public void SetButtonNumbersState(bool state) {
        for (int i = 0; i < numberButtons.Length; i++)
        {
            numberButtons[i].interactable = state;
        }
    }

    public void Delete() {
        if (pinNumbers.Count > 0) {
            pinNumbersText[pinNumbers.Count - 1].text = "";
            pinNumbers.RemoveAt(pinNumbers.Count - 1);
            loginButton.interactable = false;
            SetButtonNumbersState(true);
            errorText.SetActive(false);
        }      

    }

    public void Clear() {
        for (int i = 0; i < pinNumbersText.Length; i++)
        {
            pinNumbersText[i].text = "";
        }
        pinNumbers.Clear();
        SetButtonNumbersState(true);
        errorText.SetActive(false);
    }

    public void AuthUser() {        
        bool pass = authorization.CheckAuth(pinNumbersText[0].text + pinNumbersText[1].text + pinNumbersText[2].text + pinNumbersText[3].text);
        if (!pass)
        {
            errorText.SetActive(true);
        }
        else {
            userNameText.text = authorization.GetCurrentLogguedUserName();
            main.ShowMenu();
        }
    }
}
