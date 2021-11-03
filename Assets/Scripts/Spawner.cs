using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToSpawn;
    [SerializeField] private Transform InitialPosition;

    [SerializeField] private int Rows = 4;
    [SerializeField] private int Columns = 8;

    private float waveStepRight = 1f, spaceColumns = 0.3f, spaceRows = 0.3f;

    //Test Github
    private void Awake()
    {
        for (int r = 0; r < Rows; r++)
        {
            float posY = InitialPosition.position.y - (spaceRows * r);

            for (int c = 0; c < Columns; c++)
            {
                Vector2 objectPosition = new Vector2(InitialPosition.position.x + (spaceColumns * c), posY);
                GameObject go = Instantiate(ObjectToSpawn, objectPosition, Quaternion.identity);
                go.transform.SetParent(transform);
                go.name = "Enemy" + (c + 1) + "-Row:" + (r + 1);
            }
        }
    }
}