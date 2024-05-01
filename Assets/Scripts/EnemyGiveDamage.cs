using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGiveDamage : MonoBehaviour
{

    public int damageToGive;


    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            //FindObjectOfType<PlayerHealth>().TakeDamage(damageToGive);
        }

    }

}
