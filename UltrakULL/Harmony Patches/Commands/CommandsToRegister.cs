using GameConsole;
using GameConsole.CommandTree;
using plog;
using System.Linq;

using UltrakULL.json;

namespace UltrakULL.Commands
{
    public sealed class CommandToRegister : CommandRoot, IConsoleLogger
    {
        public CommandToRegister(Console con) : base(con)
        {
        }

        public override string Name => "ultrakull";
        public override string Description => "tons of setting";

        protected override Branch BuildTree(Console con)
        {
            return Branch(Name,
                        Branch("set",
                                Leaf<string>("lang", lang => LanguageManager.SetCurrentLanguage(lang))
                        ),
                        Branch("list",
                                Leaf("lang", () =>
                                {
                                    Log.Info("Available Languages:");
                                    foreach (var kvp in LanguageManager.allLanguages)
                                    {
                                        Log.Info($"- {kvp.Key}");
                                    }
                                })
                            ),
                        Leaf("getversion", () => Log.Info($"UltrakULL version: {MainPatch.GetVersion()}")),
                        Leaf("isInitializeSuccessful", () =>
                        {
                            Log.Info($"Initialize Statu: {MainPatch.Instance.ready}");
                            if (!MainPatch.Instance.ready)
                            {
                                Log.Info($"Reason : {MainPatch.Instance.initializeErrorMessage}");
                            }
                        })
            );


        }

        public Logger Log { get; } = new Logger("ultrakull");
    }
}

