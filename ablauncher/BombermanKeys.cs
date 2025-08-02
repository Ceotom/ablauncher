using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ablauncher {

    /**
     * Bomberman keys are a bitch; they don't follow scancode conventions.
     * 
     * So we define a separate class in a separate file.
     */
    class BombermanKeys {
        private Dictionary<int,Keys> keyMap = new Dictionary<int,Keys>();
        private Dictionary<Keys,int> scanToBm = new Dictionary<Keys,int>();

        public BombermanKeys() {
            define();
            buildReverseMap();
        }

        private void buildReverseMap() {
            foreach (KeyValuePair<int,Keys> item in keyMap) scanToBm[item.Value] = item.Key;
        }

        public Keys BmToWindows(int code) {
            if (keyMap.ContainsKey(code)) return keyMap[code];
            return Keys.None;
        }

        public int WindowsToBm(Keys key) {
            if (scanToBm.ContainsKey(key)) return scanToBm[key];
            return 0;
        }

        private void define() {
            keyMap[ 0] = Keys.None;
            keyMap[ 1] = Keys.Escape;

            keyMap[ 2] = Keys.D1;
            keyMap[ 3] = Keys.D2;
            keyMap[ 4] = Keys.D3;
            keyMap[ 5] = Keys.D4;
            keyMap[ 6] = Keys.D5;
            keyMap[ 7] = Keys.D6;
            keyMap[ 8] = Keys.D7;
            keyMap[ 9] = Keys.D8;
            keyMap[10] = Keys.D9;
            keyMap[11] = Keys.D0;

            keyMap[12] = Keys.OemMinus;
            keyMap[13] = Keys.Oemplus;
            keyMap[14] = Keys.Back;
            keyMap[15] = Keys.Tab;

            keyMap[16] = Keys.Q;
            keyMap[17] = Keys.W;
            keyMap[18] = Keys.E;
            keyMap[19] = Keys.R;
            keyMap[20] = Keys.T;
            keyMap[21] = Keys.Y;
            keyMap[22] = Keys.U;
            keyMap[23] = Keys.I;
            keyMap[24] = Keys.O;
            keyMap[25] = Keys.P;

            keyMap[26] = Keys.OemOpenBrackets;
            keyMap[27] = Keys.OemCloseBrackets;
            keyMap[28] = Keys.Return;
            keyMap[29] = Keys.LControlKey;

            keyMap[30] = Keys.A;
            keyMap[31] = Keys.S;
            keyMap[32] = Keys.D;
            keyMap[33] = Keys.F;
            keyMap[34] = Keys.G;
            keyMap[35] = Keys.H;
            keyMap[36] = Keys.J;
            keyMap[37] = Keys.K;
            keyMap[38] = Keys.L;

            keyMap[39] = Keys.OemSemicolon;
            keyMap[40] = Keys.OemQuotes;
            keyMap[41] = Keys.Oemtilde;
            keyMap[42] = Keys.LShiftKey;
            keyMap[43] = Keys.OemBackslash;

            keyMap[44] = Keys.Z;
            keyMap[45] = Keys.X;
            keyMap[46] = Keys.C;
            keyMap[47] = Keys.V;
            keyMap[48] = Keys.B;
            keyMap[49] = Keys.N;
            keyMap[50] = Keys.M;

            keyMap[51] = Keys.Oemcomma;
            keyMap[52] = Keys.OemPeriod;
            keyMap[53] = Keys.OemQuestion;
            keyMap[54] = Keys.RShiftKey;

            keyMap[55] = Keys.Multiply;

            keyMap[56] = Keys.LMenu;
            keyMap[57] = Keys.Space;
            keyMap[58] = Keys.CapsLock;
            keyMap[59] = Keys.F1;
            keyMap[60] = Keys.F2;
            keyMap[61] = Keys.F3;
            keyMap[62] = Keys.F4;
            keyMap[63] = Keys.F5;
            keyMap[64] = Keys.F6;
            keyMap[65] = Keys.F7;
            keyMap[66] = Keys.F8;
            keyMap[67] = Keys.F9;
            keyMap[68] = Keys.F10;

            keyMap[69] = Keys.NumLock;
            keyMap[71] = Keys.NumPad7;
            keyMap[72] = Keys.NumPad8;
            keyMap[73] = Keys.NumPad9;
            keyMap[74] = Keys.Subtract;
            keyMap[75] = Keys.NumPad4;
            keyMap[76] = Keys.NumPad5;
            keyMap[77] = Keys.NumPad6;
            keyMap[78] = Keys.Add;
            keyMap[79] = Keys.NumPad1;
            keyMap[80] = Keys.NumPad2;
            keyMap[81] = Keys.NumPad3;
            keyMap[82] = Keys.NumPad0;
            keyMap[83] = Keys.Decimal;

            keyMap[87] = Keys.F11;
            keyMap[88] = Keys.F12;

            //keyMap[156] = Keys.Enter; // Windows doesn't distinguish between enter and return, and return is the more likely candidate
            keyMap[157] = Keys.RControlKey;
            keyMap[181] = Keys.Divide;
            keyMap[184] = Keys.RMenu;

            keyMap[199] = Keys.Home;
            keyMap[200] = Keys.Up;
            keyMap[201] = Keys.PageUp;
            keyMap[203] = Keys.Left;
            keyMap[205] = Keys.Right;
            keyMap[207] = Keys.End;
            keyMap[208] = Keys.Down;
            keyMap[209] = Keys.PageDown;
            keyMap[210] = Keys.Insert;
            keyMap[211] = Keys.Delete;
        }
    }
}
