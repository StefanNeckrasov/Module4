using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyBrain : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private MelliNavMove _move;
    [SerializeField] private EnamyAttack _attack;

    private Health _target;

    void Start() => _target = FindObjectOfType<Motion>().transform.GetComponent<Health>();


    private void Update()
    {
        if (_attack.TRange(_target))
        {
            _move.Stop();
            _attack.Attack();
        }
        else
        {
            _move.Move(_target);

        }
        
    }
}
