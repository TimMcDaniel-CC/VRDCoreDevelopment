using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(LineRenderer))]
public class CurveRenderer : MonoBehaviour
{
    [SerializeField]
    private int pointSamples = 64;
    
    
    [SerializeField]
    private float maxDistance = 10f;
    [SerializeField]
    private float maxHeight = 2.0f;
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private float curveWidth = 0.01f;
    [SerializeField]
    private Material material;
    [SerializeField]
    private Gradient colorGradient;

    [SerializeField, HideInInspector]
    private LineRenderer lineRenderer;

    private void Reset()
    {
        curve = AnimationCurve.Linear(0f, 0f, 1f, 0f);
        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.widthCurve = AnimationCurve.Linear(0f, curveWidth, 1f, curveWidth);
        colorGradient = new Gradient();
        GradientColorKey[] colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(Color.red, 0f);
        colors[1] = new GradientColorKey(Color.red, 1f);

        GradientAlphaKey[] alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(0.5f, 0.0f);
        alphas[1] = new GradientAlphaKey(0.5f, 1.0f);
        colorGradient.SetKeys(colors, alphas);
        
        lineRenderer.material = material;
        lineRenderer.colorGradient = colorGradient;

    }
    private void Update()
    {
        SetCurve();
    }
    private void SetCurve()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointSamples;
        float distanceBetweenPoints = maxDistance / pointSamples;
        lineRenderer.colorGradient = colorGradient;
        lineRenderer.widthCurve = AnimationCurve.Linear(0f, curveWidth, 1f, curveWidth);

        for(int i = 0; i < pointSamples; i++)
        {
            float zPos =  i * distanceBetweenPoints;
            float yPos = ((float)i / pointSamples);
            yPos = curve.Evaluate(yPos) * maxHeight;
            Vector3 origin = transform.position;
            
            lineRenderer.SetPosition(i, new Vector3(origin.x, origin.y + yPos, origin.z + zPos));

        }
    }
}
