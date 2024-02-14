using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Vector3 _moveVector;
    private CharacterController _characterController;
    private float _fallvelocity = 0;
    public float gravity = 9.8f;
    public float Speed;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveVector = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        
    }

    private void FixedUpdate()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);
        _fallvelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallvelocity * Time.fixedDeltaTime);
        




    }
}
