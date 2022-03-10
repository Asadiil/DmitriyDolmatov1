using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speedRotate;

        void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        void FixedUpdate()
        {
            var direction = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward,
                direction,
                _speedRotate * Time.fixedDeltaTime,
                0f);

            transform.rotation = Quaternion.LookRotation(stepRotate);
        }
    }
}
