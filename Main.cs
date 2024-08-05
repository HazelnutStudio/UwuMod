using Il2CppTMPro;
using MelonLoader;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Hazelnut272.UwuMod
{
    public class Main : MelonMod
    {
        public static Main Instance;

        private TextMeshProUGUI _tutorialText;
        private TextMeshProUGUI _cash;
        private Image _cashSprite;

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            Instance = this;
            LoggerInstance.Msg("Uwu mod enabled :3");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Input.GetKeyDown(KeyCode.F5))
            {
                LoggerInstance.Msg("disappearing sprite :3");
                _cashSprite = GameObject.Find("Canvas-HUD/Contents/CashCounter(Clone)/Icon").GetComponent<Image>();
                _cashSprite.color = new Color(0, 0, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.F6))
            {
                LoggerInstance.Msg(":3");
                _cash = GameObject.Find("Canvas-HUD/Contents/CashCounter(Clone)/Count").GetComponent<TextMeshProUGUI>();
            }

            if (Input.GetKey(KeyCode.F7))
            {
                _cash.text = ":3";
            }
        }

        public static void Log(string msg)
        {
            Instance.LoggerInstance.Msg(msg);
        }

        public void OnPauseMenuOpened()
        {
            LoggerInstance.Msg("Yay!~");

            MelonCoroutines.Start(TranslatePauseMenu());
            return;



            //LoggerInstance.Msg($"set text. tutorialText = [{_tutorialText.ToString()}], quitText = [{quitText.ToString()}], restartText = [{restartText.ToString()}], resumeText = [{resumeText.ToString()}]");
        }

        private IEnumerator TranslatePauseMenu()
        {
            yield return new WaitForSecondsRealtime(0.05f);
            if (GameObject.Find("Canvas-Overlay/Contents/SimpleMenuPrompt/PauseMenu(Clone)") == null)
            {
                yield break;
            }

            string menuRoot = "Canvas-Overlay/Contents/SimpleMenuPrompt/PauseMenu(Clone)/VerticalLayout/";

            _tutorialText = GameObject.Find(menuRoot + "TutorialButton/Text").GetComponent<TextMeshProUGUI>();
            _tutorialText.text = "Tutowiaw >.<";
            TextMeshProUGUI quitText = GameObject.Find(menuRoot + "QuitButton/Backing/Text").GetComponent<TextMeshProUGUI>();
            quitText.text = "Quit tuwu desktop QwQ";
            TextMeshProUGUI restartText = GameObject.Find(menuRoot + "GiveUpButton/Backing/Text").GetComponent<TextMeshProUGUI>();
            restartText.text = "Westawt \\^o^/";
            TextMeshProUGUI resumeText = GameObject.Find(menuRoot + "ResumeButton/Backing/Text").GetComponent<TextMeshProUGUI>();
            resumeText.text = "Wesume UwU";
        }
    }
}
