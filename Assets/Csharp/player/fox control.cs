using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
public class foxcontrol : MonoBehaviour
{
    public input inputaction;
    //public PlayerInput playerInput;
    public Vector2 move;
    private Rigidbody2D rb;
    public physicscheck physicscheck;
    public float speed;
    public float jumpForce;
    private int jumpnum1 = 3;
    private float lastnum1 = 0;
    public GameObject cherry1;
    public AudioSource audiosource;
    public AudioClip jumpaudio;
    public AudioClip shootaudio;




    private void Awake()
    {
        inputaction = new input();
        //playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();

        inputaction.Player.Jump.started += jump;    //performed表示长按
        inputaction.Player.shoot.started += shoot;

        physicscheck = GetComponent<physicscheck>();
        audiosource = GetComponent<AudioSource>();
    }
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log(other.name);
    //}


    private void OnEnable() 
    {
     inputaction.Enable();   
    }
    private void OnDisable() 
    {
     inputaction.Disable();   
    }
   
        private void Update()
    {
        
        
        move = inputaction.Player.Move.ReadValue<Vector2>();   
        //move = playerInput.actions["Move"].ReadValue<Vector2>();
       // Debug.Log(move.x);
       // Debug.Log(playerInput.actions["Move"]);
        //rb.velocity = move;       
    }
    public void shoot(InputAction.CallbackContext obj)
    {       
            GameObject cherry = Instantiate(cherry1, rb.position, Quaternion.identity);
        audiosource.PlayOneShot(shootaudio, 0.7F);
    }
    private void FixedUpdate()
    {
        Run();
    }
    private void Run()
    {
        rb.velocity = new Vector2(move.x*speed*Time.deltaTime,rb.velocity.y); 
        int turnaround = (int)transform.localScale.x;
        //图片锚点决定翻转方向  
        if (move.x > 0)
            turnaround = 1;
        if (move.x < 0)
            turnaround = -1;
        transform.localScale = new Vector3(turnaround,1,1);
    }
    private void jump(InputAction.CallbackContext obj)
    {
        //Debug.Log("Jump");
        if (physicscheck.isground) //第一种三段跳
            lastnum1 = jumpnum1;
        if (lastnum1 != 0)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            lastnum1 = lastnum1 - 1;
            audiosource.PlayOneShot(jumpaudio, 0.7F);
            
            //audiosource.Play();
        }
        else
        {
            return;
        }

        //if (physicscheck.isground) //第二种三段跳
        //{
        //    lastnum1 = jumpnum1;
        //    jumpForce = 10;
        //}
        //if (lastnum1 != 0)
        //{
        //    rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        //    lastnum1 = lastnum1 - 1;
        //}
        //else
        //{
        //    jumpForce = 0;
        //}

    }



}
