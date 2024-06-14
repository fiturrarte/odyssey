using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProvider : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool = new BulletPool();

    // Start is called before the first frame update
    public GameObject GetBullet()
    {
        return bulletPool.getBullet();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
