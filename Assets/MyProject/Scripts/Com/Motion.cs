using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInp _inputm;
    private Camera _camera;

    private void Start() => _camera = Camera.main;

    void Update()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (_inputm.Motion.sqrMagnitude > 0.05f)
        {
            var direction = _camera.transform.TransformDirection(_inputm.Motion);
            direction.y = 0;
            direction.Normalize();

            transform.forward = direction;
            direction += Physics.gravity;

            _controller.Move(direction * _speed * Time.deltaTime);
            _animator.SetFloat("Speed", _controller.velocity.magnitude);
        }
        else
        {
            _animator.SetFloat("Speed", _inputm.Motion.magnitude);
        }

        
    }
}