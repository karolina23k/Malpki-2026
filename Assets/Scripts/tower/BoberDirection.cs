using UnityEngine;

public class BoberDirection : MonoBehaviour
{
    public Sprite[] sprites; // 0 - 0, 1 - 45, 2 - 90, 3 - 135, 4 - 180, 5 - 225, 6 - 270, 7 - 315
    SpriteRenderer sr;

    void Awake() => sr = GetComponent<SpriteRenderer>();

    public void LookAt(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        int index = Mathf.RoundToInt(angle / 45f);
        index = ((index % 8) + 8) % 8;
        sr.sprite = sprites[index];
    }
}
