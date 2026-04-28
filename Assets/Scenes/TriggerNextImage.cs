using UnityEngine;

public class TriggerNextImage : MonoBehaviour
{
    public ImageCycler cycler; // reference to your script

    void OnTriggerEnter(Collider other)
    {
        cycler.NextImage();
        
    }
}