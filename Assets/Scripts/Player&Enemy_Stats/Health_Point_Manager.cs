using UnityEngine;

public class Health_Point_Manager : MonoBehaviour
{
    public int max_hp;
    private int health_points;

    //DEBUG Stuff
    public bool debug_prints_enable;
    void Start()
    {
        health_points = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (health_points < 0)
        {

            Destroy(gameObject);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //----------------------------------Non-Unity Functions---------------------------------------------------------
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    public void TakeDammage(int damage)
    {
        if (debug_prints_enable)
        {
            Debug.Log($"{gameObject.name} Pre-damage health: {health_points}");
            Debug.Log($"{gameObject.name} Damage: {damage}");
        }
        
        health_points = health_points - damage;
        
        if (debug_prints_enable)
        {
            Debug.Log($"{gameObject.name} Post-damage health: {health_points}");
        }
    }
}
