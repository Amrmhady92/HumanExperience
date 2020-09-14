using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject m_memoryWindow;
    private UnityEngine.Vector3 m_big   = new UnityEngine.Vector3(  1.3f,   .0f,    1f);
    private UnityEngine.Vector3 m_small = new UnityEngine.Vector3(  .0f,    .0f,    .0f);

    private UnityEngine.Vector3 m_start = new UnityEngine.Vector3(1.3f, .0f, 1f); //new UnityEngine.Vector3(.0f, .0f, .0f); 
    private UnityEngine.Vector3 m_end = new UnityEngine.Vector3(1.3f, .0f, 1f); //new UnityEngine.Vector3(.0f, .0f, .0f);

    private float m_time     =  .0f;
    private float m_duration = 2.5f;
    private float m_growDuration = 3.5f;
    private float m_disappearDuration = .5f;

    private bool m_isSmall = true;

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && m_time == 0)
        {
            if (m_isSmall)
               StartMemory();
            else
               EndMemory();
        }

        if (m_memoryWindow.transform.localScale.x != m_end.x)
        {
            m_time += Time.deltaTime / m_duration;

            //MemoryCam.orthographicSize = Mathf.SmoothStep(m_startSize, m_endSize, m_time);
            m_memoryWindow.transform.localScale = UnityEngine.Vector3.Lerp(m_start, m_end, m_time);

            //if (MemoryCam.orthographicSize == m_smallSize)
            //MemoryCam.enabled = false;
            if (m_memoryWindow.transform.localScale.x == m_end.x)
                m_time = .0f;
        }


    }


    private void StartMemory()
    {
        m_duration  = m_growDuration;
        m_isSmall   = false;
        m_start     = m_small;
        m_end       = m_big;
    }

    private void EndMemory()
    {
        m_duration  = m_disappearDuration;
        m_isSmall   = true;
        m_start     = m_big;
        m_end       = m_small;
    }












    //public Camera MemoryCam;
    //private float m_smallSize = 0.01f;
    //private float m_bigSize = 2.5f;
    //private float m_startSize;
    //private float m_endSize = 0.01f;
    //private float m_time;
    //private float m_duration = 5f;

    //private bool m_small = false;

    //private float m_startX;
    //private float m_startY;
    //private float m_startW;
    //private float m_startH;

    //private float m_endX;
    //private float m_endY;
    //private float m_endW;
    //private float m_endH;


    //private float m_smallX = 0.5f;
    //private float m_bigX = .0f;

    //private float m_smallY = .75f;
    //private float m_bigY = .5f;

    //private float m_smallH = .0f;
    //private float m_bigH = .5f;

    //private float m_smallW = .0f;
    //private float m_bigW = 1f;


    //private void Awake()
    //{
    //    //MemoryCam.orthographicSize = m_smallSize;
    //}

    //void FixedUpdate()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (m_small)
    //            StartMemory();
    //        else
    //            EndMemory();
    //    }

    //    if (MemoryCam.rect.x != m_endX)
    //    {
    //        m_time += Time.deltaTime / m_duration;

    //        //MemoryCam.orthographicSize = Mathf.SmoothStep(m_startSize, m_endSize, m_time);
    //        MemoryCam.rect = new Rect(Mathf.Lerp(m_startX, m_endX, m_time),
    //                                           Mathf.Lerp(m_startY, m_endY, m_time),
    //                                   Mathf.Lerp(m_startW, m_endW, m_time),
    //                                           Mathf.Lerp(m_startH, m_endH, m_time));

    //        //if (MemoryCam.orthographicSize == m_smallSize)
    //        //MemoryCam.enabled = false;
    //        if (MemoryCam.rect.x == m_bigX)
    //            m_small = false;
    //        else
    //            m_small = true;
    //    }
    //}

    //private void StartMemory()
    //{
    //    //MemoryCam.enabled = true;
    //    //m_endSize = m_bigSize;
    //    //m_startSize = m_smallSize;
    //    m_small = true;

    //    m_startX = m_smallX;
    //    m_startY = m_smallY;
    //    m_startH = m_smallH;
    //    m_startW = m_smallW;

    //    m_endX = m_bigX;
    //    m_endY = m_bigY;
    //    m_endH = m_bigH;
    //    m_endW = m_bigW;
    //}

    //private void EndMemory()
    //{
    //    //m_endSize = m_smallSize;
    //    //m_startSize = m_bigSize;
    //    m_small = false;

    //    m_startX = m_bigX;
    //    m_startY = m_bigY;
    //    m_startH = m_bigH;
    //    m_startW = m_bigW;

    //    m_endX = m_smallX;
    //    m_endY = m_smallY;
    //    m_endH = m_smallH;
    //    m_endW = m_smallW;
    //}
}
