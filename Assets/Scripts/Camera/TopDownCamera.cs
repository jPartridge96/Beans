using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target; // The player object that the camera will follow
    public float smoothSpeed = 0.125f; // The speed at which the camera will follow the player
    public float cameraYPosition; // The fixed Y-axis position of the camera
    public float zoomSpeed = 5f; // The speed at which the camera will zoom in/out
    public float minZoom = 5f; // The minimum zoom level
    public float maxZoom = 15f; // The maximum zoom level
    public float zOffset = 1f;

    private float currentZoom = 10f; // The current zoom level
    private Quaternion currentRotation;
    private Vector3 currentVelocity = Vector3.zero; // Current velocity for SmoothDamp

    private void Start()
    {
        currentRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // Get the scroll wheel input and update the zoom level
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Calculate the desired position and zoom level for the camera
        Vector3 desiredPosition = new Vector3(target.position.x, currentZoom, target.position.z - zOffset);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

        // Update the camera position and rotation
        transform.position = smoothedPosition;
        transform.rotation = currentRotation;
        transform.LookAt(target);
    }
}
