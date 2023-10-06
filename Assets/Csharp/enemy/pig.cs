using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float speed;
    Animator anim;
    Rigidbody2D rb;
    public Vector3 facedirector;
    character health;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<character>();
    }
    private void Update()
    {
        facedirector = new Vector3(transform.localScale.x,0,0);
        setanimation();
    }
    public void FixedUpdate()
    {
        Move();
       
    }
    public void Move()
    {
        rb.velocity = new Vector2 (speed*facedirector.x*Time.deltaTime,rb.velocity.y);
    }
    public void Destroy ()
    {
        if (health.health <= 0) 
        Destroy(this.gameObject);
    }
    public void setanimation()
    {
        anim.SetFloat("health", health.health);
  
    }
}
