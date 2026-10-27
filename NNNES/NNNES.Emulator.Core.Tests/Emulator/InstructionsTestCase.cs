using Newtonsoft.Json;

namespace NNNES.Emulator.Core.Tests.Emulator
{
    public class InstructionsTestCase
    {
        public class State
        {
            public class RamEntry
            {
                public ushort Address { get; set; }
                public byte Value { get; set; }
            }

            [JsonProperty("pc")]
            public ushort ProgramCounter { get; set; }

            [JsonProperty("a")]
            public byte Accumulator { get; set; }

            [JsonProperty("x")]
            public byte X { get; set; }

            [JsonProperty("y")]
            public byte Y { get; set; }

            [JsonProperty("p")]
            public byte Status { get; set; }

            [JsonProperty("s")]
            public byte StackPointer { get; set; }

            [JsonProperty("ram")]
            public List<RamEntry> Ram;
        }

        public class Cycle
        {
            public ushort Address { get; set; }
            public byte Value { get; set; }
            public string? Type { get; set; }
        }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("initial")]
        public State InitialState { get; set; }

        [JsonProperty("final")]
        public State FinalState { get; set; }

        [JsonProperty("cycles")]
        public List<Cycle> Cycles { get; set; }
    }
}