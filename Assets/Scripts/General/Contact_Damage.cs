using UnityEngine;


public class Contact_Damage : MonoBehaviour
{
    private Health_Point_Manager health_Point_Manager;
    public int contact_damage;
    public GameObject deathParticle;
    public bool destroy_self_on_contact;

    void OnCollisionEnter2D(Collision2D other)
    {
        health_Point_Manager = other.gameObject.GetComponent<Health_Point_Manager>();
        health_Point_Manager.TakeDammage(contact_damage);
        if (destroy_self_on_contact)
        {
            Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
