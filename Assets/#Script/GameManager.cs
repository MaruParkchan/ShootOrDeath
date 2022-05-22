using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private LightControl lightControl;
 
    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (DataController.isDie != true)
        {
            player.Updated();
            lightControl.Updated();
        }
        else
        {         
            Cursor.visible = true;
        }
    }
}
