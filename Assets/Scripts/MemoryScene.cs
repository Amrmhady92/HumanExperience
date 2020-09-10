using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryScene : MonoBehaviour
{

    static List<MemoryScene> memoryScenes;

    public int id = -1;
    public Transform startPosition;

    public static List<MemoryScene> MemoryScenes
    {
        get
        {
            if (memoryScenes == null) memoryScenes = new List<MemoryScene>();
            return memoryScenes;
        }
    }

    public static void ActivateMemoryScene(int scnID)
    {
        bool found = false;
        if (MemoryScenes != null) 
        {
            for (int i = 0; i < MemoryScenes.Count; i++)
            {
                if (MemoryScenes[i] != null)
                {
                    if (MemoryScenes[i].id == scnID)
                    {
                        MemoryScenes[i].gameObject.SetActive(true);
                        GameHandler.Instance.playerCharacter.transform.position = MemoryScenes[i].startPosition.position;
                        GameHandler.Instance.memoryCamera.transform.position = new Vector3(MemoryScenes[i].startPosition.position.x, MemoryScenes[i].startPosition.position.y, GameHandler.Instance.memoryCamera.transform.position.z);
                        GameHandler.Instance.playerCharacter.GetComponent<CharacterController>().active = true;

                        found = true;
                    }
                    else memoryScenes[i].gameObject.SetActive(false);
                }
            }
        }
        if (!found) Debug.LogError("Scene Not Found");
    }

    private void Awake()
    {
        if(!MemoryScenes.Contains(this)) MemoryScenes.Add(this);
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (MemoryScenes != null && !MemoryScenes.Contains(this))
        {
            MemoryScenes.Remove(this);
        }
    }
}
