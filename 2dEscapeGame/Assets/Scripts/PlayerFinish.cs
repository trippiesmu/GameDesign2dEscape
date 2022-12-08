using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinish : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fin")
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }
}