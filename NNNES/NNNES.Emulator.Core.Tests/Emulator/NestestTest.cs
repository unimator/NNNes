using NNNES.Emulator.Proxy;
using System.Text.RegularExpressions;

namespace NNNES.Emulator.Core.Tests.Emulator;

[TestFixture]
public class NestestTest
{

    [Test]
    public void TestAgainstNestetRom()
    {
        var romPath = @"F:\Projekty\NES\nestest.nes";
        var logFile = @"F:\Projekty\NES\nestest.log";

        var nes = new Nes();

        var cartridgeContent = File.ReadAllBytes(romPath);
        var nesCartridge = new NesCartridge(cartridgeContent);
        nes.SetCartridge(nesCartridge);
        nes.Reset();
        var logs = File.ReadLines(logFile);

        var registers = nes.GetRegisters();
        nes.SetRegisters(new NNNES.Emulator.Proxy.Proxy.CpuRegisters
        {
            Accumulator = registers.Accumulator,
            Stack = registers.Stack,
            Status = 0x24, 
            X = registers.X,
            Y = registers.Y,
            ProgramCounter = 0xC000
        });

        var pattern = new Regex(
    @"^(?<pc>[0-9A-F]{4})\s+.*?\bA:(?<a>[0-9A-F]{2})\s+X:(?<x>[0-9A-F]{2})\s+Y:(?<y>[0-9A-F]{2})\s+P:(?<p>[0-9A-F]{2})\s+SP:(?<sp>[0-9A-F]{2})\b",
    RegexOptions.Compiled);

        var instr_index = 0;
        foreach (var line in logs)
        {
            var match = pattern.Match(line);
            if (!match.Success)
                Assert.Fail("Regex failed");

            ushort pc = Convert.ToUInt16(match.Groups["pc"].Value, 16);
            byte a = Convert.ToByte(match.Groups["a"].Value, 16);
            byte x = Convert.ToByte(match.Groups["x"].Value, 16);
            byte y = Convert.ToByte(match.Groups["y"].Value, 16);
            byte p = Convert.ToByte(match.Groups["p"].Value, 16);
            byte sp = Convert.ToByte(match.Groups["sp"].Value, 16);

            registers = nes.GetRegisters();

            Assert.That(registers.ProgramCounter, Is.EqualTo(pc), "Program Counter incorrect");
            Assert.That(registers.Stack, Is.EqualTo(sp), "Stack Pointer incorrect");
            Assert.That(registers.X, Is.EqualTo(x), "X incorrect");
            Assert.That(registers.Y, Is.EqualTo(y), "Y incorrect");
            Assert.That(registers.Status, Is.EqualTo(p), "Status incorrect");
            Assert.That(registers.Accumulator, Is.EqualTo(a), "Accumulator incorrect");

            nes.NextInstruction();
            instr_index++;
        }
    }
}
