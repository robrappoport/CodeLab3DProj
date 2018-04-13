using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollisions : MonoBehaviour {
    public ParticleSystem psys;
    public int scoreIncrease;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "scoreBall")
        {
            GameManager.Instance.score += scoreIncrease;
            Instantiate(psys, collision.transform.position, Quaternion.identity);
            psys.Play();
            Destroy(collision.gameObject);
           
        }
    }
}
