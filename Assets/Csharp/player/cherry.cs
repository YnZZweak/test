using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cherry : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float damage;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (gameObject.transform.position.magnitude > 10)
        {
            Destroy(gameObject);
        }

        transform.Translate(new Vector3(speed*Time.deltaTime, 0, 0));
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<character>()?.takedamage1(this);
    }
    


}
