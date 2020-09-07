using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Transform player;
    GameObject obj;
    Rigidbody2D rb;
    public float rotSpeed = 3.0f, movSpeed = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        obj = GameObject.FindWithTag("Player");
        player = obj.transform;
        rb = obj.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform != null && player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, movSpeed * Time.deltaTime);
            var offset = 90f;
            Vector2 direction = new Vector2(player.position.x,player.position.y) - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle - offset));
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(GameObject.FindWithTag("Enemy"));
            if (PlayerPrefs.GetInt("Highscore") == 0)
            {
                PlayerPrefs.SetInt("Highscore", ScoreManager.Kills);
            }
            else if (PlayerPrefs.GetInt("Highscore") < ScoreManager.Kills)
            {
                PlayerPrefs.SetInt("Highscore", ScoreManager.Kills);
            }
            SceneManager.LoadScene("GameOverMenu");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stinger"))
        {
            ScoreManager.Kills++;
            ScoreManager.Enemies--;
            Destroy(this.gameObject);
        }
    }
}

