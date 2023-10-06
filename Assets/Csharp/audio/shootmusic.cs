using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class shootmusic : MonoBehaviour
{
    public input inputaction;
    public AudioSource audiosource;
    private void Awake()
    {
        inputaction = new input();
        inputaction.Player.shoot.started += shoot;
    }
    public void shoot(InputAction.CallbackContext obj)
    {
        audiosource.Play();
    }
}
