using UnityEngine;

namespace LernProject
{
    
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage = 4f;
        private Transform _target;
        private float _speed;


        public void Init(Transform target, float lifeTime, float speed)
        {
            _target = target;
            _speed = speed;
        }

        void FixedUpdate()
        {
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                takeDamage.Hit(_damage);
                Destroy(gameObject);
            }
        }
    }
}