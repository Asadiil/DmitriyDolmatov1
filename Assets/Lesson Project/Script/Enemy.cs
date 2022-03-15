using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Enemy : MonoBehaviour, ITakeDamage
	{
        [SerializeField] private Player _player;
		[SerializeField] private GameObject _bullPref;
		[SerializeField] private Transform _spawnBull;
		[SerializeField] private float _lookRotate;

		public float _health = 12f;
		public float speed;

		private bool _isSpawnBull;
		private bool _LookChange;

		void Start()
        {
            _player = FindObjectOfType<Player>(); //выбор обЪекта.
        }

		void Update()
		{
			//transform.LookAt(_player.transform); // поворот противника (персонажа)на игрока look
			//transform.Translate(Vector3.forward * Time.deltaTime * speed); // изменение на позиции. движение.look/speed

			if (Vector3.Distance(transform.position, _player.transform.position) <= 3)//fire
            {
				if (Input.GetMouseButtonDown(2))
                {
					_isSpawnBull = true;
                }
            }
			if (Vector3.Distance(transform.position, _player.transform.position) <= 4) //look
			{
					_LookChange = true;
					Look();
			}
		}
		private void FixedUpdate()
        {
			if (_isSpawnBull)//fire
			{
				_isSpawnBull = false;
				Fire();
			}
			if (_LookChange)//look
			{
				_LookChange = false;
				Look();
			}
		}

		//fire

		private void Fire()
        {
			var bullObj = Instantiate(_bullPref, _spawnBull.position, _spawnBull.rotation);
			var bullet = bullObj.GetComponent<Bullet>();
			bullet.Init(_player.transform, 5, 4f);
		}

		//look
		private void Look()
		{


			var direction = _player.transform.position - transform.position;
			var stepRotate = Vector3.RotateTowards(transform.forward, direction, 
				_lookRotate * Time.fixedDeltaTime, 0f);

			if (CanSeePlayer() == true)
			{
				Debug.Log("player");
				transform.rotation = Quaternion.LookRotation(stepRotate);
				transform.Translate(Vector3.forward * Time.deltaTime * speed);//двигало
			}

		}


		//damage
		public void Init(float health)
		{
			_health = health;
			Destroy(gameObject, 1f);
		}

		public void Hit(float damage)
		{
			_health -= damage;

			if (_health <= 0)
				Destroy(gameObject);
		}

		bool CanSeePlayer()
		{
			RaycastHit hit;
			var direction = _player.transform.position - transform.position;

			if ((Vector3.Angle(direction, transform.forward)) <= 90f * 0.5f)
			{
				
				if (Physics.Raycast(transform.position, direction, out hit, _lookRotate))
				{
					return (hit.transform.CompareTag("Player"));
				}
			}

			return false;
		}
	}
}