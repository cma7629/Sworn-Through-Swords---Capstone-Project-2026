using UnityEngine;
using UnityEngine.UI;
public class GameStart : MonoBehaviour
{
    public Image targetImage;
   // public int[] quadrant = new int[4];
    private int currentIndex = 0;
// public int[][] pos = [quadrant][0,1,2,3,4];
    public Sprite[] images; //frames desired
   // public trigger targets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (images.Length > 0)
        {
            targetImage.sprite = images[currentIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void beginExcersize()
    {

    }

    public void NextImage()
    {
        currentIndex++;

        if (currentIndex >= images.Length)
            currentIndex = 0;// back to beginning

        targetImage.sprite = images[currentIndex];
    }

}
