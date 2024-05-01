using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp;
   

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ammo"))
        {
            hp--;
        }
        if (hp <= 0) { Destroy(gameObject); }
    }
}
