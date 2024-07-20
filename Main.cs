using System;
using MelonLoader;
using UnityEngine;
using Il2CppHabitanks;

namespace UwuMod
{
    public class Main : MelonMod
    {
        public static Main Instance;
        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            Instance = this;
            LoggerInstance.Msg("Uwu mod enabled :3");
        }

        public static void Log(string msg)
        {
            Instance.LoggerInstance.Msg(msg);
        }
    }
}
