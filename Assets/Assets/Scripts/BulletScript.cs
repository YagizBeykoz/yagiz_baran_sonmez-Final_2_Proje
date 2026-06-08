using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision objectHit)
    {
        if (objectHit.gameObject.CompareTag("Enemy"))
        {
            print("Bir " + objectHit.gameObject.name + " vurdun!");

            CreateBulletImpactEffect(objectHit);

            Destroy(gameObject);
        }

        if (objectHit.gameObject.CompareTag("Wall"))
        {
            print("Duvari vurdun...");

            CreateBulletImpactEffect(objectHit);

            Destroy(gameObject);
        }

        if (objectHit.gameObject.CompareTag("Button"))
        {
            print("Butonu vurdun!");

            CreateBulletImpactEffect(objectHit);

            Destroy(gameObject);
        }
    }

void CreateBulletImpactEffect(Collision objectHit)
    {
        ContactPoint contact = objectHit.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );
        
        hole.transform.SetParent(objectHit.gameObject.transform);
    }
}
