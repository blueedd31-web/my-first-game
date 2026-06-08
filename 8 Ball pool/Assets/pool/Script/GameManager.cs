using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball[] balls;
    private int ballsRemaining;

    void Start()
    {
        ballsRemaining = balls.Length;
    }

    void Update()
    {
        int activeBalls = 0;

        foreach (Ball ball in balls)
        {
            if (ball.gameObject.activeSelf)
                activeBalls++;
        }

        if (activeBalls == 0)
        {
            Debug.Log("Game Over!");
        }
    }
}