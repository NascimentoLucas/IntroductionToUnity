#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField]
    private ItemManager itemManager;
    [SerializeField]
    private Transform tip;
    private RaycastHit hit;
    [SerializeField]
    private int dist = 10;
    private ItemGround item;

    private bool released;

    private void Start()
    {
        released = true;
    }

    void Update()
    {
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(tip.transform.position, tip.transform.TransformDirection(Vector3.forward) * dist, Color.blue);
        if (released)
        {
            if (Input.GetAxisRaw("Fire1") > 0)
            {
                if (Physics.Raycast(tip.transform.position, tip.transform.TransformDirection(Vector3.forward),
                    out hit, dist))
                {
                    // Linha no editor
                    item = hit.transform.GetComponent<ItemGround>();
                    if (item != null)
                    {
                        released = false;
                        itemManager.SetItem(item);
                    }
                }
                else
                {
                    
                }
            } 
        }
        else
        {
            if(Input.GetAxisRaw("Fire1") == 0)
            {
                released = true;
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (tip != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(tip.transform.position, tip.localScale.y);
        }
    }
#endif
}
