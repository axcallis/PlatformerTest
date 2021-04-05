using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLoader_AC : MonoBehaviour
{
    public static ProjectileLoader_AC projLoaderInstance;

    public GameObject activeProjectile;
    public List<GameObject> pool;
    public float resetTimer = 2f;
    float initialResetTimer;
    bool ready;
    List<Vector3> origins;

    private void Awake() => projLoaderInstance = this;

    void Start()
    {
        initialResetTimer = resetTimer;
        InitializeOriginPoints();
        ResetProjectiles();
    }

    void Update()
    {
        if(pool.Count < 3)
        {
            ready = false;
            resetTimer -= Time.deltaTime;
            if(resetTimer <=0)
                ResetProjectiles();
        }
    }

    void InitializeOriginPoints()
    {
        origins = new List<Vector3>();
        for (int i = 0; i < pool.Count; i++)
            origins.Add(pool[i].transform.position);
    }

    public void ResetProjectiles()
    {
        if(activeProjectile)
        {
            pool.Add(activeProjectile);
            activeProjectile = null;
        }
        for (int i = 0; i < pool.Count; i++)
        {
            pool[i].SetActive(false);
            pool[i].transform.position = origins[i];
            pool[i].GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
        resetTimer = initialResetTimer;
        ready = true;
    }

    public void LoadProjectile()
    {
        if(ready)
        {
            activeProjectile = pool[0];
            activeProjectile.SetActive(true);
            pool.RemoveAt(0);
            ProjectileAiming_AC.projAimingInstance.ThrowProjectile(activeProjectile);
        }
    }
}