using UnityEngine;
using MelonLoader;
using HarmonyLib;
using Il2CppHabitanks.UI;

namespace Hazelnut272.UwuMod
{
    [HarmonyPatch(typeof(OpenPauseMenuButton), nameof(OpenPauseMenuButton.Activate))]
    [HarmonyPatch(MethodType.Normal)]
    public static class PauseMenuPatch
    {
        public static void Postfix()
        {
            Main.Instance.OnPauseMenuOpened();
        }
    }
}