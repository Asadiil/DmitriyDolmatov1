using UnityEngine;

namespace LernProject
{
    public class ObjectUse : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            Player.Health += 50f;
            Destroy(gameObject);
        }
    } 
}
