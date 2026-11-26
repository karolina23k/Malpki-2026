using Mono.Cecil;
using UnityEngine;


public class Tower : MonoBehaviour
{
    public float range = 8f;
    public int damage = 1;
    public float fireRate = 1f;
    public float fireRateLevel = 0;
    public float rangeLevel = 0;
    public string upgrade1Name = "Zwiększ prędkość";
    public string upgrade2Name = "Zwiększ zasięg";
    public Sprite icon;


    public GameObject target;
    private float cooldown = 1f;

    private void Update()
    {
        if (!EnemyMenager.main.isGameStarted) return;

        // przeładowanie leci cały czas, także gdy nie ma balonu w zasięgu
        if (cooldown < fireRate)
        {
            cooldown += Time.deltaTime;
        }

        if (target)
        {
            Vector2 dir = target.transform.position - transform.position;
            dir.Normalize();
            GetComponent<BoberDirection>().LookAt(dir);

            if (cooldown >= fireRate)
            {
                target.GetComponent<enemy>().damage(damage);
                cooldown = 0f;
            }
        }
    }

}
