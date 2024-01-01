using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public class Player : MonoBehaviour
    {
        public AudioSource music;
        public AudioClip jump;

        private void Awake()
        {
            music = gameObject.AddComponent<AudioSource>();
            music.playOnAwake = false;
            jump = Resources.Load<AudioClip>("music/jump");
        }
        void Update()
        {
			if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                music.clip = jump;
                music.Play();
            }
        }
    }
}

