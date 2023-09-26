using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public int health;
    public int lives;
    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public Slider healthUI;

    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
               // FindObjectOfType<Levelmanager>().RespawnPlayer;
                this.health = 6;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
               (new NavigationController()).GoToGameOverScene();
                Debug.Log("Gameover");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());
        }
    }

    //PlayHitReaction();
    // Start is called before the first frame update
    void Start()
    {
        fill.color = gradient.Evaluate(1F);

    }

    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;
        fill.color = gradient.Evaluate(healthUI.normalizedValue);

    }
}
