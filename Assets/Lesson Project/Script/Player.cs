using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Player : MonoBehaviour
    {
        public GameObject shieldPrefab;
        public Transform SpawnPosition;

        private bool _isSpawnShield;
        private int level = 1;

        private Vector3 _direction;
        public float speed = 2f;

        private bool _isSprint;
        private bool _isJump;

        private void Awake()
        {

        }

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
                _isSpawnShield = true;
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _isSprint = Input.GetButton("Sprint");
            _isJump = Input.GetButton("Jump");
        }

        private void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }
            Move(Time.fixedDeltaTime);
        }
        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, SpawnPosition.position, SpawnPosition.rotation);
            var shield = shieldObj.GetComponent<Shield>();
            shield.Init(10 * level);

            shield.transform.SetParent(SpawnPosition);
        }

        private void Move(float delta)
        {
            transform.position += _direction * (_isSprint ? speed * 2: speed) * delta;
        }
    }
}