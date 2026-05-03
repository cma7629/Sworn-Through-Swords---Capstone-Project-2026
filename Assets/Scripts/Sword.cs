using UnityEngine;

public class Sword : MonoBehaviour
{

    public Transform tip;
    public Transform basePoint;

    public Vector3 EdgeDirection => transform.right; //define edge axis

    private Vector3 lastTipPos;
    private Vector3 tipVelocity;

    [SerializeField] float minSpeed = 0.05a f;
    [SerializeField] float minAlignment = 0.7f;
    [SerializeField] float cooldown = 0.1f;

    
    public int lastHitType;//used to tell what type of hit was last. Used for specific cut triggers. 1 = front, -1 = back, 0 = flat


    float lastHitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tipVelocity = (tip.position - lastTipPos) / Time.deltaTime;
        lastTipPos = tip.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            return;

        TryHit(other);
    }

    void TryHit(Collider other)
    {
        Debug.Log($"--- Trying hit on {other.name} ---");

        // Cooldown check
        if (Time.time - lastHitTime < cooldown)
        {
            Debug.Log("Blocked: Cooldown");
            return;
        }

        float speed = tipVelocity.magnitude;
        Debug.Log($"Speed: {speed:F2}");

        if (speed < minSpeed)
        {
            Debug.Log($"Blocked: Too slow (min {minSpeed})");
            lastHitType = 0;
            return;
        }

        Vector3 swingDir = tipVelocity.normalized;
        Vector3 edgeDir = EdgeDirection.normalized;

        float rawAlignment = Vector3.Dot(swingDir, edgeDir);
        float alignment = Mathf.Abs(rawAlignment);

        Debug.Log($"Alignment: {alignment:F2} (raw: {rawAlignment:F2})");

        if (alignment < minAlignment)
        {
            Debug.Log($"Blocked: Bad edge alignment (min {minAlignment})");
            lastHitType = 0;
            return;
        }

        // Sample points
        Vector3 midPoint = (tip.position + basePoint.position) * 0.5f;

        bool tipHit = CheckSurface(other, tip.position, swingDir, "TIP");
        bool midHit = CheckSurface(other, midPoint, swingDir, "MID");
        bool baseHit = CheckSurface(other, basePoint.position, swingDir, "BASE");

        bool validSurfaceHit = tipHit || midHit || baseHit;

        if (!validSurfaceHit)
        {
            Debug.Log("Blocked: No valid surface alignment on any blade point");
            return;
        }


        bool isBackEdge = rawAlignment < 0f;

        if (isBackEdge)
        {
            Debug.Log($" BACK EDGE CUT!");
            ScoreManager.Instance.backHit();
            lastHitType = -1;
        }
        else
        {
            Debug.Log($" FRONT EDGE CUT!");
            ScoreManager.Instance.frontHit();
            lastHitType = 1;
        }


        lastHitTime = Time.time;
    }

    bool CheckSurface(Collider other, Vector3 point, Vector3 swingDir, string label)
    {
        Vector3 contactPoint = other.ClosestPoint(point);
        Vector3 toBlade = (point - contactPoint).normalized;

        float surfaceAlignment = Vector3.Dot(swingDir, -toBlade);

        Debug.Log($"{label} | SurfaceAlignment: {surfaceAlignment:F2}");

        return surfaceAlignment > 0.3f;
    }

}
