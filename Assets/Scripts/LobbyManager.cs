using System.Collections;
using System.Collections.Generic;
//using Unity.Services.
using Unity.Services.Core;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
	private async void Start()
	{
		await UnityServices.InitializeAsync();

		//AuthenticationService
	}
}
