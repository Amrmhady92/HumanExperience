using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryScene : MonoBehaviour
{

    public bool deactivateOnStart = true;
    public GameObject sceneEntryPortal;
    public List<GameObject> sceneObjects;


    static List<MemoryScene> memoryScenes;


    public bool active = false;

    public int id = -1;



    public static List<MemoryScene> MemoryScenes
    {
        get
        {
            if (memoryScenes == null) memoryScenes = new List<MemoryScene>();
            return memoryScenes;
        }
    }

    public static void ActivateMemoryScenePortal(int scnID)
    {
        MemoryScene activeScene = null;
        MemoryScene nextScene = null;

        bool found = false;
        if (MemoryScenes != null) 
        {
            for (int i = 0; i < MemoryScenes.Count; i++)
            {
                if (MemoryScenes[i] != null)
                {
                    if (MemoryScenes[i].id == scnID)
                    {
                        //MemoryScenes[i].gameObject.SetActive(true);
                        //GameHandler.Instance.playerCharacter.transform.position = MemoryScenes[i].startPosition.position;
                        //GameHandler.Instance.memoryCamera.transform.position = new Vector3(MemoryScenes[i].startPosition.position.x, MemoryScenes[i].startPosition.position.y, GameHandler.Instance.memoryCamera.transform.position.z);
                        //GameHandler.Instance.playerCharacter.GetComponent<CharacterController>().active = true;

                        nextScene = MemoryScenes[i];
                        found = true;



                    }
                    else if (MemoryScenes[i].active) activeScene = MemoryScenes[i];
                    else MemoryScenes[i].gameObject.SetActive(false);
                }
            }
        }
        if (!found)
        {
            Debug.LogError("Scene Not Found");
            return;
        }

        if(nextScene != null && activeScene != null)
        {
            Debug.Log("Openning Scene\nNextScene "+nextScene.name+"\nActiveScene "+activeScene);
            Canvas nextSceneCanvas = nextScene.sceneEntryPortal.GetComponent<Canvas>();
            if(nextSceneCanvas != null)
            {
                LeanTween.size(nextSceneCanvas.GetComponent<RectTransform>(), Vector2.one * 100, 5f).setOnComplete(() => 
                {
                    nextSceneCanvas.gameObject.SetActive(false);
                    GameHandler.Instance.playerCharacter.GetComponent<CharacterController>().active = true;
                    activeScene.gameObject.SetActive(false);
                });
            }
        }
        else
        {
            Debug.LogError("Active Scene " + activeScene + " \nNext Scene " + nextScene);
        }

    }




    private void Awake()
    {
        if (!MemoryScenes.Contains(this)) MemoryScenes.Add(this);
        if (deactivateOnStart) this.gameObject.SetActive(false);
        if(sceneObjects != null)
        {
            for (int i = 0; i < sceneObjects.Count; i++)
            {
                sceneObjects[i].SetActive(true);
            }
        }
        
    }

    private void OnDestroy()
    {
        if (MemoryScenes != null && !MemoryScenes.Contains(this))
        {
            MemoryScenes.Remove(this);
        }
    }
}
