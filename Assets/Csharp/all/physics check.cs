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
        isground = Physics2D.OverlapCircle((Vector2)transform.position + bottomoffest,checkraduis,groundlayer); //检测是否碰撞
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomoffest, checkraduis); //用于绘制场景中想要检测的范围
    }
}
