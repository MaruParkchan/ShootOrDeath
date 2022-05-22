using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

    [SerializeField] private GameObject fadeOutObject;
    [SerializeField] private GameObject creditObject;

    public void StartButton()
    {
        fadeOutObject.SetActive(true);
        Invoke("StartGame", 3.0f);
    }

    public void CreditButton()
    {
        creditObject.SetActive(true);
    }

    public void CloseWindow()
    {
        creditObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

   
}
