using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class ToweSelectionManager : MonoBehaviour
{
    public RectTransform towerPanel;
    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI upgrade1Text;
    public TextMeshProUGUI upgrade2Text;
    public Image towerImage;
    public float hiddenPosX = -117.5f;
    public float shownPosX = -342.5f;
    public float slideSpeed = 12f;

    public LayerMask towerLayer;
    public float fireRateMultiplier = 0.75f;
    public float maxFireRateLevel = 3;
    public float rangeMultiplier = 1.25f;
    public float maxRangeLevel = 3;

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

        SpriteRenderer sr = tower.GetComponent<SpriteRenderer>();
        Tower towerScript = tower.GetComponent<Tower>();
        if (towerImage != null)
        {
            if (towerScript != null && towerScript.icon != null) towerImage.sprite = towerScript.icon;
            else if (sr != null) towerImage.sprite = sr.sprite;
            towerImage.preserveAspect = true;
        }


        if (towerScript != null)
        {
            if (upgrade1Text != null) upgrade1Text.text = towerScript.upgrade1Name;
            if (upgrade2Text != null) upgrade2Text.text = towerScript.upgrade2Name;
        }

    }
    public void UpgradeFireRate()
    {
        if (selectedTower == null) return;

        Tower towerScript = selectedTower.GetComponent<Tower>();
        if (towerScript == null) return;
        if (towerScript.fireRateLevel >= maxFireRateLevel) return;

        towerScript.fireRate *= fireRateMultiplier;
        towerScript.fireRateLevel++;
    }

    public void UpgradeRange()
    {
        if (selectedTower == null) return;

        Tower towerScript = selectedTower.GetComponent<Tower>();
        if (towerScript == null) return;
        if (towerScript.rangeLevel >= maxRangeLevel) return;

        towerScript.range *= rangeMultiplier;
        towerScript.rangeLevel++;
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
