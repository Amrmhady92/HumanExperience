using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    public MemoryPuller testPuller;
    public GameObject playerCharacter;
    public SoundManager soundManager;


    public GameObject charImage;


    private bool initialized = false;

    public static GameHandler Instance
    {
        get
        {
            return instance;
        }
    }




    private void Start()
    {
        if (Instance == null) instance = this;
        if (soundManager == null) soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ActivateMemories();
        }
    }

    private void ActivateMemories()
    {
        testPuller.OpenPortal();
    }

    public void InitPlayer()
    {
        if (!initialized)
        {
            initialized = true;
            charImage.SetActive(true);
        }
    }

}
