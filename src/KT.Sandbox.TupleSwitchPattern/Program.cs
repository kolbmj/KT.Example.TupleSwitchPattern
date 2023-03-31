using KT.Sandbox.TupleSwitchPattern.Enums;

namespace KT.Sandbox.TupleSwitchPattern
{
    /// <summary>
    /// This class demonstrates using tuple-based switch expressions to simplify
    /// the nested-if madness.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry-point of the application.  Report on the return value of each
        /// engine type determination method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //define our parameters
            const string manufacturer_name = "Corellian Engineering Corporation";
            const string model_name = "Millenium Falcon";
            const string trim_name = "YT-1300 light fighter";

            //get the engine type by calling each of the 'determine' methods
            EngineType iffy = DetermineEngineTypeIffy(manufacturer: manufacturer_name, model: model_name, trim: trim_name);
            EngineType expressy = DetermineEngineTypeExpressy(manufacturer: manufacturer_name, model: model_name, trim: trim_name);

            //report
            Console.WriteLine(Enum.GetName<EngineType>(iffy));
            Console.WriteLine(Enum.GetName<EngineType>(expressy));
        }

        /// <summary>
        /// Determine the engine types based on nested 'if' statements
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
        private static EngineType DetermineEngineTypeIffy(string manufacturer, string model, string trim)
        {
            if (manufacturer == "Audi")
            {
                if (model == "A8")
                {
                    if (trim == "Hybrid")
                    {
                        return EngineType.Electric;
                    }
                    else
                    {
                        return EngineType.InternalCombustion;
                    }
                }

                return EngineType.Unknown;
            }
            else if (manufacturer == "Tesla")
            {
                return EngineType.Electric;
            }
            else if (model == "USS Enterprise")
            {
                if (manufacturer == "Newsport News Shipbuilding")
                    return EngineType.Nuclear;

                if (manufacturer == "Utopia Planitia Fleet Yards")
                    return EngineType.Impulse;
            }
            else if (manufacturer == "Corellian Engineering Corporation" && model == "Millenium Falcon" && trim == "YT-1300 light fighter")
            {
                return EngineType.SublightThrusters;
            }

            return EngineType.Unknown;
        }

        /// <summary>
        /// Determine engine type based on a tuple-based switch expression
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
        private static EngineType DetermineEngineTypeExpressy(string manufacturer, string model, string trim) =>
            (manufacturer, model, trim) switch
            {
                ("Audi", "A8", "Hybrid") => EngineType.Electric,
                ("Audi", "A8", _) => EngineType.InternalCombustion,
                ("Tesla", _, _) => EngineType.Electric,
                ("Newsport News Shipbuilding", "USS Enterprise", _) => EngineType.Nuclear,
                ("Utopia Planitia Fleet Yards", "USS Enterprise", _) => EngineType.Impulse,
                ("Corellian Engineering Corporation", "Millenium Falcon", "YT-1300 light fighter") => EngineType.SublightThrusters,
                _ => EngineType.Unknown
            };
    }
}