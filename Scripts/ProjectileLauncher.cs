using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileLauncherPos;


    private void OnEnable()
    {
        FireProjectile();
    }

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileLauncherPos.position, projectilePrefab.transform.rotation);
        projectile.transform.localScale = new Vector3(transform.parent.localScale.x, 1, 1);
    }
}
