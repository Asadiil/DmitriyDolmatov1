using UnityEngine;

namespace LernProject
{
    public class Enemy : MonoBehaviour, ITakeDamage
	{
        [SerializeField] private Player _player;
		[SerializeField] private GameObject _bullPref;
		[SerializeField] private Transform _spawnBull;

		public float _health = 12f;

		private bool _isSpawnBull;
		

		void Start()
        {
            _player = FindObjectOfType<Player>(); //поиск обЪекта, игрока.
        }

		void Update()
		{
			if (Vector3.Distance(transform.position, _player.transform.position) <= 3)
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

		public void Init(float health)
		{
			_health = health;
		}

		public void Hit(float damage)
		{
			_health -= damage;

			if (_health <= 0)
				Destroy(gameObject);
		}
	}
}