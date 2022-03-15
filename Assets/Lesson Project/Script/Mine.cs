using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                Debug.Log("BOOOOM");
                takeDamage.Hit(_damage);
            }
        }

        public void Init(float damage)
        {
            _damage = damage;
            Destroy(gameObject, 3f);
        }
    } 
}
