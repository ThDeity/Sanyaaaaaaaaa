using UnityEngine;
public class Graph : MonoBehaviour
{
    [Range(10, 100)]
    public int resolution = 10;
    public float timeScale = 10f;
    private int currentResolution;
    private ParticleSystem.Particle[] points;
    private Rigidbody2D _cube;

    private void CreatePoints()
    {
        currentResolution = resolution;
        points = new ParticleSystem.Particle[resolution];
        float increment = 1f / (resolution - 1);
        for (int i = 0; i < resolution; i++)
        {
            float x = i * increment;
            points[i].position = new Vector3(x, 0f, 0f);
            points[i].color = new Color(255, 0f, 0f);
            points[i].size = 0.1f;
        }
    }

    void Start()
    {
        _cube = GameObject.Find("Cube").GetComponent<Rigidbody2D>();

        if (resolution < 10 || resolution > 100) 
        {
            Debug.LogWarning("Разрешение графика вышло за границы, сброшено в минимум", this);
            resolution = 10;
        }
        points = new ParticleSystem.Particle[resolution];
        float increment = 1f / (resolution - 1);
        for (int i = 0; i < resolution; i++)
        {
            float x = i * increment;
            points[i].position = new Vector3(x, 0f, 0f);
            points[i].color = new Color(255, 0f, 0f);
            points[i].size = 0.1f;
        }
    }
    void Update()
    {
        if (currentResolution != resolution)
            CreatePoints();

        for (int i = 0; i < resolution; i++)
        {
            Vector3 p = points[i].position;
            p.y = _cube.velocity.magnitude;
            //p.x = Time. / timeScale;
            points[i].position = p;
            Color c = points[i].color;
            c.g = p.y;
            points[i].color = c;
        }
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }
}