using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{

    //Set velocity and rotationspeed
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    //Set the imports to a var
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private Rigidbody2D _rb;
    public AudioClip backgroundMusic; 
    public AudioClip explosionSound;
    private AudioSource m_MyAudioSource;

    //Func to start the gme
    private void Start()
    {
        //Get components
        _rb = GetComponent<Rigidbody2D>();
        m_MyAudioSource = GetComponent<AudioSource>();

        //Fire background music func
        PlayBackgroundMusic();
        
    }
    //Func to update the game when playing
    private void Update()
    {
        //Make the plane move when clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        //Define the rotation when moves
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //Fire explosionsound func
         PlayExplosionSound();
        //Set plane to explosion sprite
        spriteRenderer.sprite = newSprite;
        //Set gameover
        GameManager.instance.GameOver();
    }

    private void PlayBackgroundMusic()
    {
        //Check if audiosource or backgroundmusic is not null
        if (m_MyAudioSource != null && backgroundMusic != null)
        {
            //Set the audiosource clip to the background music
            m_MyAudioSource.clip = backgroundMusic;
            //Loop the audiosource
            m_MyAudioSource.loop = true;
            //Play the audiosource
            m_MyAudioSource.Play();
        
        }
       
    }
    
    //Func to play explosionsound
 private void PlayExplosionSound() {
      //Set audiosource clip to explosion
       m_MyAudioSource.clip = explosionSound;
       //Play the explosion sound once
       m_MyAudioSource.PlayOneShot(explosionSound);
 }
}

