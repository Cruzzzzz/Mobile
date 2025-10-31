using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Sprite[] areaSprites; // 5 áreas diferentes

    public void ChangeArea(int index)
    {
        if (index >= 0 && index < areaSprites.Length)
            background.sprite = areaSprites[index];
    }

    public void UpdateAreaByTime(float elapsedTime)
    {
        int areaIndex = Mathf.FloorToInt(elapsedTime / 60); // muda a cada minuto
        ChangeArea(areaIndex);
    }
}
