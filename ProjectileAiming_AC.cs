using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAiming_AC : MonoBehaviour
{
    public static ProjectileAiming_AC projAimingInstance;

    public Transform spawnPoint;
    public float projectileForce;
    public Camera cam;
    PlayerController_AC player;
    LineRenderer line;
    private void Awake() => projAimingInstance = this;

    private void Start()
    {
        player = PlayerController_AC.controllerInstance;
        line = GetComponentInChildren<LineRenderer>();
        cam = player.cam;
    }

    void Update()
    {
        Vector3 lookDirection = cam.WorldToScreenPoint(Input.mousePosition) - spawnPoint.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        spawnPoint.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        DrawLine(spawnPoint.position, lookDirection);
    }

    public void ThrowProjectile(GameObject projectile)
    {
        projectile.transform.position = spawnPoint.position;
        projectile.transform.forward = spawnPoint.right;
        projectile.GetComponent<Rigidbody>().velocity = spawnPoint.TransformDirection(Vector3.right * projectileForce);
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        line.startWidth = 0.01f;
        line.endWidth = 0.01f;
    }
}