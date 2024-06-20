using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProvider : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool = new BulletPool();


    public GameObject GetBullet()
    {
        return bulletPool.GetBullet();        
    }

}
