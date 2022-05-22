using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public float DestroyTime = 0;

    private void Awake()
    {
        Destroy(this.gameObject, DestroyTime);
    }
}
