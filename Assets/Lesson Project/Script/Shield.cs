using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	[SerializeField]private float _durability = 12f;

    public void Init(float durability)
    {
		_durability = durability;
        Destroy(gameObject, 3f);
    }
}