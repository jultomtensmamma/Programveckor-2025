using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform player; // Reference to the player
        public Vector3 offset; // Offset position from the player
        public float smoothSpeed = 0.125f; // Smoothing factor

        void FixedUpdate()
        {
            // Desired camera position
            Vector3 desiredPosition = player.position + offset;

            // Smoothly interpolate between current and desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Apply the smoothed position to the camera
            transform.position = smoothedPosition;
        }
    }

