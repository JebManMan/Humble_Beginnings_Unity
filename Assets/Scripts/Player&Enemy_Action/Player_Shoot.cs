using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bullet_1;
    public float bulletForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Copying over some code just testing
        

    }

    public void Shoot(Vector3 target_pos)
{
    Transform shootPoint = transform.Find("Normal_Shoot_Point");
    GameObject bullet = Instantiate(bullet_1, shootPoint.position, Quaternion.identity);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    if (rb != null)
    {
        Vector2 direction = (target_pos - shootPoint.position).normalized;
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
}

}
