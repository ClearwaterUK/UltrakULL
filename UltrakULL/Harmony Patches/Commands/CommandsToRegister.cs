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
                        Leaf("getVersion", () => Log.Info($"UltrakULL version: {MainPatch.GetVersion()}")),
                        Leaf("isInitialzationSuccessfull", () =>
                        {
                            Log.Info($"Initialize status: {MainPatch.Instance.ready}");
                            if (!MainPatch.Instance.ready)
                            {
                                Log.Info($"Step with issue: {MainPatch.Instance.initializeErrorMessage.statu}");
                                Log.Info($"Error Meesage: {MainPatch.Instance.initializeErrorMessage.e}");
                            }
                        })
                        );
        }

        public Logger Log { get; } = new Logger("ultrakull");
    }
}

