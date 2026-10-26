using Newtonsoft.Json;
using NNNES.Emulator.Core.Tests.Emulator.Converters;
using NNNES.Emulator.Core.Tests.Proxy;
using NNNES.Emulator.Proxy;
using System.Text;
using static NNNES.Emulator.Proxy.Nes;

namespace NNNES.Emulator.Core.Tests.Emulator
{

    [TestFixture]
    public class InstructionsTests
    {
        [TestCase("00 88 2e")]
        public void ShouldCorrectlyExecuteInstructions(string testName)
        {
            var configuredDataPath = @"F:\Projekty\NES\nes6502\v1";
            
            var dataPath = Path.IsPathRooted(configuredDataPath)
                ? configuredDataPath
                : Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, configuredDataPath));
            
            var testFile = Directory.GetFiles(dataPath);

            var firstFile = testFile[0];

            var testFileContent = File.ReadAllText(firstFile);

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new RamEntryConverter());
            settings.Converters.Add(new CycleConverter());

            var testCases = JsonConvert.DeserializeObject<InstructionsTestCase[]>(testFileContent, settings);

            var cartridgeMemory = new byte[0x8000];
            var ram = new byte[0x800];

            const string header = "NES\x001a";

            foreach (var testCase in testCases)
            {
                if (testCase.Name != testName)
                {
                    continue;
                }

                Encoding.ASCII.GetBytes(header).CopyTo(cartridgeMemory, 0);

                var nes = new NesDebug();
                var nesCartridge = new NesCartridge(cartridgeMemory);
                nes.SetCartridge(nesCartridge);

                for(var i = 0; i < testCase.InitialState.Ram.Count; i++)
                {
                    var ramEntry = testCase.InitialState.Ram[i];
                    nes.WriteToBus(ramEntry.Address, ramEntry.Value);
                }

                var cpuRegisters = new CpuRegisters
                {
                    X = testCase.InitialState.X,
                    Y = testCase.InitialState.Y,
                    Accumulator = testCase.InitialState.Accumulator,
                    ProgramCounter = testCase.InitialState.ProgramCounter,
                    Status = testCase.InitialState.Status,
                    Stack = testCase.InitialState.StackPointer
                };

                nes.SetRegisters(cpuRegisters);

                nes.Clock();

                cpuRegisters = nes.GetRegisters();

                for(var i = 0; i < testCase.FinalState.Ram.Count; i++)
                {
                    var expectedRamEntry = testCase.FinalState.Ram[i];
                    var actualValue = nes.ReadFromBus(expectedRamEntry.Address);
                    Assert.That(actualValue, Is.EqualTo(expectedRamEntry.Value),
                        $"[${testCase.Name}] RAM value at address {expectedRamEntry.Address} does not match expected value.");
                }
            }
        }
    }
}
