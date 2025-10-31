using UnityEngine;

public class FishingSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject hookAnimation;
    [SerializeField] private AudioClip splashSound;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void OnClick()
    {
        soundManager.PlaySFX(splashSound);
        if (hookAnimation != null)
        {
            Instantiate(hookAnimation, transform.position, Quaternion.identity);
        }
    }

    private void OnMouseDown()
    {
        OnClick();
    }
}
