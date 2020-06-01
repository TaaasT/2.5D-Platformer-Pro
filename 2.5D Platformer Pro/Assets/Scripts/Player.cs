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
    [SerializeField]
    private int _coins;
    private UIManager _uIManager;
    [SerializeField]
    private int _lives = 3;

    private bool _canDoubleJump;
    private bool _grounded;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uIManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }

        _uIManager.UpdateLivesDisplay(_lives);
    }

    private void Update()
    {
        _grounded = _controller.isGrounded;

        if (_grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }

        }

       if(!_grounded && _canDoubleJump)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
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

    public void AddCoins()
    {
        _coins++;

        _uIManager.UpdateCoinDisplay(_coins);
    }

}
