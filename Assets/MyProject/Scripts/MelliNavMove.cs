using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MelliNavMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;

    public void Stop() => UpdateSpeed(0);

    public void Move(Health target)
    {
        _agent.SetDestination(target.transform.position);
        UpdateSpeed(1);

    }

    private void Update() => UpdateSpeed(_rb.velocity.magnitude);
    public void UpdateSpeed(float speed)
    {
        if (speed <= 0.1f)
        {
            _agent.isStopped = true;
            _animator.SetFloat("Speed", speed);

        }
        else
        {
            _agent.isStopped = false;
            _animator.SetFloat("Speed", speed);
        }


    }
}
