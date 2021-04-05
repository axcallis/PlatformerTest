using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObject_AC : MonoBehaviour
{
    public void Explode()
    {
        RaycastHit hit;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (Physics.SphereCast(transform.position, .5f, transform.forward, out hit, 2))
        {
            if(hit.collider.gameObject.tag == "Breakable Wall")
            {
                hit.collider.gameObject.GetComponent<BreakableWalls_AC>().BreakWall();
            }
        }
        gameObject.SetActive(false);
    }
}