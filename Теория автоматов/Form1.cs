using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static State St = State.S1;
        static ConstState constSt = ConstState.S;
        static ProcedureState procSt = ProcedureState.S;
        static ParamsState paramSt = ParamsState.S;
        static ReturnState returnSt = ReturnState.S;
        static BinState binSt = BinState.S;
        static FloatState floatSt = FloatState.S;
        static CharacterState charSt = CharacterState.S;
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label2.Text = "Цепочка принадлежит языку";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            string str = textBox1.Text.ToLower();
            char ch;
            List<string> VarList = new List<string>();
            List<string> ConstList = new List<string>();
            St = State.S1;
            constSt = ConstState.S;
            procSt = ProcedureState.S;
            paramSt = ParamsState.S;
            returnSt = ReturnState.S;
            binSt = BinState.S;
            floatSt = FloatState.S;
            charSt = CharacterState.S;
            int i = 0;
            int c = 0;
            StringBuilder constBuffer = new StringBuilder(8);
            StringBuilder varBuffer = new StringBuilder(8, 8);
            try
            { 
                while (i < str.Length && St != State.E && St != State.F)
                {
                    ch = str[i++];
                    switch (St)
                    {
                        case State.S1:
                            if (ch == ' ') break;
                            if (char.IsLetter(ch)) { St = State.VAR; varBuffer.Append(ch); }
                            else { St = State.E; label2.Text = "Ошибка, ожидался идентификатор"; }
                            break;
                        case State.VAR:
                            if ((char.IsLetter(ch)) || (char.IsNumber(ch))) { varBuffer.Append(ch); break; }
                            if (ch == ' ') 
                            { 
                                St = State.EQ;
                                if (!VarList.Contains(varBuffer.ToString()))
                                {
                                    VarList.Add(varBuffer.ToString());
                                    varBuffer = new StringBuilder(8, 8);
                                }
                                else { St = State.E; label2.Text = "Ошибка, повторяющиеся имена параметров недопустимы"; }
                                break;
                            }
                            if (ch == ':') 
                            { 
                                St = State.S1n;
                                if (!VarList.Contains(varBuffer.ToString()))
                                {
                                    VarList.Add(varBuffer.ToString());
                                    varBuffer = new StringBuilder(8, 8);
                                }
                                else { St = State.E; label2.Text = "Ошибка, повторяющиеся имена параметров недопустимы"; }
                            }
                            else { St = State.E; label2.Text = "Ошибка, ожидалось :"; }
                            break;
                        case State.EQ:
                            if (ch == ' ') break;
                            if (ch == ':') { St = State.S1n; }
                            else { St = State.E; label2.Text = "Ошибка, ожидалось :"; }
                            break;
                        case State.S1n:
                            if (ch == ' ') break;
                            if (ch == 'p') { St = State.PROCEDURE; procSt = ProcedureState.P; }
                            else { St = State.E; label2.Text = "Ошибка, ожидалось proc/procedure"; }
                            break;
                        case State.PROCEDURE:
                            switch (procSt)
                            {
                                case ProcedureState.P:
                                    if (ch == 'r') procSt = ProcedureState.R1;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось proc/procedure"; }
                                    break;
                                case ProcedureState.R1:
                                    if (ch == 'o') procSt = ProcedureState.O;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось proc/procedure"; }
                                    break;
                                case ProcedureState.O:
                                    if (ch == 'c') procSt = ProcedureState.C;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось proc/procedure"; }
                                    break;
                                case ProcedureState.C:
                                    if (ch == ' ') { St = State.S2; procSt = ProcedureState.F; break; }
                                    if (ch == '(') { St = State.S3; procSt = ProcedureState.F; break; }
                                    if (ch == ';') { St = State.F; procSt = ProcedureState.F; break; }
                                    if (ch == 'e') procSt = ProcedureState.E1;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось procedure, список параметров или конец цепочки"; }
                                    break;
                                case ProcedureState.E1:
                                    if (ch == 'd') procSt = ProcedureState.D;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось procedure"; }
                                    break;
                                case ProcedureState.D:
                                    if (ch == 'u') procSt = ProcedureState.U;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось procedure"; }
                                    break;
                                case ProcedureState.U:
                                    if (ch == 'r') procSt = ProcedureState.R2;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось procedure"; }
                                    break;
                                case ProcedureState.R2:
                                    if (ch == 'e') procSt = ProcedureState.E2;
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидалось procedure"; }
                                    break;
                                case ProcedureState.E2:
                                    if (ch == ' ') { St = State.S2; procSt = ProcedureState.F; break; }
                                    if (ch == '(') { St = State.S3; procSt = ProcedureState.F; break; }
                                    if (ch == ';') { St = State.F; procSt = ProcedureState.F; }
                                    else { procSt = ProcedureState.E; St = State.E; label2.Text = "Ошибка, ожидался пробел, список параметров или конец цепочки"; }
                                    break;
                            }
                            break;
                        case State.S2:
                            if (ch == ' ') break;
                            if (ch == '(') { St = State.S3; break; }
                            if (ch == 'r') { St = State.RETURN; returnSt = ReturnState.R1; }
                            else { St = State.E; label2.Text = "Ошибка, ожидался returns или список параметров"; }
                            break;
                        case State.S3:
                            switch (paramSt)
                            {
                                case ParamsState.S:
                                    if (ch == ' ') break;
                                    if (char.IsLetter(ch)) { paramSt = ParamsState.VAR; varBuffer.Append(ch); }
                                    else { St = State.E; label2.Text = "Ошибка, ожидался идентификатор"; }
                                    break;
                                case ParamsState.VAR:
                                    if ((char.IsLetter(ch)) || (char.IsNumber(ch))) { varBuffer.Append(ch); break; }
                                    if (ch == ' ') 
                                    { 
                                        paramSt = ParamsState.F;
                                        if (!VarList.Contains(varBuffer.ToString()))
                                        {
                                            VarList.Add(varBuffer.ToString());
                                            varBuffer = new StringBuilder(8, 8);
                                        }
                                        else { paramSt = ParamsState.E; St = State.E; label2.Text = "Ошибка, повторяющиеся имена параметров недопустимы"; }
                                        break; 
                                    }
                                    if (ch == ',') 
                                    { 
                                        paramSt = ParamsState.S;
                                        if (!VarList.Contains(varBuffer.ToString()))
                                        {
                                            VarList.Add(varBuffer.ToString());
                                            varBuffer = new StringBuilder(8, 8);
                                        }
                                        else { paramSt = ParamsState.E; St = State.E; label2.Text = "Ошибка, повторяющиеся имена параметров недопустимы"; }
                                        break; 
                                    }
                                    if (ch == ')') 
                                    { 
                                        St = State.S3n;
                                        if (!VarList.Contains(varBuffer.ToString()))
                                        {
                                            VarList.Add(varBuffer.ToString());
                                            varBuffer = new StringBuilder(8, 8);
                                        }
                                        else { paramSt = ParamsState.E; St = State.E; label2.Text = "Ошибка, повторяющиеся имена параметров недопустимы"; }
                                    }
                                    else { St = State.E; label2.Text = "Ошибка, ожидался идентификатор, запятая или )"; }
                                    break;
                                case ParamsState.F:
                                    if (ch == ' ') break;
                                    if (ch == ',') { paramSt = ParamsState.S; break; }
                                    if (ch == ')') { St = State.S3n; }
                                    else { St = State.E; label2.Text = "Ошибка, ожидалась запятая или )"; }
                                    break;
                            }
                            break;
                        case State.S3n:
                            if (ch == ';') { St = State.F; break; }
                            if (ch == ' ') { St = State.S4; }
                            else { St = State.E; label2.Text = "Ошибка, ожидался конец цепочки или пробел"; }
                            break;
                        case State.S4:
                            if (ch == ' ') break;
                            if (ch == 'r') { St = State.RETURN; returnSt = ReturnState.R1; }
                            else { St = State.E; label2.Text = "Ошибка, ожидался returns"; }
                            break;
                        case State.RETURN:
                            switch (returnSt)
                            {
                                case ReturnState.R1:
                                    if (ch == 'e') returnSt = ReturnState.E1;
                                    else { returnSt = ReturnState.E; St = State.E; label2.Text = "Ошибка, ожидался returns"; }
                                    break;
                                case ReturnState.E1:
                                    if (ch == 't') returnSt = ReturnState.T;
                                    else { returnSt = ReturnState.E; St = State.E; label2.Text = "Ошибка, ожидался returns"; }
                                    break;
                                case ReturnState.T:
                                    if (ch == 'u') returnSt = ReturnState.U;
                                    else { returnSt = ReturnState.E; St = State.E; label2.Text = "Ошибка, ожидался returns"; }
                                    break;
                                case ReturnState.U:
                                    if (ch == 'r') returnSt = ReturnState.R2;
                                    else { returnSt = ReturnState.E; St = State.E; label2.Text = "Ошибка, ожидался returns"; }
                                    break;
                                case ReturnState.R2:
                                    if (ch == 'n') returnSt = ReturnState.N;
                                    else { returnSt = ReturnState.E; St = State.E; label2.Text = "Ошибка, ожидался returns"; }
                                    break;
                                case ReturnState.N:
                                    if (ch == 's') returnSt = ReturnState.S1;
                                    else { returnSt = ReturnState.E; St = State.E; label2.Text = "Ошибка, ожидался returns"; }
                                    break;
                                case ReturnState.S1:
                                    if (ch == ' ') break;
                                    if (ch == '(') { St = State.S5; returnSt = ReturnState.F; }
                                    else { returnSt = ReturnState.E; St = State.E; label2.Text = "Ошибка, ожидался пробел или ("; }
                                    break;
                            }
                            break;
                        case State.S5:
                            if (ch == ' ') break;
                            if (ch == 'b') { St = State.BIN; binSt = BinState.B; break; }
                            if (ch == 'f') { St = State.FLOAT; floatSt = FloatState.F1; break; }
                            if (ch == 'c') { St = State.CHARACTER; charSt = CharacterState.C1; }
                            else { St = State.E; label2.Text = "Ошибка, ожидался атрибут"; }
                            break;
                        case State.BIN:
                            switch (binSt)
                            {
                                case BinState.B:
                                    if (ch == 'i') binSt = BinState.I1;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось bin"; }
                                    break;
                                case BinState.I1:
                                    if (ch == 'n') binSt = BinState.N;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось bin"; }
                                    break;
                                case BinState.N:
                                    if (ch == ' ') binSt = BinState.F1;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось bin"; }
                                    break;
                                case BinState.F1:
                                    if (ch == ' ') break;
                                    if (ch == 'f') binSt = BinState.I2;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось fixed"; }
                                    break;
                                case BinState.I2:
                                    if (ch == 'i') binSt = BinState.X;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось fixed"; }
                                    break;
                                case BinState.X:
                                    if (ch == 'x') binSt = BinState.E1;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось fixed"; }
                                    break;
                                case BinState.E1:
                                    if (ch == 'e') binSt = BinState.D;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось fixed"; }
                                    break;
                                case BinState.D:
                                    if (ch == 'd') binSt = BinState.D1;
                                    else { binSt = BinState.E; St = State.E; label2.Text = "Ошибка, ожидалось fixed"; }
                                    break;
                                case BinState.D1:
                                    if (ch == ' ') break;
                                    if (ch == ')') { binSt = BinState.F; St = State.S6; }
                                    else { St = State.E; label2.Text = "Ошибка, ожидалось )"; }
                                    break;
                            }
                            break;
                        case State.FLOAT:
                            switch (floatSt)
                            {
                                case FloatState.F1:
                                    if (ch == 'l') floatSt = FloatState.L;
                                    else { floatSt = FloatState.E; St = State.E; label2.Text = "Ошибка, ожидалось float"; }
                                    break;
                                case FloatState.L:
                                    if (ch == 'o') floatSt = FloatState.O;
                                    else { floatSt = FloatState.E; St = State.E; label2.Text = "Ошибка, ожидалось float"; }
                                    break;
                                case FloatState.O:
                                    if (ch == 'a') floatSt = FloatState.A;
                                    else { floatSt = FloatState.E; St = State.E; label2.Text = "Ошибка, ожидалось float"; }
                                    break;
                                case FloatState.A:
                                    if (ch == 't') floatSt = FloatState.T;
                                    else { floatSt = FloatState.E; St = State.E; label2.Text = "Ошибка, ожидалось float"; }
                                    break;
                                case FloatState.T:
                                    if (ch == ' ') break;
                                    if (ch == ')') { floatSt = FloatState.F; St = State.S6; }
                                    else { floatSt = FloatState.E; St = State.E; label2.Text = "Ошибка, ожидалось )"; }
                                    break;
                            }
                            break;
                        case State.CHARACTER:
                            switch (charSt)
                            {
                                case CharacterState.C1:
                                    if (ch == 'h') charSt = CharacterState.H;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.H:
                                    if (ch == 'a') charSt = CharacterState.A1;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.A1:
                                    if (ch == 'r') charSt = CharacterState.R1;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.R1:
                                    if (ch == 'a') charSt = CharacterState.A2;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.A2:
                                    if (ch == 'c') charSt = CharacterState.C2;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.C2:
                                    if (ch == 't') charSt = CharacterState.T;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.T:
                                    if (ch == 'e') charSt = CharacterState.E1;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.E1:
                                    if (ch == 'r') charSt = CharacterState.R2;
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                                case CharacterState.R2:
                                    if (ch == ' ') break;
                                    if (ch == '(') { charSt = CharacterState.F; St = State.CONST; }
                                    else { charSt = CharacterState.E; St = State.E; label2.Text = "Ошибка, ожидалось character"; }
                                    break;
                            }
                            break;
                        case State.CONST:
                            if (ch == ' ') break;
                            constBuffer.Append(ch);
                            if (ch == '0') { St = State.E; label2.Text = "Ошибка, константа не может быть 0"; }
                            else if (char.IsNumber(ch)) St = State.CONST1;
                            else { St = State.E; label2.Text = "Ошибка, ожидалась константа"; }
                            break;
                        case State.CONST1:
                            if (char.IsNumber(ch))
                            {
                                constBuffer.Append(ch);
                                break;
                            }
                            else if (ch == ' ') { St = State.S6n; if (!ConstList.Contains(constBuffer.ToString())) ConstList.Add(constBuffer.ToString()); constBuffer = new StringBuilder(8); }
                            else if (ch == ')') { St = State.S6n1; if (!ConstList.Contains(constBuffer.ToString())) ConstList.Add(constBuffer.ToString()); constBuffer = new StringBuilder(8); }
                            else { St = State.E; label2.Text = "Ошибка, константа не определена"; }
                            break;
                        case State.S6n:
                            if (ch == ' ') break;
                            if (ch == ')') St = State.S6n1;
                            else { St = State.E; label2.Text = "Ошибка, ожидалось )"; }
                            break;
                        case State.S6n1:
                            if (ch == ' ') break;
                            if (ch == ')') St = State.S6;
                            else { St = State.E; label2.Text = "Ошибка, ожидалось )"; }
                            break;
                        case State.S6:
                            if (ch == ';') St = State.F;
                            else { St = State.E; label2.Text = "Ошибка, ожидался конец цепочки"; }
                            break;
                    }
                }
                if (constBuffer.Length != 0)
                {
                    ConstList.Add(constBuffer.ToString());
                    constBuffer = new StringBuilder(8);
                }
                if (varBuffer.Length != 0)
                {
                    VarList.Add(varBuffer.ToString());
                    varBuffer = new StringBuilder(8, 8);
                }
                foreach (string var in VarList)
                {
                    if(var == "proc" || var == "procedure" || var == "returns" || var == "float" || var == "character")
                    {
                        St = State.E;
                        label2.Text = "Ошибка, имя идентификатора не должно быть ключевым словом";
                        i = str.Length+1;
                    }
                }
                if (ConstList.Count != 0)
                {
                    if (Int32.TryParse(ConstList[0], out c))
                    {
                        if (c < 1 || c > 32768)
                        {
                            St = State.E;
                            label2.Text = "Ошибка, недопустимое значение константы";
                        }
                    }
                }
                if (St != State.E && str[str.Length-1] == ';')
                {
                    label2.Text = "Цепочка принадлежит языку";
                    textBox2.Text += VarList[0];
                    textBox2.Text += "\r\n";
                    textBox5.Text += "-";
                    textBox5.Text += "\r\n";
                    if (returnSt == ReturnState.F)
                    {
                        textBox4.Text += "Функция";
                        textBox4.Text += "\r\n";
                        if (binSt == BinState.F)
                        {
                            textBox6.Text += "BIN FIXED";
                            textBox6.Text += "\r\n";
                        }
                        else if (floatSt == FloatState.F)
                        {
                            textBox6.Text += "FLOAT";
                            textBox6.Text += "\r\n";
                        }
                        else
                        {
                            textBox6.Text += "CHARACTER";
                            textBox6.Text += "\r\n";
                            textBox3.Text += ConstList[0];
                            textBox3.Text += "\r\n";
                        }
                    }
                    else
                    {
                        textBox4.Text += "Процедура";
                        textBox4.Text += "\r\n";
                        textBox6.Text += "-";
                        textBox6.Text += "\r\n";
                    }
                    for (int j = 1; j < VarList.Count; j++)
                    {
                        textBox2.Text += VarList[j];
                        textBox2.Text += "\r\n";
                        textBox4.Text += "Параметр";
                        textBox4.Text += "\r\n";
                        textBox5.Text += j;
                        textBox5.Text += "\r\n";
                        textBox6.Text += "-";
                        textBox6.Text += "\r\n";
                    }
                }
                else if (St != State.E && str[str.Length-1] != ';')
                {
                    label2.Text = "Цепочка не принадлежит языку";
                    St = State.E; 
                }
                else
                {
                    if (i == 0)
                    {
                        textBox1.SelectionStart = i;
                        textBox1.SelectionLength = 0;
                        textBox1.Select();
                    }
                    else
                    {
                        textBox1.SelectionStart = i - 1;
                        textBox1.SelectionLength = 0;
                        textBox1.Select();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                textBox1.SelectionStart = i - 1;
                textBox1.SelectionLength = 0;
                textBox1.Select();
                label2.Text = "Ошибка, максимальная длина идентификатора - 8";
            }
            label2.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "Цепочка принадлежит языку";
            label2.Visible = false;
        }
    }
    enum State
    {
        S1, S1n, VAR,
        S2, EQ, CONST, CONST1, PROCEDURE,
        S3, S3n, S4, S5, S6, S6n, S6n1, RETURN, BIN, FLOAT, CHARACTER, F, E
    }
    enum ConstState
    {
        S, SIGN, ZERO, NUM, DOT, FRACT, F, E
    }
    enum ProcedureState
    {
        S, P, R1, O, C, E1, D, U, R2, E2, F, E
    }
    enum ReturnState
    {
        S, R1, E1, T, U, R2, N, S1, F, E
    }
    enum BinState
    {
        S, B, I1, N, F1, I2, X, E1, D, D1, F, E
    }
    enum FloatState
    {
        S, F1, L, O, A, T, F, E
    }
    enum CharacterState
    {
        S, C1, H, A1, R1, A2, C2, T, E1, R2, F, E
    }
    enum ParamsState
    {
        S, S1, VAR, F, E
    }
}
