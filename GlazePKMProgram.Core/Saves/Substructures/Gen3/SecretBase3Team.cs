using System;

namespace GlazePKMProgram.Core
{
    public sealed class SecretBase3Team
    {
        private const int O_PID = 0;
        private const int O_Moves = 0x18;
        private const int O_Species = 0x24;
        private const int O_Item = 0x30;
        private const int O_Level = 0x3C;
        private const int O_EV = 0x42;

        private static int GetOffsetPID(int index) => O_PID + (index * 4);
        private static int GetOffsetMove(int index, int move) => O_Moves + (index * 8) + (move * 2);
        private static int GetOffsetSpecies(int index) => O_Species + (index * 2);
        private static int GetOffsetItem(int index) => O_Item + (index * 2);

        public readonly SecretBase3PKM[] Team;
        private readonly byte[] Data;

        public SecretBase3Team(byte[] data)
        {
            Team = new SecretBase3PKM[6];
            for (int i = 0; i < Team.Length; i++)
                Team[i] = GetPKM(i);
            Data = data;
        }

        public byte[] Write()
        {
            for (int i = 0; i < Team.Length; i++)
                SetPKM(i);
            return Data;
        }

        private SecretBase3PKM GetPKM(int index)
        {
            return new()
            {
                PID = BitConverter.ToUInt32(Data, GetOffsetPID(index)),
                Species = BitConverter.ToUInt16(Data, GetOffsetSpecies(index)),
                HeldItem = BitConverter.ToUInt16(Data, GetOffsetItem(index)),
                Move1 = BitConverter.ToUInt16(Data, GetOffsetMove(index, 0)),
                Move2 = BitConverter.ToUInt16(Data, GetOffsetMove(index, 1)),
                Move3 = BitConverter.ToUInt16(Data, GetOffsetMove(index, 2)),
                Move4 = BitConverter.ToUInt16(Data, GetOffsetMove(index, 3)),
                Level = Data[O_Level + index],
                EVAll = Data[O_EV + index],
            };
        }

        private void SetPKM(int index)
        {
            var pk = Team[index];
            BitConverter.GetBytes(pk.PID).CopyTo(Data, GetOffsetPID(index));
            BitConverter.GetBytes((ushort)pk.Species).CopyTo(Data, GetOffsetSpecies(index));
            BitConverter.GetBytes((ushort)pk.HeldItem).CopyTo(Data, GetOffsetItem(index));
            BitConverter.GetBytes((ushort)pk.Move1).CopyTo(Data, GetOffsetMove(index, 0));
            BitConverter.GetBytes((ushort)pk.Move2).CopyTo(Data, GetOffsetMove(index, 1));
            BitConverter.GetBytes((ushort)pk.Move3).CopyTo(Data, GetOffsetMove(index, 2));
            BitConverter.GetBytes((ushort)pk.Move4).CopyTo(Data, GetOffsetMove(index, 3));
            Data[O_Level + index] = (byte)pk.Level;
            Data[O_EV + index] = (byte)pk.EVAll;
        }
    }
}