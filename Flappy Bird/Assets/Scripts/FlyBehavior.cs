using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private Rigidbody2D _rb;
    public AudioClip backgroundMusic; 
    public AudioClip explosionSound;
    private AudioSource m_MyAudioSource;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        m_MyAudioSource = GetComponent<AudioSource>();

      
            PlayBackgroundMusic();
        
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
         PlayExplosionSound();
        spriteRenderer.sprite = newSprite;
  
        GameManager.instance.GameOver();
    }

    private void PlayBackgroundMusic()
    {
        if (m_MyAudioSource != null && backgroundMusic != null)
        {
            m_MyAudioSource.clip = backgroundMusic;
            m_MyAudioSource.loop = true;
            m_MyAudioSource.Play();
        
        }
       
    }

 private void PlayExplosionSound() {
       m_MyAudioSource.clip = explosionSound;
       m_MyAudioSource.PlayOneShot(explosionSound);
 }
}

