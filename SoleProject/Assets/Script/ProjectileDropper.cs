using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ProjectileObj;
    [SerializeField]
    private GameObject RangeObj;

    BoxCollider2D boxCollider2d;

    public float dropDelay=0.0f;

    void Awake()
    {
        boxCollider2d = RangeObj.GetComponent<BoxCollider2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropProjectileRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator DropProjectileRoutine()
    {
        while (true)
        {
            DropProjectile();
            yield return new WaitForSeconds(dropDelay);
            
        }
    }


    private void DropProjectile()
    {
            Instantiate(ProjectileObj, ReturnRandomPos(), Quaternion.identity);
    }

    Vector3 ReturnRandomPos()
    {
        Vector3 originPos = RangeObj.transform.position;

        // float rangeX = boxCollider2d.transform.localScale.x;
        float rangeX = boxCollider2d.bounds.size.x;
        float rangeY = boxCollider2d.transform.localScale.y;

        rangeX = Random.Range((rangeX / 2.0f) * -1.0f, rangeX / 2.0f);
        
        Vector3 RandomPos = new Vector3(rangeX, rangeY-1, 0.0f);

        Vector3 respawnPos = originPos + RandomPos;

        return respawnPos; 
    }
}
