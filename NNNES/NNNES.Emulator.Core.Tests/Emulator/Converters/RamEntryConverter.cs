using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NNNES.Emulator.Core.Tests.Emulator.InstructionsTestCase.State;

namespace NNNES.Emulator.Core.Tests.Emulator.Converters
{
    public class RamEntryConverter : JsonConverter<RamEntry>
    {
        public override RamEntry ReadJson(
            JsonReader reader,
            Type objectType,
            RamEntry existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var array = JArray.Load(reader);

            if (array.Count != 2)
                throw new JsonSerializationException(
                    $"Expected a two-element array for {nameof(RamEntry)}.");

            return new RamEntry
            {
                Address = array[0].ToObject<ushort>(),
                Value = array[1].ToObject<byte>()
            };
        }

        public override void WriteJson(
            JsonWriter writer,
            RamEntry value,
            JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.Address);
            writer.WriteValue(value.Value);
            writer.WriteEndArray();
        }
    }
}
