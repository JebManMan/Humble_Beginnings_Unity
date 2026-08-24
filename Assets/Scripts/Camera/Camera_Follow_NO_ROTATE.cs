using UnityEngine;

public class Camera_Follow_NO_ROTATE : MonoBehaviour
{
    public Transform target_location;

    // Update is called once per frame
    void Update()
    {
        // the camera needs view of the player
        float new_z = target_location.position.z - 1;
        transform.position = new Vector3(target_location.position.x, target_location.position.y, new_z);
    }
}
