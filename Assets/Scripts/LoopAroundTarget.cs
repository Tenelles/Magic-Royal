using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAroundTarget : MonoBehaviour
{
    [SerializeField] private Vector2Int _bounds;
    [SerializeField] private Transform _target;

    public void Update()
    {
        Looping();
    }

    private void Looping()
    {
        Vector2 relativePosition = _target.position - transform.position;
        
        Vector2 offset = Vector2.zero;

        if (Mathf.Abs(relativePosition.x) >= _bounds.x)
            offset.x = Mathf.Sign(relativePosition.x) * _bounds.x * 2;
        
        if (Mathf.Abs(relativePosition.y) >= _bounds.y)
            offset.y = Mathf.Sign(relativePosition.y) * _bounds.x * 2;

        transform.Translate(offset);
    }

}
