using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    public float speedVariation = 0.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        //RubyCon controller = other.GetComponent<RubyCon>();
        PlayerController p = other.GetComponent<PlayerController>();

        if(p != null )
        {
            UnityEngine.Debug.Log("���ǵ� ������ ȹ��: " + speedVariation + " ��ȭ ");
            p.ChangePlayerSpeed(speedVariation);

            Destroy(gameObject);
        }
    }
}
