using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    //Lista de Bullet
    List<GameObject> bullets;
    int poolSize = 10;
    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            CreateBullet();
        }

    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(true);
        bullets.Add(bullet);
    }

    public GameObject GetBullet()
    {
        int i = 0;
        bool bulletFound = false;        
        while (i < poolSize && !bulletFound)
        {
            GameObject bullet = bullets[i];
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bulletFound = true;
            }
            i++;
        }
        if (bulletFound)
        {
            return bullets[i-1];
        } else
        {
            CreateBullet();
            return bullets[0];
        }
    }


 
}
