using UnityEngine;
namespace LernProject
{

    public class Shield : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private float _durability = 12f;

        public void Init(float durability)
        {
            _durability = durability;
            Destroy(gameObject, 10f);
        }
        public void Hit(float damage)
        {
            _durability -= damage;

            if (_durability <= 0)
                Destroy(gameObject);
        }
    } 
}