namespace NNNES.Emulator.Forms.Disassembler
{
    public struct Instruction
    {
        public ushort Address { get; set; }

        public byte Opcode { get; set; }

        public string Mnemonic { get; set; }

        public string [] Arguments { get; set; }
    }
}