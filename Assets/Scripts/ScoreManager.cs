using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int front = 0;
    public int bad = 0;
    public int back = 0;

    void Awake()
    {
        Instance = this;
    }

    public void frontHit()
    {
        front ++;
    }

    public void badHit()
    {
        bad ++;
    }

    public void backHit()
    {
        back ++;
    }

}