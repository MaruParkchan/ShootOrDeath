using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour {

    [SerializeField] GameObject aim;

    private void Awake()
    {
        Application.runInBackground = true;
        Cursor.visible = true;
    }

}
