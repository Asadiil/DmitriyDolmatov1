using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speedRotate;
        [SerializeField] private GameObject _bullPref;
        [SerializeField] private Transform _spawnBull;
        [SerializeField] private float startTimeShots;

        private float timeShots;

        private bool _isSpawnBull;
        private bool _LookChange;


        void Start()
        {
            _player = FindObjectOfType<Player>();
        }
        void Update()
        {
            //transform.LookAt(_player.transform);

            /* if (Vector3.Distance(transform.position, _player.transform.position) <= 4)
             {
                 if (Input.GetMouseButtonDown(2))
                 {
                     _isSpawnBull = true;
                 }*/

            if (timeShots <= 0)
            {
                timeShots = startTimeShots;
                if (Vector3.Distance(transform.position, _player.transform.position) <= 4)
                {
                    _isSpawnBull = true;
                }
                
            }
            else
            {
                timeShots -= Time.deltaTime;
            }
            
            if (Vector3.Distance(transform.position, _player.transform.position) <= 4)
            {
                _LookChange = true;
            }
        }

        void FixedUpdate()
        {
            
            if (_isSpawnBull)
            {
                _isSpawnBull = false;
                Fire();
            }
            if (_LookChange)
            {
                _LookChange = false;
                Look();
            }
        }
        private void Fire()
        {
            var bullObj = Instantiate(_bullPref, _spawnBull.position, _spawnBull.rotation);
            var bullet = bullObj.GetComponent<Bullet>();
            bullet.Init(_player.transform, 7, 4f);
        }
        private void Look()
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
