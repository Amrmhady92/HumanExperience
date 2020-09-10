using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;


    public GameObject playerCharacter;
    public GameObject memoryCamera;




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
    private void Start()
    {
        if (Instance == null) instance = this;
    }
}
