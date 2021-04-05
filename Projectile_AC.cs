using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_AC : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, gameObject.GetComponent<Rigidbody>().velocity);
        gameObject.transform.rotation = rot;
        if(collision.gameObject.CompareTag("Explosive"))
        {
            collision.gameObject.GetComponent<ExplosiveObject_AC>().Explode();
            Debug.Log("explode");
        }
    }
}