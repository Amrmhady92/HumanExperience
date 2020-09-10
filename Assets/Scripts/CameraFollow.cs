using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject   m_memoryPlayer;
    public Camera       m_memoryCamera;
    public float        m_speed = 0.25f;


    public float smoothTime = 0.5f;
    private UnityEngine.Vector3 velocity = UnityEngine.Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //m_memoryCamera.gameObject.transform.position = new UnityEngine.Vector3(m_memoryPlayer.transform.position.x / 2, 0, -10);
        m_memoryCamera.gameObject.transform.position = UnityEngine.Vector3.Lerp(new UnityEngine.Vector3(m_memoryCamera.gameObject.transform.position.x,
                                                                                                        m_memoryCamera.gameObject.transform.position.y,
                                                                                                        - 10),
                                                                                new UnityEngine.Vector3(m_memoryPlayer.transform.position.x,
                                                                                                        m_memoryPlayer.transform.position.y,
                                                                                                        - 10),
                                                                                Time.deltaTime / m_speed); 

        //// Define a target position above and behind the target transform
        //UnityEngine.Vector3 targetPosition = m_memoryPlayer.transform.TransformPoint(new UnityEngine.Vector3(0, 0, -10));

        //// Smoothly move the camera towards that target position
        //m_memoryCamera.gameObject.transform.position = UnityEngine.Vector3.SmoothDamp(m_memoryCamera.gameObject.transform.position, targetPosition, ref velocity, smoothTime);
    }
}
