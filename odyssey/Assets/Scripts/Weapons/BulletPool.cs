using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    //Lista de Bullet
    List<GameObject> bullets = new List<GameObject>();
    int poolSize = 10;
    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Start bulletPool");
        //Bullet bullet = new Bullet();
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bullets.Add(bullet);
    }

    public GameObject getBullet()
    {
        return bullets[0];
    }

   /* void Awake()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab); 
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }*/
}
