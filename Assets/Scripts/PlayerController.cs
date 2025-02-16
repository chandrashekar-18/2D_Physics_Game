using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _playErrorSound;
    [SerializeField] private AudioSource _playGameOverSound;

    private Vector3 _direction;
    private float _gravity = -9.8f;
    private float _strength = 5f;
    //public int _maxHealth = 10;
    //public int _currentHealth = 10;
    public int _health = 5;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        _direction = Vector3.zero;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _direction = Vector3.up * _strength;
        }

        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            _health--;
            _playErrorSound.Play();
            Destroy(collision.gameObject);

            if (_health<= 0)
            {
                _gameManager.GameOver();
                _playGameOverSound.Play();
                _health = 5;
            }
        }
        else if(collision.gameObject.tag == "Ground")
        {
            _gameManager.GameOver();
            _playGameOverSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            _gameManager.IncreaseScore();
            Destroy(collision.gameObject);
        }
    }

}
