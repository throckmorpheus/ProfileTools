using HarmonyLib;﻿
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProfileTools;

[HarmonyPatch]
public class Patches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(TitleScreenManager), nameof(TitleScreenManager.FadeInTitleLogo))]
    public static void FadeInTitleLogo_Postfix(TitleScreenManager __instance) {
        ProfileTools.Instance.FooterDisplay.Setup(__instance);
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StandaloneProfileManager), nameof(StandaloneProfileManager.SwitchProfile))]
    public static void SwitchProfile_Postfix(ref bool __result, string profileName) {
        // If switch was successful
        if (__result) {
            ProfileTools.Instance.FooterDisplay.SetProfileName(profileName);
        }
    }
}