using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public Object currentPlayer;
	public Vector3 playerPosition;

	public GameObject enemy;
	public Object currentEnemy;
	public Vector3 spawnValues;
	public int enemyCount;

	public float startWait;
	public float spawnWait;
	public float waveWait;

	// Use this for initialization
	void Start ()
	{
		currentPlayer = Instantiate (player, playerPosition, Quaternion.identity);

		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < enemyCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 
				                                     spawnValues.y,
				                                     Random.Range (-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
				currentEnemy =  Instantiate (enemy, spawnPosition, spawnRotation);

				((GameObject) currentEnemy).GetComponent<AI>().SetPlayer((GameObject) currentPlayer);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
