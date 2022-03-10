using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _player;
		[SerializeField] private GameObject _bullPref;
		[SerializeField] private Transform _spawnBull;

		private bool _isSpawnBull;

		public float health = 12;
		public float speed;

        void Start()
        {
            _player = FindObjectOfType<Player>();
        }

		void Update()
		{
			transform.LookAt(_player.transform);
			//transform.Translate(Vector3.forward * Time.deltaTime * speed);

			if (Vector3.Distance(transform.position, _player.transform.position) <= 6)
            {
				if (Input.GetMouseButtonDown(2))
                {
					_isSpawnBull = true;
                }
            }
		}
		private void FixedUpdate()
        {
			if (_isSpawnBull)
			{
				_isSpawnBull = false;
				Fire();
			}
		}

		private void Fire()
        {
			var bullObj = Instantiate(_bullPref, _spawnBull.position, _spawnBull.rotation);
			var bullet = bullObj.GetComponent<Bullet>();
			bullet.Init(_player.transform, 5, 4f);
		}

		public void TakeDamage(int damage)
		{
			health -= damage;
			if (health <= 0)
			{
				Die();
			}
		}
		
		void Die()
		{
			Destroy(gameObject);
		}
	}
}