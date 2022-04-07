using UnityEngine;

namespace LernProject
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _damage = 5f;
        [SerializeField] private float dangerRadius = 15f;
        [SerializeField] private float dangerForce = 10f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                Debug.Log("BOOOOM");
                takeDamage.Hit(_damage);
                Explode();
                Destroy(gameObject);
            }
        }

        public void Init(float damage)
        {
            _damage = damage;
            Destroy(gameObject, 3f);
            Explode();
        }
        
        private void Explode()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, dangerRadius);
            foreach(var hit in hitColliders)
            {
                Debug.Log("Crash!!!");

            }
        }
    } 
}
