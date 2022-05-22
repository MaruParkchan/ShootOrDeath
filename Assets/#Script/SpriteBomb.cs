using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBomb : MonoBehaviour {

    [SerializeField] Sprite[] sprite;
    private SpriteRenderer render;
    private Rigidbody2D rigidbody2D;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnDie()
    {
        for(int i = 0; i < sprite.Length; i++)
        {
            render.sprite = sprite[i];
            GameObject clone = Instantiate(this.gameObject);
            clone.transform.position = transform.position;
          //  clone.transform.GetComponent<Rigidbody2D>().
        }
    }
}
