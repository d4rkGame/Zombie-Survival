using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // SerializeField - атрибут для вывода полей в инспектор.
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;

    private void Update()
    {
        _controller.Move(GetDirection());
        Rotate();
    }

    private Vector3 GetDirection()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = transform.rotation * direction;

        direction *= Time.deltaTime * _speed;

        return direction;
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles -= new Vector3(0, _speedRotation * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles += new Vector3(0, _speedRotation * Time.deltaTime, 0);
        }
    }
}


