using UnityEngine;

public class Fish : MonoBehaviour, ICollectable
{
    [SerializeField] private int value = 1;
    [SerializeField] private float speed = 1.5f;
    public static float globalSpeed;
    [SerializeField] private AudioClip catchSound;


private CurrencyManager currencyManager;
    private SoundManager soundManager;
    private Animator anim;
    private bool collected = false;

    private void Start()
    {
        globalSpeed = speed;

        currencyManager = FindFirstObjectByType<CurrencyManager>();
        soundManager = FindFirstObjectByType<SoundManager>();

    anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!collected)
            transform.Translate(Vector2.left * globalSpeed * Time.deltaTime);

    }

    private void OnMouseDown()
    {
        Collect();
    }

    public void Collect()
    {
        if (collected) return;
        collected = true;

        if (currencyManager != null)
            currencyManager.AddCoins(value);
        else
            Debug.LogWarning("CurrencyManager não encontrado!");

        if (soundManager != null && catchSound != null)
            soundManager.PlaySFX(catchSound);

        if (anim != null)
        {
            anim.SetTrigger("Caught");
            Destroy(gameObject, 0.35f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}


