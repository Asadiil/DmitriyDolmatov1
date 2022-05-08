using UnityEngine;

namespace LernProject
{
    public class GameOver : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Game Over");
        }
    }
}
