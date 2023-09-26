using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{

public Transform equipPosition; //the transform point at which a weapon will be attached
    public float distance; //the closest distance from which you can successfully pick weapon
    public KeyCode droppickupButton; //key will be set in Unity inspector
    public KeyCode pickupButton; //key will be set in Unity inspector
    GameObject currentWeapon; //weapon player is currently CARRYING
    GameObject wp; //a random weapon the raycast hit in the world
    bool canGrab; //if weapon properly tagged, it can be picked up
    void Start()
    {
        GameObject currentWeapon = null;
        canGrab = true;
    }

    void CheckWeapons()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,
        Camera.main.transform.forward, out hit, distance))
        {
            //If the raycast hit point went through a game object tagged "Grabbable"
            //Then player can in fact pick it up
            //wp is assigned the GO the raycast pierced 
            if (hit.transform.tag == "Grabbable")
            {
                //Debug.Log("You Can Grab This Weapon.");
                canGrab = true;
                wp = hit.transform.gameObject;
            }
            else
            {
                canGrab = false;
            }
        }
    }

    void PickUpWeapon()
    {
        //Now assign wp to current weapon,
        //as there may be plenty of other weapons in the world,
        //but this is the one the player's currently carrying
        currentWeapon = wp;
        currentWeapon.transform.position =
        equipPosition.position; //attach weapon at same position asequip point
        currentWeapon.transform.parent = equipPosition;
        //make the weapon a child of the EquipPosition gameObject
        currentWeapon.transform.localEulerAngles = new
        Vector3(0f, 270f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic =
        true;//To prevent the weapon from reacting to gravity
        currentWeapon.GetComponent<Collider>().isTrigger =
        true;
    }


    void Update()
    {
        CheckWeapons();
        if (canGrab)
        {
            //So long as player is not currently carrying a weapon
            if (currentWeapon == null)
            {
                if (Input.GetKeyDown(pickupButton))
                {
                    PickUpWeapon();
                }
            }
        }

    }
}
