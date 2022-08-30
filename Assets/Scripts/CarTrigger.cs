using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Goal"))
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(col.gameObject, .5f);
            GameManager.Instance.RestartGame(2f);
        }
        else
        {
            GameManager.Instance.RestartGame(.5f);
        }
    }
}
