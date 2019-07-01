using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public GameObject Explosion;
    public GameController gameController;

    // coba bikin audionya pake script nanti

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();         // biar konsisten
        //_animator = GetComponent<Animator>();
        _rigidbody2D.velocity = Vector2.down * speed;         // Vector2.up sama aja kaya Vector2(0,1) enemy=down
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayExplosion();
            Destroy(collision.gameObject);
            gameController.game_over();
        }
        else if (collision.CompareTag("PlayerBullet")) {
            Instantiate(Explosion, transform.position, transform.rotation);
            gameController.AddScore();
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
