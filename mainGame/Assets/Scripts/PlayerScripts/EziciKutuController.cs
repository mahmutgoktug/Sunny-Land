using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EziciKutuController : MonoBehaviour
{
    [SerializeField]
    GameObject yokOlmaEfekti;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kurbaga"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(yokOlmaEfekti, transform.position, transform.rotation);
        }
    }
}
