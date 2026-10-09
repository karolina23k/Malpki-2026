using UnityEngine;

public class EnemyMenager : MonoBehaviour 
{

    public static EnemyMenager main;

    public Transform[] checkpoints;
    void Awake()
    {
        main = this;
    }

}
