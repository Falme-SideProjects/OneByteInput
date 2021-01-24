using System;
using System.Collections.Generic;
using System.Text;

namespace OneByteInput
{
    enum Keys
    {
        up      =   1,
        right   =   2,
        down    =   4,
        left    =   8,
        select  =   16,
        start   =   32,
        a       =   64,
        b       =   128
    }

    class InputController
    {
        private byte controls = 0;

        public InputController()
        {
            while(true)
            {
                InsertChar(Console.ReadKey().KeyChar);
                StringifyBinary();
            }
        }

        private void InsertChar(char letter)
        {
            switch(letter)
            {
                case 'w': ChangeControl((byte)Keys.up); break;
                case 'd': ChangeControl((byte)Keys.right); break;
                case 's': ChangeControl((byte)Keys.down); break;
                case 'a': ChangeControl((byte)Keys.left); break;
                case 'g': ChangeControl((byte)Keys.select); break;
                case 'h': ChangeControl((byte)Keys.start); break;
                case 'j': ChangeControl((byte)Keys.a); break;
                case 'k': ChangeControl((byte)Keys.b); break;
            }
        }

        private void ChangeControl(byte direction)
        {
            if( (controls & direction) == 0)
                controls = (byte)(controls | direction);
            else
                controls = (byte)(controls ^ direction);
        }

        private void StringifyBinary()
        {
            byte _val = (byte.MaxValue + 1) / 2;

            StringBuilder _result = new StringBuilder();
            while(_val>=1)
            {
                if ((_val & this.controls) != 0) _result.Append("1");
                else _result.Append("0");

                _val /= 2;
            }
            Console.WriteLine(_result.ToString());
        }
    }
}
