using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool CanAttack => _attackTime <= 0;

    [SerializeField] private LayerMask _damageMask;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInp _inputm;

    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _damage;
    [SerializeField] private float _radius;
    Collider[] _hits = new Collider[3];
    private float _attackTime;

    private void Start() => RestartAttack();

    void Update()
    {
        if (!CanAttack)
        {
            _attackTime -= Time.deltaTime;
        }

        if (_inputm.PressedAttack && CanAttack)
        {
            var index = Random.Range(0, 3);
            _animator.SetInteger("AttackIndex", index);
            _animator.SetTrigger("Attack");
            RestartAttack();
            AttackNearEnamies();
        }

    }

    private void AttackNearEnamies()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, _radius, _hits, _damageMask);

        for (int i = 0; i < count; ++i)
        {
            if (_hits[i].TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(_damage);
            }
        }
    }

    private void RestartAttack() => _attackTime = _attackCooldown;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
