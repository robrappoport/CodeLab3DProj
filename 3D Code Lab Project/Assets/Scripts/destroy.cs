using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    ParticleSystem psys;

    private void Start()
    {
        psys = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update () {
        if (!psys.isPlaying)
        {
            Destroy(this.gameObject, 1f);
        }
	}
}
