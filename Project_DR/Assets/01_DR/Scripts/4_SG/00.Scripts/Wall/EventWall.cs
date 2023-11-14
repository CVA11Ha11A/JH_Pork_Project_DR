using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWall : MonoBehaviour
{
    public bool isLeft, isRight, isUp, isDown = false;
    private FloorMeshPos floorMesh = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (floorMesh == null)
            {
                floorMesh = collision.gameObject.GetComponent<FloorMeshPos>();
                EventWallPosExamine();
            }
        }


    }       // OnCollisioinEnter()


    // �̺�Ʈ�� ��ġ �˼�
    private void EventWallPosExamine()
    {
        // �̺�Ʈ ���� �������� ���������� �˼�
        if (this.transform.position.x == floorMesh.bottomLeftCorner.x)
        {       // ���� �ϴ� �������� �������� �������
            isLeft = true;
        }
        else if (this.transform.position.x == floorMesh.bottomRightCorner.x)
        {       // ������ �ϴ� �������� �������� �������
            isRight = true;
        }
        if (this.transform.position.z == floorMesh.topLeftCorner.z)
        {       // ����� ���̿� �������
            isUp = true;
        }
        else if (this.transform.position.z == floorMesh.bottomLeftCorner.z)
        {       // �ϴ��� ���̿� �������
            isDown = true;
        }
        EventWallPosSet();

    }       // EventWallPosExamine()

    private void EventWallPosSet()
    {
        Vector3 setPos;
        setPos = this.transform.position;
        if (isLeft == true)
        {
            setPos.x += 0.5f;
            this.transform.position = setPos;
        }
        if (isRight == true)
        {
            setPos.x -= 0.5f;
            this.transform.position = setPos;
        }
        if (isUp == true)
        {
            setPos.z -= 0.5f;
            this.transform.position = setPos;
        }
        if (isDown == true)
        {
            setPos.z += 0.5f;
            this.transform.position = setPos;
        }        
        EventWallScaleSet();
    }       // EventWallPosSet()


    // �ڽ��� ��ġ�� ���� Sclae�� �ٲ��ִ� �Լ�
    private void EventWallScaleSet()
    {
        Vector3 setSclae;
        if (isLeft == true)
        {
            setSclae = this.transform.localScale;
            setSclae.z = 3f;
            this.transform.localScale = setSclae;
        }
        if (isRight == true)
        {
            setSclae = this.transform.localScale;
            setSclae.z = 3f;
            this.transform.localScale = setSclae;
        }
        if (isUp == true)
        {
            setSclae = this.transform.localScale;
            setSclae.x = 3f;
            this.transform.localScale = setSclae;
        }
        if (isDown == true)
        {
            setSclae = this.transform.localScale;
            setSclae.x = 3f;
            this.transform.localScale = setSclae;
        }
        MakeChildrenObjects();

    }       // EventWallScaleSet()

    // ���� �� obj�� �ڽ��� �ڽĿ�����Ʈ�� ����� �Լ�
    private void MakeChildrenObjects()
    {
        RaycastHit hit;
        float maxDis = 1f;
        if (isLeft == true || isRight == true)
        {       // �̺�Ʈ���� ���� Ȥ�� �����ʿ� �ִٸ� -> ����,�Ĺ� ���̸� ��
            if (Physics.Raycast(this.transform.position,Vector3.forward,out hit, maxDis))
            {             
                hit.collider.transform.parent = this.transform;
            }
            if (Physics.Raycast(this.transform.position, Vector3.back, out hit, maxDis))
            {             
                hit.collider.transform.parent = this.transform;
            }            
        }
        else if(isUp == true || isDown == true)
        {       // �̺�Ʈ���� ���� Ȥ�� �Ʒ��ʿ� �ִٸ� -> ��,�� ���̸���
            if (Physics.Raycast(this.transform.position, Vector3.left, out hit, maxDis))
            {             
                hit.collider.transform.parent = this.transform;
            }
            if (Physics.Raycast(this.transform.position, Vector3.right, out hit, maxDis))
            {                
                hit.collider.transform.parent = this.transform;
            }
        }

    }       // MakeChildrenObjects()
}       // ClassEnd
