using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject_AC : MonoBehaviour
{
    public void BreakObject()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}