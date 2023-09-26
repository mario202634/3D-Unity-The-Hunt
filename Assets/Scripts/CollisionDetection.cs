using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public int damage;
   // public GameObject HitParticle;

    // Start is called before the first frame update


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") // && wc.isAttacking
        {
            Debug.Log(other.name);
          other.GetComponent<Animator>().SetTrigger("Hit");

            /*Instantiate(HitParticle,
                new Vector3(    
                        other.transform.position.x,
                        transform.position.y,
                        other.transform.position.z),
                        other.transform.rotation);
            */

            

            FindObjectOfType<AIController>().TakeDamage(damage);
			if (FindObjectOfType<AIController>().health==0)
			{
                other.GetComponent<Animator>().SetTrigger("Dead");

            }
            //Destroy(other.gameObject, 2f);

            
        }
      

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

