using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOrOff : MonoBehaviour
{
    public bool on;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            on = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            on = false;
        }
    }
}
