using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeNavMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _range;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;

    Transform _player;

    private void Start()
    {
        _player = FindObjectOfType<Motion>().transform;
        _agent.SetDestination(_player.position);
        SetNewPoint();

    }

    private void Update()
    {

        //float distanceToDestination = Vector3.Distance(transform.position, _agent.destination);

        if (_agent.remainingDistance < 1)
        {
            SetNewPoint();
        }
        else
        {
            _agent.isStopped = false;
            _animator.SetFloat("Speed", _rb.velocity.magnitude);
        }

    }

    private void SetNewPoint()
    {
        Vector3 point = FindRandomPoint();
        _agent.SetDestination(point);
    }

    private Vector3 FindRandomPoint()
    {
        int counter = 5;
        Vector3 position;
        do
        {
            Vector2 point = Random.insideUnitCircle;

            if (Mathf.Abs(point.x) < 0.5f)
            {
                point.x += 2;
            }

            if (Mathf.Abs(point.y) < 0.5f)
            {
                point.y += 2;
            }

            position = new Vector3(point.x, 0, point.y) * _range;
            position += _player.position;
            counter--;
        }
        while (!_agent.Raycast(position, out var hit) && counter > 0) ;

        return position;
    }
}
