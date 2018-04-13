using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyContact : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "scoreBall")
        {
            GameManager.Instance.score -= 2;
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }
    }
}
