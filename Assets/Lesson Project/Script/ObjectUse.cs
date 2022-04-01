using UnityEngine;

namespace LernProject
{
    public class ObjectUse : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }

        void OnTriggerEnter(Collider other)
        {
            Player.Health += 50f;
            Destroy(gameObject);
        }
    } 
}
