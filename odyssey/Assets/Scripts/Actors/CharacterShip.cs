using Assets.Scripts.Director;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class CharacterShip : MonoBehaviour
    {
        [SerializeField] BulletProvider bulletProvider = new BulletProvider();

        public void Start()
        {
            shoot();
        }

        public void Initialized()
        {
            
        }

        public void shoot()
        {
            // Obtener una bala del proveedor
            GameObject bullet = bulletProvider.GetBullet();

        }
    }
    }

