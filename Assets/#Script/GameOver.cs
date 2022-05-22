using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    [SerializeField] private GameObject clone;

	public void RestartGame()
    {
        clone.SetActive(false);
        SceneManager.LoadScene("Scene01");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Intro");
    }
}
