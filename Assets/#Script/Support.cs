using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour {

    [SerializeField] private float speed = 0;

	void Update () {
        Move();
	}

    void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Boundary")
            Destroy(gameObject);
    }
}
