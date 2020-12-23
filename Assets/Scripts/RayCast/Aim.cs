#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Aim : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField]
    private Transform tip;
    private RaycastHit hit;
    [SerializeField]
    private int dist = 10;

    // Update is called once per frame
    void Update()
    {
        // Does the ray intersect any objects excluding the player layer
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, dist))
        {
            // Linha no editor
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

            if (hit.transform.tag.Equals("Enemy"))
            {
                Debug.Log("Did Hit"); 
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * dist, Color.blue);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (tip != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(tip.transform.position, tip.localScale.y); 
        }
    }
#endif
}
