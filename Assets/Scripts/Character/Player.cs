using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

[RequireComponent(typeof(Body))]
[RequireComponent(typeof(KeyboardMoving))]
public class Player : MonoBehaviour
{
    private Body _body;

    private void Start()
    {
        _body = GetComponent<Body>();
    }


}
