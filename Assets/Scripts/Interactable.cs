using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite interactIcon;
    public Vector2 iconSize;
    public int ID;

    void Start()
    {
        //Give a super wide range so most GO with Interactable attached will fall within the range
        //and be picked up by the Raycast hit, no matter how many there exist in the game world.
         ID = Random.Range(0, 999999);
    }

    void Update()
    { }
}
