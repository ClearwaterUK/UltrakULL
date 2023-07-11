using System.Collections.Generic;
using Antlr4.StringTemplate;
using Newtonsoft.Json;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act1Vn
    {
        private static readonly TemplateGroup Templates = new TemplateGroupString(Resources.Mirage);
        private static readonly VisualNovel VisualNovel = LanguageManager.CurrentLanguage.visualnovel;
        
        // A key is a relative path to post-intro dialogs. The value is a template name
        private static readonly Dictionary<string, string> IntroTemplates;
        
        // Same, but post-intro
        private static readonly Dictionary<string, string> MirageTemplates;

        static Act1Vn()
        {
            Templates.EnableCache = false;
            
            var mapperDefinition = new
            {
                intro = new Dictionary<string, string>(),
                mirage = new Dictionary<string, string>()
            };
            var parsedObjects  = JsonConvert.DeserializeAnonymousType(Resources.MirageDialogObjects, mapperDefinition);
            
            IntroTemplates = parsedObjects.intro;
            MirageTemplates = parsedObjects.mirage;
        }
            
        public static void PatchPrompts(ref GameObject canvasObj)
        {

            GameObject choicesBaseObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "PowerUpVignette"),"Panel"),"Aspect Ratio Mask");

            GameObject fallenChoices = GetGameObjectChild(choicesBaseObject, "Fallen");

            //Annoyingly both choice box objects in the Fallen sections are named the same. So we'll do this to pick up both of them.
            List<GameObject> fallenChoiceObjects = new List<GameObject>();
            foreach (Transform a in fallenChoices.transform)
            {
                if (a.gameObject.name == "Choices Box")
                {
                    fallenChoiceObjects.Add(a.gameObject);
                }
            }

            GameObject fallenChoice1Object = fallenChoiceObjects[0];
            GameObject fallenChoice2Object = fallenChoiceObjects[1];

            //Fallen
            Text fallenChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice1Object, "Button (A)"),"Text"));
            fallenChoice1ChoiceAText.text = VisualNovel.visualnovel_fallenPromptFirst1;

            Text fallenChoice1ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice1Object, "Button (B)"), "Text"));
            fallenChoice1ChoiceBText.text = VisualNovel.visualnovel_fallenPromptFirst2;

            Text fallenChoice1ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice1Object, "Button (C)"), "Text"));
            fallenChoice1ChoiceCText.text = VisualNovel.visualnovel_fallenPromptFirst3;

            Text fallenChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice2Object, "Button (A)"), "Text"));
            fallenChoice2ChoiceAText.text = VisualNovel.visualnovel_fallenPromptSecond1;

            Text fallenChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice2Object, "Button (B)"), "Text"));
            fallenChoice2ChoiceBText.text = VisualNovel.visualnovel_fallenPromptSecond2;

            Text fallenChoice2ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice2Object, "Button (C)"), "Text"));
            fallenChoice2ChoiceCText.text = VisualNovel.visualnovel_fallenPromptSecond3;

            //Middle choice 1
            GameObject middleChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (1)");

            Text middleChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices1Object, "Button (A)"), "Text"));
            middleChoice1ChoiceAText.text = VisualNovel.visualnovel_middlePrompt1;

            Text middleChoice1ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices1Object, "Button (B)"), "Text"));
            middleChoice1ChoiceBText.text = VisualNovel.visualnovel_middlePrompt2;

            Text middleChoice1ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices1Object, "Button (C)"), "Text"));
            middleChoice1ChoiceCText.text = VisualNovel.visualnovel_middlePrompt3;


            //Middle choice 2
            GameObject middleChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (2)");

            Text middleChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices2Object, "Button (A)"), "Text"));
            middleChoice2ChoiceAText.text = VisualNovel.visualnovel_middlePromptSecondRecklessness;

            Text middleChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices2Object, "Button (B)"), "Text"));
            middleChoice2ChoiceBText.text = VisualNovel.visualnovel_middlePromptSecondWaiting;

            Text middleChoice2ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices2Object, "Button (C)"), "Text"));
            middleChoice2ChoiceCText.text = "...Pourquoi sommes-nous ici?";


            //Recklessness choice 1
            GameObject recklessnessChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box");

            Text recklessnessChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(recklessnessChoices1Object, "Button (A)"), "Text"));
            recklessnessChoice1ChoiceAText.text = VisualNovel.visualnovel_recklessnessPrompt1;

            Text recklessnessChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(recklessnessChoices1Object, "Button (B)"), "Text"));
            recklessnessChoice2ChoiceBText.text = VisualNovel.visualnovel_recklessnessPrompt2;

            //Recklessness choice 2
            GameObject recklessnessChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box (1)");
            Text recklessnessChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(recklessnessChoices2Object, "Button (A)"), "Text"));
            recklessnessChoice2ChoiceAText.text = VisualNovel.visualnovel_recklessnessPrompt3;

            //Waiting choice 1
            GameObject waitingChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box");

            Text waitingChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(waitingChoices1Object, "Button (A)"), "Text"));
            waitingChoice1ChoiceAText.text = VisualNovel.visualnovel_waitingPromptFirst1;

            Text waitingChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(waitingChoices1Object, "Button (B)"), "Text"));
            waitingChoice2ChoiceBText.text = VisualNovel.visualnovel_waitingPromptFirst2;

            //Waiting choice 2
            GameObject waitingChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box (1)");
            Text waitingChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(waitingChoices2Object, "Button (A)"), "Text"));
            waitingChoice2ChoiceAText.text = VisualNovel.visualnovel_waitingPromptThird;

            //Nihilism choice
            GameObject nihilismChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (2)");
            Text nihilismChoices1Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices1Object, "Button (A)"), "Text"));
            nihilismChoices1Text.text = VisualNovel.visualnovel_nihilismPrompt1;

            GameObject nihilismChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (3)");
            Text nihilismChoices2Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices2Object, "Button (A)"), "Text"));
            nihilismChoices2Text.text = VisualNovel.visualnovel_nihilismPrompt2;

            GameObject nihilismChoices3Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (4)");
            Text nihilismChoices3Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices3Object, "Button (A)"), "Text"));
            nihilismChoices3Text.text = VisualNovel.visualnovel_nihilismPrompt3;

            GameObject nihilismChoices4Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (5)");
            Text nihilismChoices4Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices4Object, "Button (A)"), "Text"));
            nihilismChoices4Text.text = VisualNovel.visualnovel_nihilismPrompt4;

            GameObject nihilismChoices5Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (6)");
            Text nihilismChoices5Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices5Object, "Button (A)"), "Text"));
            nihilismChoices5Text.text = VisualNovel.visualnovel_nihilismPrompt5;

            GameObject nihilismChoices6Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (7)");
            Text nihilismChoices6Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices6Object, "Button (A)"), "Text"));
            nihilismChoices6Text.text = VisualNovel.visualnovel_nihilismPrompt6;

            GameObject nihilismChoices7Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (8)");
            Text nihilismChoices7Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices7Object, "Button (A)"), "Text"));
            nihilismChoices7Text.text = VisualNovel.visualnovel_nihilismPrompt7;

            GameObject nihilismChoices8Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (9)");
            Text nihilismChoices8Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices8Object, "Button (A)"), "Text"));
            nihilismChoices8Text.text = VisualNovel.visualnovel_nihilismPrompt8;

            GameObject nihilismChoices9Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (10)");
            Text nihilismChoices9Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices9Object, "Button (A)"), "Text"));
            nihilismChoices9Text.text = VisualNovel.visualnovel_nihilismPrompt9;

            GameObject nihilismChoices10Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (11)");
            Text nihilismChoices10Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices10Object, "Button (A)"), "Text"));
            nihilismChoices10Text.text = VisualNovel.visualnovel_nihilismPrompt10;

            GameObject nihilismChoices11Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (12)");
            Text nihilismChoices11Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices11Object, "Button (A)"), "Text"));
            nihilismChoices11Text.text = VisualNovel.visualnovel_nihilismPrompt11;

            GameObject nihilismChoices12Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (13)");
            Text nihilismChoices12Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices12Object, "Button (A)"), "Text"));
            nihilismChoices12Text.text = VisualNovel.visualnovel_nihilismPrompt12;

            GameObject nihilismChoices13Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (14)");
            Text nihilismChoices13Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices13Object, "Button (A)"), "Text"));
            nihilismChoices13Text.text = VisualNovel.visualnovel_nihilismPrompt13;

            GameObject nihilismChoices14Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (16)");
            Text nihilismChoices14Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices14Object, "Button (A)"), "Text"));
            nihilismChoices14Text.text = VisualNovel.visualnovel_nihilismPrompt14;

            GameObject nihilismChoices15Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (17)");
            Text nihilismChoices15Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices15Object, "Button (A)"), "Text"));
            nihilismChoices15Text.text = VisualNovel.visualnovel_nihilismPrompt15;

            GameObject nihilismChoices16Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (18)");
            Text nihilismChoices16Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices16Object, "Button (A)"), "Text"));
            nihilismChoices16Text.text = VisualNovel.visualnovel_nihilismPrompt16;

            GameObject nihilismChoices17Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (19)");
            Text nihilismChoices17Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices17Object, "Button (A)"), "Text"));
            nihilismChoices17Text.text = VisualNovel.visualnovel_nihilismPrompt17;

            GameObject nihilismChoices18Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (20)");
            Text nihilismChoices18Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices18Object, "Button (A)"), "Text"));
            nihilismChoices18Text.text = VisualNovel.visualnovel_nihilismPrompt18;

            GameObject nihilismChoices19Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (21)");
            Text nihilismChoices19Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices19Object, "Button (A)"), "Text"));
            nihilismChoices19Text.text = VisualNovel.visualnovel_nihilismPrompt19;

            GameObject nihilismChoices20Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (22)");
            Text nihilismChoices20Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices20Object, "Button (A)"), "Text"));
            nihilismChoices20Text.text = VisualNovel.visualnovel_nihilismPrompt20;

            GameObject nihilismChoices21Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (25)");
            Text nihilismChoices21Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices21Object, "Button (A)"), "Text"));
            nihilismChoices21Text.text = VisualNovel.visualnovel_nihilismPrompt21;

            GameObject nihilismChoices22Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (23)");
            Text nihilismChoices22Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices22Object, "Button (A)"), "Text"));
            nihilismChoices22Text.text = VisualNovel.visualnovel_nihilismPrompt22;

            GameObject nihilismChoices23Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (24)");
            Text nihilismChoices23Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices23Object, "Button (A)"), "Text"));
            nihilismChoices23Text.text = VisualNovel.visualnovel_nihilismPrompt23;

            //Conclusion choice
            GameObject conclusionChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Conclusion"), "Choices Box (2)");
            Text conclusionChoices1Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(conclusionChoices1Object, "Button (A)"), "Text"));
            Text conclusionChoices2Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(conclusionChoices1Object, "Button (B)"), "Text"));
            conclusionChoices1Text.text = VisualNovel.visualnovel_conclusionPrompt1;
            conclusionChoices2Text.text = VisualNovel.visualnovel_conclusionPrompt2;

        }

        public static string GetString(IntermissionController controller)
        {
            var parent = controller.transform.parent;
            var template = parent.name == "Intro"
                ? IntroTemplates[controller.name]
                : MirageTemplates[parent.parent.name + "/" + parent.name];

            return Templates.GetInstanceOf(template)
                .Add("visualnovel", VisualNovel)
                .Render();
        }
    }
}
