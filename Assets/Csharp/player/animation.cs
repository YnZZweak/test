using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private physicscheck physicscheck;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicscheck = GetComponent<physicscheck>();
    }
    private void Update()
    {
        setanimation();
    }
    public void trigger()
    {
        anim.SetTrigger("hurt");
    }
    public void setanimation() 
    {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("isground",physicscheck.isground);
    }
}
