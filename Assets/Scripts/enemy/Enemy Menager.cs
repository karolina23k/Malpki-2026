using UnityEngine;

public class EnemyMenager : MonoBehaviour 
{
    
    public static EnemyMenager main;

    public Transform[] checkpoints;

    public bool isGameStarted = false;


    void Awake()
    {
        main = this;
    }

    public void StartGame()
    {
        isGameStarted = true;
    }
}
