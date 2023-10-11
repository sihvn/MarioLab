using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPowerupController : MonoBehaviour, IPowerupController
{
    // Start is called before the first frame update
    public Animator powerupAnimator;
    public BasePowerup powerup;
    public bool isBreakable = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!powerup.hasSpawned)
            {

                this.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<Animator>().SetTrigger("bounce");
                powerupAnimator.SetTrigger("spawned");

                if (!isBreakable)
                {
                    // spawn the powerup
                    this.GetComponent<Animator>().SetTrigger("spawned");
                }
            }
            else
            {
                if (isBreakable)
                {
                    // show disabled sprite
                    this.GetComponent<Animator>().SetTrigger("bounce");
                }
            }



        }
    }

    public void Disable()
    {
        // this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // transform.localPosition = new Vector3(0, 0, 0);
    }
}
