using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]public struct PortalCombination
{
    public GameObject m_portal;
    public GameObject m_key1;
    public GameObject m_key2;
}

public class ActivationHandler : MonoBehaviour
{
    public List<GameObject>    m_Activatables = new List<GameObject>();
    public List<bool>          m_IsActive     = new List<bool>();

    public List<PortalCombination> m_portalCombinations = new List<PortalCombination>();

    public List<GameObject> m_activeKeys = new List<GameObject>();

    public Color m_activeColor;
    public Color m_inactiveColor;


    private void Awake()
    {
        foreach (GameObject m_Activatable in m_Activatables)
        {
            m_IsActive.Add(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Activate(GameObject inActivatable)
    {
        int i = m_Activatables.IndexOf(inActivatable);

        if(i != -1)
        {
            m_IsActive[i] = !m_IsActive[i];
            
            if (m_IsActive[i])
                m_Activatables[i].transform.Find("Aura").GetComponent<SpriteRenderer>().color = m_activeColor;
            else
                m_Activatables[i].transform.Find("Aura").GetComponent<SpriteRenderer>().color = m_inactiveColor;

            
            if(!m_activeKeys.Contains(inActivatable))
            {
                if (!m_activeKeys.Any() || m_activeKeys.Count != 2)
                    m_activeKeys.Add(inActivatable);
                else
                {
                    m_activeKeys[0].transform.Find("Aura").GetComponent<SpriteRenderer>().color = m_inactiveColor;
                    m_IsActive[m_Activatables.IndexOf(m_activeKeys[0])] = false;
                    m_activeKeys.RemoveAt(0);
                    m_activeKeys.TrimExcess();
                    m_activeKeys.Add(inActivatable);
                }
            }
            else
            {
                m_activeKeys.RemoveAt(m_activeKeys.IndexOf(inActivatable));
                m_activeKeys.TrimExcess();
            }

        }


        foreach (PortalCombination combination in m_portalCombinations)
        {
            int j = 0;
            if ((m_IsActive[m_Activatables.IndexOf(m_portalCombinations[j].m_key1)] && !m_IsActive[m_Activatables.IndexOf(m_portalCombinations[j].m_key2)]) ||
                (!m_IsActive[m_Activatables.IndexOf(m_portalCombinations[j].m_key1)] && m_IsActive[m_Activatables.IndexOf(m_portalCombinations[j].m_key2)]) &&
                 m_activeKeys.Count != 2)
            {
                Debug.Log("The portal is Opening");
                m_portalCombinations[j].m_portal.SetActive(false);
            }
            else if (m_IsActive[m_Activatables.IndexOf(m_portalCombinations[j].m_key1)] && m_IsActive[m_Activatables.IndexOf(m_portalCombinations[j].m_key2)])
                m_portalCombinations[j].m_portal.SetActive(true);
            else
                m_portalCombinations[j].m_portal.SetActive(false);
            j++;
        }
    }


}
