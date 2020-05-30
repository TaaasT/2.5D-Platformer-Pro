using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private bool _switching;

    private float _speed = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }
        else if(_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        if(transform.position == _targetA.position)
        {
            _switching = true;  
        }
        else if(transform.position == _targetB.position)
        {
            _switching = false;
        }

    }

}
