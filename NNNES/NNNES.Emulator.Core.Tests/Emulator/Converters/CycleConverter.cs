using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NNNES.Emulator.Core.Tests.Emulator.InstructionsTestCase;
using static NNNES.Emulator.Core.Tests.Emulator.InstructionsTestCase.State;

namespace NNNES.Emulator.Core.Tests.Emulator.Converters
{
    public class CycleConverter : JsonConverter<Cycle>
    {
        public override Cycle ReadJson(
            JsonReader reader,
            Type objectType,
            Cycle existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var array = JArray.Load(reader);

            if (array.Count != 3)
                throw new JsonSerializationException(
                    $"Expected a three-element array for {nameof(Cycle)}.");

            return new Cycle
            {
                Address = array[0].ToObject<ushort>(),
                Value = array[1].ToObject<byte>(),
                Type = array[2].ToObject<string>()
            };
        }

        public override void WriteJson(
            JsonWriter writer,
            Cycle value,
            JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.Address);
            writer.WriteValue(value.Value);
            writer.WriteValue(value.Type);
            writer.WriteEndArray();
        }
    }
}
