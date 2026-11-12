using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject towerPrefab;
    public LayerMask cantBuildLayer;
    public string placedTowerLayerName = "tower";
    public string monkeyName;

    private GameObject draggedTower;
    private Tower towerScript;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        mousePos.z = 0;
        draggedTower = Instantiate(towerPrefab, mousePos, Quaternion.identity);

        draggedTower.name = string.IsNullOrEmpty(monkeyName) ? towerPrefab.name : monkeyName;
        
        SetLayerRecursively(draggedTower, LayerMask.NameToLayer("Default"));
        
        towerScript = draggedTower.GetComponent<Tower>();
        if (towerScript != null) towerScript.enabled = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedTower != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            mousePos.z = 0;
            draggedTower.transform.position = mousePos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedTower != null)
        {
            Collider2D hit = Physics2D.OverlapCircle(draggedTower.transform.position, 0.5f, cantBuildLayer);

            if (hit != null)
            {
                Destroy(draggedTower);
            }
            else
            {
                int targetLayer = LayerMask.NameToLayer(placedTowerLayerName);
                if (targetLayer != -1)
                {
                    SetLayerRecursively(draggedTower, targetLayer);
                }

                if (towerScript != null) towerScript.enabled = true;
            }
            
            draggedTower = null;
        }
    }

    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (newLayer < 0 || newLayer > 31) return;

        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            if (child.name.ToLower() != "range")
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
    }
}