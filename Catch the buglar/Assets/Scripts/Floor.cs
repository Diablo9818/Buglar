using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Floor : MonoBehaviour
{
    private bool _isBuglarInside;

    public UnityAction<bool> StateChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Buglar buglar))
        {
            _isBuglarInside = true;
            StateChanged?.Invoke(_isBuglarInside);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Buglar buglar))
        {
            _isBuglarInside = false;
            StateChanged?.Invoke(_isBuglarInside);
        }
    }
}
