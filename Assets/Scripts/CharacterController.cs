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

    private Collider2D m_collider;
    public GameObject m_activationHandler;
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
        if (Input.GetKeyDown(KeyCode.E) && m_collider != null)
        {
            m_activationHandler.SendMessage("Activate", m_collider.gameObject);
        }

        //if (m_collider != null)
        //{
        //    m_activationHandler.SendMessage("Activate", m_collider.gameObject);
        //    m_collider = null;
        //}

        rb.velocity = new Vector2(xDir * speed, yDir * speed) + outsideForce;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Activatable")
        {
            Debug.Log("Sup");
            m_collider = collider;
        }
    }

    //private void OnCollisioEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Activatable")
    //    {
    //        Debug.Log("Sup");
    //        m_collision = collision;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_collider = null;
    }

}
