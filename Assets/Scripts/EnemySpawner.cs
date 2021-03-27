using UnityEngine;

public class EnemySpawner : SingletonMonoBehaviour<EnemySpawner>
{
    bool inGame = false;

    float time = 0f;
    float spawnCicleTime = 1f;
    [SerializeField] GameObject enemyObject = null;
    float fieldSize = 10f;
    [SerializeField] GameObject playerObject = null;

    private void FixedUpdate()
    {
        if (inGame)
        {
            time += Time.deltaTime;
            if (time >= spawnCicleTime)
            {
                float x;
                float y;
                while (true)
                {
                    x = Random.Range(-fieldSize, fieldSize);
                    y = Random.Range(-fieldSize, fieldSize);

                    if (x - 2 < playerObject.transform.position.x && x + 2 > playerObject.transform.position.x)
                    {
                        if (y - 2 < playerObject.transform.position.x && y+2 > playerObject.transform.position.x)
                        {
                            continue;
                        }
                    }

                    break;
                }
                
                Vector3 position = new Vector3(x, 0, y);
                Instantiate(enemyObject, position, Quaternion.identity);
                time = 0f;

            }
        }
    }

    public void StartGame()
    {
        inGame = true;
    }
}
