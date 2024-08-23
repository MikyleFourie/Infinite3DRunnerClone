using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]  // Hides from the Add Component menu
public class CustomDeadZone : CinemachineExtension
{
    public float topDeadZoneHeight = 0.2f;  // Percentage of screen height for the top dead zone
    public float bottomDeadZoneHeight = 0.1f;  // Percentage of screen height for the bottom dead zone

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var targetPos = state.ReferenceLookAt;
            var camPos = state.CorrectedPosition;

            // Vertical distance between camera and target
            float verticalOffset = targetPos.y - camPos.y;

            // Camera height in world units (depends on orthographic or perspective)
            float cameraHeight = state.Lens.OrthographicSize * 2f;

            // Calculate top and bottom dead zone bounds in world units
            float topBound = topDeadZoneHeight * cameraHeight;
            float bottomBound = bottomDeadZoneHeight * cameraHeight;

            if (verticalOffset > topBound)
            {
                // Move the camera up if the target exceeds the top bound
                camPos.y += (verticalOffset - topBound);
            }
            else if (verticalOffset < -bottomBound)
            {
                // Move the camera down if the target falls below the bottom bound
                camPos.y += (verticalOffset + bottomBound);
            }

            // Apply the calculated position back to the camera state
            state.RawPosition = camPos;
        }
    }
}
