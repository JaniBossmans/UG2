using UnityEngine;

public class Brick : MonoBehaviour
{
    public delegate void BrickDestroyed();
    public event BrickDestroyed OnBrickDestroyed;

    public int points = 100;
    public Sprite[] states;
    public bool unbreakable;

    private SpriteRenderer spriteRenderer;
    private int health;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetBrick();
    }

    public void ResetBrick()
    {
        gameObject.SetActive(true);

        if (!unbreakable)
        {
            health = states.Length;
            spriteRenderer.sprite = states[health - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }

    private void Hit()
    {
        if (unbreakable)
        {
            return;
        }

        health--;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            NotifyGameManager();
        }
        else
        {
            spriteRenderer.sprite = states[health - 1];
        }

        FindObjectOfType<GameManager>().OnBrickHit(this);
    }

    private void NotifyGameManager()
    {
        OnBrickDestroyed?.Invoke();
    }
}
