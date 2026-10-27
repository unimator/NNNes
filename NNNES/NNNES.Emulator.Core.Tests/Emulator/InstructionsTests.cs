using Newtonsoft.Json;
using NNNES.Emulator.Core.Tests.Emulator.Converters;
using NNNES.Emulator.Core.Tests.Proxy;
using NNNES.Emulator.Proxy.Proxy;

namespace NNNES.Emulator.Core.Tests.Emulator
{

    [TestFixture]
    public class InstructionsTests
    {
        [TestCase("00")]
        [TestCase("01")]
        [TestCase("02")]
        [TestCase("03")]
        [TestCase("04")]
        [TestCase("05")]
        [TestCase("06")]
        [TestCase("07")]
        [TestCase("08")]
        [TestCase("09")]
        [TestCase("0A")]
        [TestCase("0B")]
        [TestCase("0C")]
        [TestCase("0D")]
        [TestCase("0E")]
        [TestCase("0F")]
        [TestCase("10")]
        [TestCase("11")]
        [TestCase("12")]
        [TestCase("13")]
        [TestCase("14")]
        [TestCase("15")]
        [TestCase("16")]
        [TestCase("17")]
        [TestCase("18")]
        [TestCase("19")]
        [TestCase("1A")]
        [TestCase("1B")]
        [TestCase("1C")]
        [TestCase("1D")]
        [TestCase("1E")]
        [TestCase("1F")]
        [TestCase("20")]
        [TestCase("21")]
        [TestCase("22")]
        [TestCase("23")]
        [TestCase("24")]
        [TestCase("25")]
        [TestCase("26")]
        [TestCase("27")]
        [TestCase("28")]
        [TestCase("29")]
        [TestCase("2A")]
        [TestCase("2B")]
        [TestCase("2C")]
        [TestCase("2D")]
        [TestCase("2E")]
        [TestCase("2F")]
        [TestCase("30")]
        [TestCase("31")]
        [TestCase("32")]
        [TestCase("33")]
        [TestCase("34")]
        [TestCase("35")]
        [TestCase("36")]
        [TestCase("37")]
        [TestCase("38")]
        [TestCase("39")]
        [TestCase("3A")]
        [TestCase("3B")]
        [TestCase("3C")]
        [TestCase("3D")]
        [TestCase("3E")]
        [TestCase("3F")]
        [TestCase("40")]
        [TestCase("41")]
        [TestCase("42")]
        [TestCase("43")]
        [TestCase("44")]
        [TestCase("45")]
        [TestCase("46")]
        [TestCase("47")]
        [TestCase("48")]
        [TestCase("49")]
        [TestCase("4A")]
        [TestCase("4B")]
        [TestCase("4C")]
        [TestCase("4D")]
        [TestCase("4E")]
        [TestCase("4F")]
        [TestCase("50")]
        [TestCase("51")]
        [TestCase("52")]
        [TestCase("53")]
        [TestCase("54")]
        [TestCase("55")]
        [TestCase("56")]
        [TestCase("57")]
        [TestCase("58")]
        [TestCase("59")]
        [TestCase("5A")]
        [TestCase("5B")]
        [TestCase("5C")]
        [TestCase("5D")]
        [TestCase("5E")]
        [TestCase("5F")]
        [TestCase("60")]
        [TestCase("61")]
        [TestCase("62")]
        [TestCase("63")]
        [TestCase("64")]
        [TestCase("65")]
        [TestCase("66")]
        [TestCase("67")]
        [TestCase("68")]
        [TestCase("69")]
        [TestCase("6A")]
        [TestCase("6B")]
        [TestCase("6C")]
        [TestCase("6D")]
        [TestCase("6E")]
        [TestCase("6F")]
        [TestCase("70")]
        [TestCase("71")]
        [TestCase("72")]
        [TestCase("73")]
        [TestCase("74")]
        [TestCase("75")]
        [TestCase("76")]
        [TestCase("77")]
        [TestCase("78")]
        [TestCase("79")]
        [TestCase("7A")]
        [TestCase("7B")]
        [TestCase("7C")]
        [TestCase("7D")]
        [TestCase("7E")]
        [TestCase("7F")]
        [TestCase("80")]
        [TestCase("81")]
        [TestCase("82")]
        [TestCase("83")]
        [TestCase("84")]
        [TestCase("85")]
        [TestCase("86")]
        [TestCase("87")]
        [TestCase("88")]
        [TestCase("89")]
        [TestCase("8A")]
        [TestCase("8B")]
        [TestCase("8C")]
        [TestCase("8D")]
        [TestCase("8E")]
        [TestCase("8F")]
        [TestCase("90")]
        [TestCase("91")]
        [TestCase("92")]
        // [TestCase("93")] // Unstable
        [TestCase("94")]
        [TestCase("95")]
        [TestCase("96")]
        [TestCase("97")]
        [TestCase("98")]
        [TestCase("99")]
        [TestCase("9A")]
        // [TestCase("9B")] // Unstable
        // [TestCase("9C")] // Unstable
        [TestCase("9D")]
        // [TestCase("9E")] // Unstable
        // [TestCase("9F")] // Unstable
        [TestCase("A0")]
        [TestCase("A1")]
        [TestCase("A2")]
        [TestCase("A3")]
        [TestCase("A4")]
        [TestCase("A5")]
        [TestCase("A6")]
        [TestCase("A7")]
        [TestCase("A8")]
        [TestCase("A9")]
        [TestCase("AA")]
        [TestCase("AB")]
        [TestCase("AC")]
        [TestCase("AD")]
        [TestCase("AE")]
        [TestCase("AF")]
        [TestCase("B0")]
        [TestCase("B1")]
        [TestCase("B2")]
        [TestCase("B3")]
        [TestCase("B4")]
        [TestCase("B5")]
        [TestCase("B6")]
        [TestCase("B7")]
        [TestCase("B8")]
        [TestCase("B9")]
        [TestCase("BA")]
        [TestCase("BB")]
        [TestCase("BC")]
        [TestCase("BD")]
        [TestCase("BE")]
        [TestCase("BF")]
        [TestCase("C0")]
        [TestCase("C1")]
        [TestCase("C2")]
        [TestCase("C3")]
        [TestCase("C4")]
        [TestCase("C5")]
        [TestCase("C6")]
        [TestCase("C7")]
        [TestCase("C8")]
        [TestCase("C9")]
        [TestCase("CA")]
        [TestCase("CB")]
        [TestCase("CC")]
        [TestCase("CD")]
        [TestCase("CE")]
        [TestCase("CF")]
        [TestCase("D0")]
        [TestCase("D1")]
        [TestCase("D2")]
        [TestCase("D3")]
        [TestCase("D4")]
        [TestCase("D5")]
        [TestCase("D6")]
        [TestCase("D7")]
        [TestCase("D8")]
        [TestCase("D9")]
        [TestCase("DA")]
        [TestCase("DB")]
        [TestCase("DC")]
        [TestCase("DD")]
        [TestCase("DE")]
        [TestCase("DF")]
        [TestCase("E0")]
        [TestCase("E1")]
        [TestCase("E2")]
        [TestCase("E3")]
        [TestCase("E4")]
        [TestCase("E5")]
        [TestCase("E6")]
        [TestCase("E7")]
        [TestCase("E8")]
        [TestCase("E9")]
        [TestCase("EA")]
        [TestCase("EB")]
        [TestCase("EC")]
        [TestCase("ED")]
        [TestCase("EE")]
        [TestCase("EF")]
        [TestCase("F0")]
        [TestCase("F1")]
        [TestCase("F2")]
        [TestCase("F3")]
        [TestCase("F4")]
        [TestCase("F5")]
        [TestCase("F6")]
        [TestCase("F7")]
        [TestCase("F8")]
        [TestCase("F9")]
        [TestCase("FA")]
        [TestCase("FB")]
        [TestCase("FC")]
        [TestCase("FD")]
        [TestCase("FE")]
        [TestCase("FF")]
        public void ShouldCorrectlyExecuteInstructions(string file)
        {
            var configuredDataPath = @"F:\Projekty\NES\nes6502\v1";
            
            var dataPath = Path.IsPathRooted(configuredDataPath)
                ? configuredDataPath
                : Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, configuredDataPath));

            var testFile = Path.Combine(configuredDataPath, file + ".json");

            var testFileContent = File.ReadAllText(testFile);

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new RamEntryConverter());
            settings.Converters.Add(new CycleConverter());

            var testCases = JsonConvert.DeserializeObject<InstructionsTestCase[]>(testFileContent, settings);

            foreach (var testCase in testCases)
            {
                var nes = new NesDebug();

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
