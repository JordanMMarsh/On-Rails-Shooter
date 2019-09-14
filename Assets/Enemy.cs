using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float explosionTime = 2f;
    [SerializeField] float pointsPerEnemy = 10f;
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        if (!gameManager)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Bullets")
        {
            gameManager.AddScore(pointsPerEnemy);
            var explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(explosion, explosionTime);
            Destroy(gameObject);
        }
    }
}
