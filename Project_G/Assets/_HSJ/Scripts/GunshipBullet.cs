using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipBullet : MonoBehaviour
{
    private GameObject hitFX;
    private ParticleSystem hitPS;

    private const string bulletHit = "Bullet_Hit";
    void Start()
    {
        hitFX = Managers.Resource.LoadFromResources<Object>(bulletHit) as GameObject;
        hitPS = hitFX.GetComponent<ParticleSystem>();
        Instantiate(hitFX, transform);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollision");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point + contact.normal;
            Debug.Log("OnCollisionEnter");
            if (hitPS != null)
            {
                hitPS.transform.rotation = rot;
                hitPS.transform.position = pos;
                hitPS.transform.LookAt(contact.point + contact.normal); 
                hitPS.Play();
            }
        }
    }
}
