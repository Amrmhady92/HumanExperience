using System;
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
    [SerializeField] bool active = false;

    bool open = false;
    bool trapped = false;

    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }

    private void Update()
    {
        if (!Active) return;
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
                    player.active = false;
                    player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    MemoryScene.ActivateMemoryScenePortal(memorySceneId);
                    Active = false;
                }
            }
        }
    }

    public void OpenPortal(float time = 2f, Action callback = null)
    {
        Canvas canv = this.gameObject.GetComponent<Canvas>();
        LeanTween.cancelAll();
        LeanTween.size(canv.GetComponent<RectTransform>(), Vector2.one * 5, time).setOnComplete(() =>
        {
            callback?.Invoke();
            Active = true;
        });
    }

    public void OpenMiniPortal(float time = 2f, Action callback = null)
    {
        Canvas canv = this.gameObject.GetComponent<Canvas>();
        LeanTween.cancelAll();
        LeanTween.size(canv.GetComponent<RectTransform>(), Vector2.one * 1, time).setOnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void ClosePortal(float time = 0.5f, Action callback = null)
    {
        Active = false;
        Canvas canv = this.gameObject.GetComponent<Canvas>();
        LeanTween.cancelAll();
        LeanTween.size(canv.GetComponent<RectTransform>(), Vector2.zero, time).setOnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>() != null)
        {
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
