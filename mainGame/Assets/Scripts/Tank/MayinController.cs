using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayinController : MonoBehaviour
{
    public GameObject patlamaEfekti;

    PlayerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PatlamaFNC();

            playerHealthController.HasarAl();
        }
    }

    public void PatlamaFNC()
    {
        Destroy(this.gameObject);

        Instantiate(patlamaEfekti, transform.position, transform.rotation);
    }


}
