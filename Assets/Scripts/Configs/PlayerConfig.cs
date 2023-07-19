using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class PlayerConfig 
    {
        [SerializeField] private float shootSpeed;
        [SerializeField] private float shootRange;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private int damage;
        [SerializeField] private float moveSpeed;
        [SerializeField] private int playerHealth;

        public float ShootSpeed
        {
            get => shootSpeed;
        }

        public float ShootRange
        {
            get => shootRange;
        }

        public float BulletSpeed
        {
            get => bulletSpeed;
        }

        public int Damage
        {
            get => damage;
        }

        public float MoveSpeed
        {
            get => moveSpeed;
        }

        public int Health
        {
            get => playerHealth;
        }
    }
}