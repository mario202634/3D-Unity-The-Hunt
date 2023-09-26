using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10;
    public float range = 100f; //gun can hit things up to 100 units away (so long as they’re tagged)
    public float impactForce;
    //public ParticleSystem flashFire; //to play a particle animation upon firing weapon. Set variable in Unity
    public Transform equipPosition;
    private Target target;
    GameObject GO;
    void Start() { }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            Debug.Log("Shot");

        }
    }
    void Shoot()
    {
        //flashFire.Play();
        RaycastHit hit2;

        //if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit2, range))
        if (Physics.Raycast(equipPosition.transform.position, equipPosition.transform.forward, out hit2, range))
        {
            target = hit2.transform.GetComponent<Target>();

            if (target != null)
            {
                if (target.transform.tag == "Chest")
                {
                    target.TakeDamage(damage);
                    target.GetComponent<Rigidbody>().AddForce(-hit2.normal * impactForce);
                }
            }

        }
    }
}