using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
            Destroy(this.gameObject);
    }
}
