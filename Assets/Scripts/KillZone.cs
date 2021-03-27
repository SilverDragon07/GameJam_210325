using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameManager.Instance.EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameManager.Instance.EndGame();
        }
        else if (other.gameObject.name.Contains("Enemy"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.KillCountUp();
        }
    }
}