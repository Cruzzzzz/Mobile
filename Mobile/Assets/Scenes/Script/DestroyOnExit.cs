using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

