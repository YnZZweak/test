using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class character : MonoBehaviour
{
    public float maxhealth;
    public float health;
    public float nodamage;
    private float nodamagetimer;
    public bool isnodamage = false;
    public UnityEvent<Transform> ontakedamage;
    private void Start()
    {
        health = maxhealth;
    }

    private void Update()
    {
        if (isnodamage)
        {
            nodamagetimer -= Time.deltaTime;
            if (nodamagetimer <= 0)
                isnodamage=false;
        }
    }

    public void takedamage(attack attacker) 
    {
        if (isnodamage)
            return;
        health -= attacker.damage;
        
        isnodamage = true;
        nodamagetimer = nodamage;
        ontakedamage?.Invoke(attacker.transform);
    }
    public void takedamage1(cherry cherry)
    {
        if (isnodamage)
            return;
        health -= cherry.damage;

        isnodamage = true;
        nodamagetimer = nodamage;
       
    }



}
