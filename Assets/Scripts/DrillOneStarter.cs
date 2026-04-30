using UnityEngine;

public class DrillOneStarter : MonoBehaviour //This starts the Beck Edge Drill
{
    
    public DrillStart drill;
    public ImageCycler cycler;

    void OnTriggerEnter(Collider other)
    {
        if (drill.noActiveDrill())
        {
            Debug.Log("DRILL START: BACK-EDGE");
            drill.BeginDrill(1);
            cycler.NextImage();
        }
        else
        {
            Debug.Log("DRILL ALREADY STARTED");
        }
            

    }
}