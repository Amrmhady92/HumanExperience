using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{

    public float speed = 2;
    public bool xOnly = false;
    public Vector2 outsideForce = Vector2.zero;
    private Rigidbody2D rb;
    [HideInInspector] public bool active = true;
    [HideInInspector] public float xDir, yDir = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {



        if (!active) return;

        xDir = 0;
        yDir = 0;

        if (Input.GetKey(KeyCode.W) && !xOnly)
        {
            yDir = 1;
        }
        if (Input.GetKey(KeyCode.S) && !xOnly)
        {
            yDir = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xDir = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xDir = -1;
        }

        rb.velocity = new Vector2(xDir * speed, yDir * speed) + outsideForce;

    }




}
