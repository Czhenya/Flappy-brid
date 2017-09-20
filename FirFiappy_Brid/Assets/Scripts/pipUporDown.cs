using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipUporDown : MonoBehaviour {

    private AudioSource colaudio;

    void Start()
    {
        colaudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            colaudio.Play();
            GameManager.intance.GameState = GameManager.GAME_END;
        }
    }
}
