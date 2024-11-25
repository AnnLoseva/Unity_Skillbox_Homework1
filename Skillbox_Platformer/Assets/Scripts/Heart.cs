using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] int damage = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            Health playerHealth = other.GetComponent<Health>();

            playerHealth.ChangeHPPlayher(damage);


            Destroy(this.gameObject);
        }
    }

}
