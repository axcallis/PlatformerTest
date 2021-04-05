using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWalls_AC : BreakableObject_AC
{
    public GameObject revealLight;

    public void BreakWall()
    {
        BreakObject();
        revealLight.SetActive(true);
        GetComponent<MeshCollider>().enabled = false;
    }
}