using UnityEngine;

public class DrillStart : MonoBehaviour
{
    public Collider[] collider;

    //Drill Types:
    //0 = front edge only
    //1 = back edge only
    //2 = back edge first, then front edge

    public int drillType = -1;

    public void BeginDrill(int drillNumber)
    {
        for (int i = 0; i < collider.Length; i++)
        {
            collider[i].enabled = false;
        }
        drillType = drillNumber;
    }


    public void DrillEnd()
    {
        for (int i = 0; i < collider.Length; i++)
        {
            collider[i].enabled=true;
        }
        drillType = -1;

    }

    public bool noActiveDrill()
    {
        if (drillType == -1)
        {
            return true;
        }
        else
        {

            return true;
        }
    }
}
