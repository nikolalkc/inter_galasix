using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	const string version = "v0.0.1";
	public string roomName = "Galaxy";
	public Transform spawnPoint;
	public string playerPrefabName = "ship";

	void Start() {
		PhotonNetwork.ConnectUsingSettings(version);
	}

	void OnJoinedLobby() {
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom() {
		PhotonNetwork.Instantiate(playerPrefabName,
								  spawnPoint.position,
								  spawnPoint.rotation,
								  0);
	}

}
