using UnityEngine;
using UnityEngine.UI;

public class ImageCycler : MonoBehaviour
{
    public Image targetImage;
    // public int[] quadrant = new int[4];
    private int currentIndex = 0;
    // public int[][] pos = [quadrant][0,1,2,3,4];
    public Sprite[] images; //frames desired
    public Collider[] triggerCollider;

    private int[] quadrant1 = { 1, 10, 17, 20 }; 
    private int[] quadrant4 = { 5, 8, 13, 22 };
    private int[] quadrant2 = { 2, 11, 16, 19 };
    private int[] quadrant3 = { 4, 7, 14, 23 };
    
    public float timeRemaining = 5f;
    private bool timerRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (images.Length > 0)
        {
            targetImage.sprite = images[currentIndex];
        }
    }


    void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0f)
            {
                timeRemaining = 0f;
                timerRunning = false;
                Debug.Log("Timer end");
                NextImage();
            }
        }

    }
        

    

    

    public void NextImage()
    {
        //disables previous collider

        for (int i = 0; i < quadrant1.Length; i++)
        {
            if (quadrant1[i] == currentIndex)
                triggerCollider[0].enabled = false;
        }
        for (int i = 0; i < quadrant2.Length; i++)
        {
            if (quadrant2[i] == currentIndex)
                triggerCollider[1].enabled = false;
        }
        for (int i = 0; i < quadrant3.Length; i++)
        {
            if (quadrant3[i] == currentIndex)
                triggerCollider[2].enabled = false;
        }
        for (int i = 0; i < quadrant4.Length; i++)
        {
            if (quadrant4[i] == currentIndex)
                triggerCollider[3].enabled = false;
        }

        currentIndex++;

        if (currentIndex % 3 == 0)
           timerRunning = true;
        if (currentIndex >= images.Length)
            currentIndex = 0;// back to beginning
        targetImage.sprite = images[currentIndex];

        //enables next collider
        for (int i = 0; i < quadrant1.Length; i++)
        {
            if (quadrant1[i] == currentIndex)
                triggerCollider[0].enabled = true;
        }
        for (int i = 0; i < quadrant2.Length; i++)
        {
            if (quadrant2[i] == currentIndex)
                triggerCollider[1].enabled = true;
        }
        for (int i = 0; i < quadrant3.Length; i++)
        {
            if (quadrant3[i] == currentIndex)
                triggerCollider[2].enabled = true;
        }
        for (int i = 0; i < quadrant4.Length; i++)
        {
            if (quadrant4[i] == currentIndex)
                triggerCollider[3].enabled = true;
        }
       
    }

}