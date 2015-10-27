using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public static bool worldCreated = false;
	const string version = "v0.0.1";
	public string roomName = "Galaxy";
	public Transform spawnPoint;
	public string playerPrefabName = "ship";
	public GameObject gameTitle;

	public int numberOfCrates;
	public float space_width, space_height;
	
	void Start() {
		PhotonNetwork.ConnectUsingSettings(version);
	}

	void OnJoinedLobby() {
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom() {
		gameTitle.SetActive(false);
		PhotonNetwork.Instantiate(playerPrefabName,
								  spawnPoint.position,
								  spawnPoint.rotation,
								  0);

		if (!worldCreated) {
			RandomlyInstantiateNetworkObjects("crate", space_width, space_height, 0, numberOfCrates);
			//RandomlyInstantiateNetworkObjects("meteor1", space_width, space_height, 10, 20);
			worldCreated = true;
		}

	}

	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void RandomlyInstantiateNetworkObjects(string prefab_name, float width, float height, float depth, int number_of_instances) {
		for (int i = 0; i < number_of_instances; i++) {
			float x = Random.Range(-width, width);
			float y = Random.Range(-height, height);
			float z = Random.Range(-depth, depth);
			Vector3 position = new Vector3(x, y, z);
			PhotonNetwork.Instantiate(prefab_name, position, Quaternion.identity, 0);
		}
	}


}
