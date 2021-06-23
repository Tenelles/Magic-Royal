using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class KeyboardMoving : MonoBehaviour
    {
        [SerializeField]
        [Range(0f, 10f)]
        private float _speed;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 direction = CalculateDirection();

            if (direction.sqrMagnitude < Mathf.Epsilon)
                return;

            transform.Translate(direction * _speed * Time.deltaTime);
            _spriteRenderer.flipX = direction.x < 0;
        }

        private Vector2 CalculateDirection()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            return new Vector2(horizontalInput, verticalInput).normalized;
        }



    }
}