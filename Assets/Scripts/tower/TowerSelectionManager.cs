using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class ToweSelectionManager : MonoBehaviour
{
    public RectTransform towerPanel;
    public TextMeshProUGUI towerNameText;
    public float hiddenPosX = -117.5f;
    public float shownPosX = -342.5f;
    public float slideSpeed = 12f;

    public LayerMask towerLayer;

    private GameObject selectedTower;
    private bool isPanelOpen = false;

    void Start()
    {
        if (towerPanel != null)
        {
            Vector2 pos = towerPanel.anchoredPosition;
            pos.x = hiddenPosX;
            towerPanel.anchoredPosition = pos;
        }
    }

    void Update()
    {
        HandleClick();
        AnimatePanel();
    }

    private void HandleClick()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            Collider2D hit = Physics2D.OverlapPoint(worldPos, towerLayer);

            if (hit != null)
            {
                SelectTower(hit.gameObject);
            }
            else
            {
                DeselectTower();
            }
        }
    }

    private void AnimatePanel()
    {
        if (towerPanel == null) return;

        float targetX = isPanelOpen ? shownPosX : hiddenPosX;
        Vector2 currentPos = towerPanel.anchoredPosition;
        currentPos.x = Mathf.Lerp(currentPos.x, targetX, Time.deltaTime * slideSpeed);
        towerPanel.anchoredPosition = currentPos;
    }

    public void SelectTower(GameObject tower)
    {
        selectedTower = tower;
        isPanelOpen = true;

        if (towerNameText != null)
        {
            towerNameText.text = tower.name;
        }
    }

    public void DeselectTower()
    {
        selectedTower = null;
        isPanelOpen = false;
    }

    public void SellSelectedTower()
    {
        if (selectedTower != null)
        {
            Destroy(selectedTower);
            DeselectTower();
        }
    }
}
