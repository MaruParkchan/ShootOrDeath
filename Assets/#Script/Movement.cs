using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [Header("스피드 최소 , 최대값")]
    [SerializeField] private float minSpeed = 0;
    [SerializeField] private float maxSpeed = 0;
    [SerializeField] private float speed = 0;

    private Rigidbody2D rigidbody2d;
    private Vector3 pos;
    private float rotatePower;
    private bool isHit = false;
    public bool IsHit { get { return isHit; } set { isHit = value; } }

    private void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rigidbody2d = GetComponent<Rigidbody2D>();
        pos = new Vector3(Random.Range(10f, 20f), Random.Range(-30, 30f), 0);
        rotatePower = 300;
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
	
	public void Update()
    {
        if (isHit)
            FlyBounce();

        else
            Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
    }

    private void FlyBounce()
    {
        transform.Rotate(0, 0, rotatePower * Time.deltaTime * 5.0f);
        transform.position += pos * Time.deltaTime;
        Destroy(gameObject, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Crazy")
            isHit = true;
    }

}
