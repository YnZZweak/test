using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicscheck : MonoBehaviour
{
    public float checkraduis;
    public bool isground;
    public LayerMask groundlayer;
    public Vector2 bottomoffest;
    private void Update()
    {
        check();  
    }
    public void check()
    {
        isground = Physics2D.OverlapCircle((Vector2)transform.position + bottomoffest,checkraduis,groundlayer); //����Ƿ���ײ
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomoffest, checkraduis); //���ڻ��Ƴ�������Ҫ���ķ�Χ
    }
}
