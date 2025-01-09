using UnityEngine;
using Unity.Cinemachine;

public class LevelCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera CinemachineCamera1;
    [SerializeField] private CinemachineConfiner2D confiner;

    // Referenzen auf die verschiedenen Polygon Collider 2D für die Bounds
    [SerializeField] private PolygonCollider2D boundsLevel1;
    [SerializeField] private PolygonCollider2D boundsLevel21;
    [SerializeField] private PolygonCollider2D boundsLevel22;
    [SerializeField] private PolygonCollider2D boundsLevel3;

    public void SetupCameraForLevel(string levelName)
    {
        // Setze die entsprechenden Bounds
        switch (levelName)
        {
            case "Level1":
                confiner.BoundingShape2D = boundsLevel1;
                SetHorizontalFollow();
                break;
            case "Level2.1":
                confiner.BoundingShape2D = boundsLevel21;
                SetHorizontalFollow();
                break;
            case "Level2.2":
                confiner.BoundingShape2D = boundsLevel22;
                SetHorizontalFollow();
                break;
            case "Level3":
                confiner.BoundingShape2D = boundsLevel3;
                SetVerticalFollow();
                break;
        }

        // Wichtig: Bounds nach Änderung invalidieren
        confiner.InvalidateBoundingShapeCache();
    }

    private void SetHorizontalFollow()
    {
        var composer = CinemachineCamera1.GetComponent<CinemachinePositionComposer>();
        if (composer != null)
        {
            composer.Damping.x = 1f; // Horizontale Bewegung
            composer.Damping.y = 10f; // Vertikale Bewegung stark gedämpft
            composer.Damping.z = 1f;
        }
    }

    private void SetVerticalFollow()
    {
        var composer = CinemachineCamera1.GetComponent<CinemachinePositionComposer>();
        if (composer != null)
        {
            composer.Damping.x = 1f; // Horizontale Bewegung
            composer.Damping.y = 10f; // Vertikale Bewegung stark gedämpft
            composer.Damping.z = 1f;
        }
    }
}