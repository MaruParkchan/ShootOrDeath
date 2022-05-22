using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {

    [SerializeField] private float cutChangeTime;

    private void Update()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        cutChangeTime -= Time.deltaTime;

        if (cutChangeTime <= 0)
            SceneManager.LoadScene("Scene01");
    }
}
