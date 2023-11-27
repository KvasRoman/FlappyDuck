using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static Player Instance;
    private Rigidbody2D rb2;
    private SpriteRenderer sprite;
    [SerializeField] float JumpHeight;
    [SerializeField] float FallSpeed;
    private float jumpTime = 0.2f;
    private Vector2 _jumpVelocity;
    private Vector2 _fallVelocity;
    private Coroutine flyCoroutine = null;
    public event Action onPlayerDeath;
    public event Action onPlayerScore;
    private void Awake()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();
        _jumpVelocity = new Vector2(0, JumpHeight / jumpTime);
        _fallVelocity = new Vector2(0, -FallSpeed);
        rb2.velocity = _fallVelocity;

        onPlayerScore += () => ScoreManager.Instance.AddScorePoint(1);
        onPlayerScore += () => ObstacleGenerator.Instance.AddObstacles();
        onPlayerDeath += () =>
        {
            SoundManager.Instance.PlaySound(SoundTypes.death);
            MenuManager.Instance.OpenMenu(MenuType.Death);
            StopGame();
        };

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.tag);
        if( collision.transform.CompareTag("Pipe"))
        {
            onPlayerDeath?.Invoke();
        }
        if(collision.transform.CompareTag("Score"))
        {
            onPlayerScore?.Invoke();
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(flyCoroutine != null)
                StopCoroutine(flyCoroutine);
            flyCoroutine = StartCoroutine(Jump());
        }
    }
    private IEnumerator Jump()
    {
        
        rb2.velocity = _jumpVelocity;
        sprite.transform.rotation = Quaternion.Euler(0, 0, 20);
        SoundManager.Instance.PlaySound(SoundTypes.fly);
        yield return new WaitForSeconds(jumpTime);
        sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        rb2.velocity = _fallVelocity;
        yield break;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Scene scene =  SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
