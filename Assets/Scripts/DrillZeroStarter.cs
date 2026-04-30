using UnityEngine;

public class DrillZeroStarter : MonoBehaviour
{
    public DrillStart drill;
    public ImageCycler cycler;
    void OnTriggerEnter(Collider other)
    {
        if (drill.noActiveDrill())
        {
            Debug.Log("DRILL START: FRONT-EDGE");
            drill.BeginDrill(0);
            cycler.NextImage();
        }
        else
        {
            Debug.Log("DRILL ALREADY STARTED");
        }


    }
}