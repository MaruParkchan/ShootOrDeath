using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour {

    [SerializeField] private GameObject fadeOutImage;

    public void FadeOut()
    {
        fadeOutImage.SetActive(true);
    }

    public void GameClearChange()
    {
        SceneManager.LoadScene("GameClear");
    }
}
