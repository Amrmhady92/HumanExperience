using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPuller : MonoBehaviour
{

    public int memorySceneId = 0;
    public float forcePower = 2;
    CharacterController player;
    bool pulling = false;
    float distance;
    Vector2 direction;

    bool trapped = false;
    private void Update()
    {
        if (pulling)
        {
            distance = Vector2.Distance(this.transform.position, player.transform.position) + 0.05f;
            if(distance > 0.1f)
            {
                direction = this.transform.position - player.transform.position;
                player.outsideForce = (direction.normalized * forcePower / distance);
            }
            else
            {
                player.outsideForce = Vector2.zero;

                if (!trapped)
                {
                    trapped = true;
                    Debug.Log("Trapped/ changing scene");
                    Debug.Log("Fading out");
                    player.active = false;
                    player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    MemoryScene.ActivateMemoryScene(memorySceneId);
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>() != null)
        {
            Debug.Log("Enter");

            if (player == null) player = collision.GetComponent<CharacterController>();
            if (player == null)
            {
                Debug.LogError("No Rigid Body");
                return;
            }
            pulling = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>() != null)
        {
            Debug.Log("Exit");
            if (player == null) player = collision.GetComponent<CharacterController>();
            if (player == null)
            {
                Debug.LogError("No Rigid Body");
                return;
            }
            player.outsideForce = Vector2.zero;
            pulling = false;
        }
    }

}
