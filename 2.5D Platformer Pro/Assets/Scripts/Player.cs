using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = 1f;
    [SerializeField]
    private float _jumpHeight = 15f;
    private float _yVelocity;


    private bool _grounded;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _grounded = _controller.isGrounded;

        if (_grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
        }
    }

    void FixedUpdate()
    {
        float horizontalInPut = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInPut, 0, 0);
        var velocity = direction * _speed;

       
        if(!_grounded)
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);

    }

}
