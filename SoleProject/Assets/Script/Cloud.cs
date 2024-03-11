using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Transform m_tr;

    public Vector2 cloudSize = new Vector2(1.0f, 1.0f);

    public float halfSize = 1.0f;

    public LayerMask m_LayerMask = -1;

    


    // Update is called once per frame
    void Update()
    {
         //Collider2D[] cols = Physics2D.OverlapCircle(m_tr.position, halfSize, m_LayerMask);

        Collider2D[] cols = Physics2D.OverlapBoxAll(m_tr.position, cloudSize * 0.5f, m_tr.eulerAngles.z * Mathf.Deg2Rad, m_LayerMask);

        foreach (Collider2D col in cols)
        {
            PlayerController p = col.GetComponent<PlayerController>();

            
            
            if(p != null)
            {
                if(p.GetisFly())
                {
                    p.MoreJump();
                    UnityEngine.Debug.Log("isFly . false");
                }

            }

        }
    }

    private void OnDrawGizmos()
    {
        if (m_tr != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(m_tr.position, cloudSize);
            //Gizmos.DrawSphere(m_tr.position, halfSize);
        }
    }

}
