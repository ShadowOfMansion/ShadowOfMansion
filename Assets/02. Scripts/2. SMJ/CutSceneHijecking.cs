using UnityEngine;

public class CutSceneHijecking : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        player.transform.position += new Vector3(-0.01f, 0.003f, -0.0035f);
        enemy.transform.position += new Vector3(-0.01f, 0.003f, -0.0035f);
    }
}
