using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWall : MonoBehaviour
{

    private void Awake()
    {
        
    }


    void Start()
    {
        StartSetWallPosition();
    }


    // ������Ʈ ������ Ray�� ��Ƽ� ���� �������� ���� Ƣ����� ���� �Լ�
    private void StartSetWallPosition()
    {
        // Ray������
        RaycastHit hitInfo;
        if(Physics.Raycast(this.transform.position, Vector3.forward,out hitInfo,Mathf.Infinity))
        {
            //hitInfo.
        }
    }       // StartSetWallPosition()


}
