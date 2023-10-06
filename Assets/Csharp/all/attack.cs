using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public int damage;
    public int attackrange;
    public int attackrate;
    public void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<character>()?.takedamage(this);
    }
}
