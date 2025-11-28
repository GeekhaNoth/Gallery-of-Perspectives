using UnityEngine;

public class GlowOnTrigger : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private Color glowColor = Color.white;
    [SerializeField] private float intensity = 3f;

    private Material targetMaterial;

    void Start()
    {
        // On duplique le material pour éviter de modifier le material global
        targetMaterial = targetRenderer.material;
        targetMaterial.DisableKeyword("_EMISSION");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetMaterial.SetColor("_EmissionColor", glowColor * intensity);
            targetMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetMaterial.DisableKeyword("_EMISSION");
        }
    }
}
