using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private bool _isBuglarInside;
    private Signalisation signalisation;

    private void Awake()
    {
        signalisation = FindObjectOfType<Signalisation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isBuglarInside)
        {
            signalisation.PlaySound(signalisation.MaxVolume);
        }
        else
        {
            signalisation.PlaySound(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Buglar>())
        {
            _isBuglarInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Buglar>())
        {
            _isBuglarInside = false;
        }
    }
}
