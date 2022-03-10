using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]private float _damag = 4f;

    public void Init(float damag)
    {
        _damag = damag;
        Destroy(gameObject, 3f);
    }
}
