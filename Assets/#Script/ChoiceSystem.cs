using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceSystem : MonoBehaviour {

    [SerializeField] private int powerValue;
    [SerializeField] private int speedValue;

    private void Awake()
    {
        PlayerPrefs.SetInt("Power", 1);
        PlayerPrefs.SetFloat("Speed", 1);
    }

    public void LevelUpSpeed()
    {
        PlayerPrefs.SetFloat("Speed", speedValue);
        NextScene();
    }

    public void LevelUpPower()
    {
        PlayerPrefs.SetInt("Power", powerValue);
        NextScene();
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Scene01");
    }
}
