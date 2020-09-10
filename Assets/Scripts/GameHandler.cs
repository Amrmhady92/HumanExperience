using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    public MemoryPuller testPuller;
    public GameObject playerCharacter;
    public GameObject memoryCamera;

    public SpriteRenderer darkFader;

    float alpha = 0;

    public static GameHandler Instance
    {
        get
        {
            return instance;
        }
    }


    public void FadeOut()
    {

    }

    public void FadeIn()
    {

    }

    IEnumerator Fade(bool fadeIn)
    {
        if (fadeIn)
        {
            alpha += 0.1f;
        }
        else //fade out
        {
            alpha -= 0.1f;
        }

        darkFader.color = new Color(0, 0, 0, alpha);
        
        yield return new WaitForEndOfFrame();

    }
    
    
    private void Start()
    {
        if (Instance == null) instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            testPuller.Active = true;
        }
    }
}
