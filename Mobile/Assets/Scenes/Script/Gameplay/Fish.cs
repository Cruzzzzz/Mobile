using UnityEngine;

public class Fish : MonoBehaviour, ICollectable
{
    [SerializeField] private int value = 1;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private AudioClip catchSound;

    private CurrencyManager currencyManager;
    private SoundManager soundManager;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        Collect();
    }

    public void Collect()
    {
        currencyManager.AddCoins(value);
        soundManager.PlaySFX(catchSound);
        Destroy(gameObject);
    }
}

