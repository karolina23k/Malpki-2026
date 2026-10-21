using Mono.Cecil;
using UnityEngine;


public class Tower : MonoBehaviour
{
    public float range = 8f;
    public int damage = 1;
    public float fireRate = 1f;

    public GameObject target;
    private float cooldown = 1f;

    private void Update()
    {
        if (target)
        {
            transform.right = target.transform.position - transform.position;

            if (cooldown >= fireRate)
            {
                transform.right = target.transform.position - transform.position;
                target.GetComponent<enemy>().damage(damage);
                cooldown = 0f;
            }
            else
            {
                cooldown += 1 * Time.deltaTime;
            }
        }
    }

}
