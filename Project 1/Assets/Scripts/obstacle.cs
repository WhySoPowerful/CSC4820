using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.instance.Health--;

          if(Player.instance.Health >= 0)
            {
             Player.instance.HealthImage[Player.instance.Health].gameObject.SetActive(false);
            }
        }
    }
}
