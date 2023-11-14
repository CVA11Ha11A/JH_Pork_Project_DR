using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolisherWall : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DestroyTime());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("EventWall"))
        {
            Destroy(collision.gameObject);
            //Debug.Log($"�ı� �Ȱ� �ֳ�? -> {collision.gameObject.name}");
        }
    }

    IEnumerator DestroyTime()
    {
        for (int i = 0; i < 5; i++)
        {
            if(this.gameObject.activeSelf == true)
            {
                this.gameObject.SetActive(false);
            }
            else if(this.gameObject.activeSelf == false)
            {
                this.gameObject.SetActive(true);
            }
            yield return null;
        }


        for (int i = 0; i < 10; i++)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }

}   //ClassEnd
