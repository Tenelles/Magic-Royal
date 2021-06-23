using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform _target;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SetTarget(Transform target) => _target = target;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();    
    }


    private void Update()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        _spriteRenderer.flipX = direction.x < 0;
        transform.Translate(_speed * Time.deltaTime * direction);
    }
}
