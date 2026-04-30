using UnityEngine;

public class TriggerNextImage : MonoBehaviour
{
    public ImageCycler cycler;
    public DrillStart drill;
    public Sword sword;


    void OnTriggerEnter(Collider other)
    {
        if (sword.lastHitType == 1)
        {
            if (drill.drillType == 0)//correct hit
            {
                cycler.NextImage();
            }
            

        }
        else if (sword.lastHitType == -1)
        {
            if (drill.drillType == 1)//correct hit
            {
                cycler.NextImage();
            }
        }
    }


}