using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add crosshairs on a Canvas 
//if the knob is not in the middle, go to the rectTransform, click alt and choose the middle option
//aatach a P{article System that is a child of the Gun call it FlashFire. 
//Unckeck looping, make duration 0.2. Make lifetime va;ues 0.04 and 0.06. change start color. take screenshot of brst property as well.
//Uncjeck play on awake. Add a Point Light as a child of the flashfire. 
//Check sahape, color over lifetime and lights boxes.
public class Target : MonoBehaviour
{
    public float health;
    public LevelManager lm;

    public void TakeDamage(float damage)
    {
        health = health - damage;

        if (lm.hasKey == false)
        {
            lm.hasKey = true;
        }

        if (health <= 0)

        {
            Destroy(this.gameObject, 0.4f);
        }
    }

}

    //public float health;

    //public void TakeDamage(float damage)
    //{
    //    health = health - damage;
    //    if (health <= 0)
    //    {
    //        Destroy(this.gameObject, 0.3f);
    //    }
    //}


