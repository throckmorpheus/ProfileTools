using HarmonyLib;
using OWML.Common;
using OWML.ModHelper;
using OWML.ModHelper.Events;
using OWML.ModHelper.Menus.NewMenuSystem;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace ProfileTools;

public class ProfileTools : ModBehaviour
{
	public static ProfileTools Instance;

	public TitleScreenFooterDisplay FooterDisplay { get; private set; }

	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		// Starting here, you'll have access to OWML's mod helper.
		Log($"{nameof(ProfileTools)} is loaded!", MessageType.Success);

		new Harmony("Throckmorpheus.ProfileTools").PatchAll(Assembly.GetExecutingAssembly());

		StandaloneProfileManager.SharedInstance.Initialize();

		FooterDisplay = new TitleScreenFooterDisplay();
		FooterDisplay.SetProfileName(StandaloneProfileManager.SharedInstance._currentProfile.profileName);
	}
	
	public void Log(string message, MessageType type = MessageType.Info)
	{
		ModHelper.Console.WriteLine(message, type);
	}
}
