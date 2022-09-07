using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    float rotSpeed = 60; // degrees per second
    
    
    void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // create effect at coin position and with player rotation
            Instantiate(Player.instance.effect, transform.position, other.transform.rotation);
            Player.instance.effect.transform.position = transform.position;
            Player.instance.score++;
            Player.instance.effect.Play();
            Destroy(gameObject); // coin Destroy
        }
    }
}
