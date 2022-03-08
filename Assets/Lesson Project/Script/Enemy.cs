using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _player;

        void Start()
        {
            _player = FindObjectOfType<Player>();
        }
    }
}