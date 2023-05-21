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
        GameObject projectile = ObjectPooling.Instance.GetGameObject(projectilePrefab);
        projectile.SetActive(true);
        projectile.transform.localScale = new Vector3(transform.parent.localScale.x, 1, 1);
        projectile.transform.position = projectileLauncherPos.position;
        projectile.transform.rotation = projectilePrefab.transform.rotation;
        StartCoroutine(DisActive(projectile));
    }

    private IEnumerator DisActive(GameObject projectile)
    {
        yield return new WaitForSeconds(projectile.GetComponent<Projectile>()._lifeTime);
        projectile.SetActive(false);
    }
}
