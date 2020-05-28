﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = 1f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float horizontalInPut = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInPut, 0, 0);
        var velocity = direction * _speed;

        if(_controller.isGrounded)
        {
            // jump 
        }
        else
        {
            velocity.y -= _gravity;
        }


        _controller.Move(velocity * Time.deltaTime);

    }
}
