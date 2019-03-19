using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biyoenformatik
{
    class Translator
    {
        private class startLength
        {
            public int start, length;
        }
        public string acDNA2cDNA(string acDna)
        {
            acDna = acDna.ToLower();
            char[] acDna_Array = acDna.ToCharArray();
            for (int i = 0; i < acDna_Array.Length; i++)
            {
                if (acDna_Array[i] == 'a') acDna_Array[i] = 't';
                else if (acDna_Array[i] == 't') acDna_Array[i] = 'a';
                else if (acDna_Array[i] == 'c') acDna_Array[i] = 'g';
                else if (acDna_Array[i] == 'g') acDna_Array[i] = 'c';
            }
            return new string(acDna_Array);
        }
        public string cDNA2mRNA(string cDna)
        {
            cDna = cDna.ToLower();
            char[] cDna_Array = cDna.ToCharArray();
            for (int i = 0; i < cDna_Array.Length; i++)
            {
                if (cDna_Array[i] == 't') cDna_Array[i] = 'u';
            }
            return new string(cDna_Array);
        }
        public string mRNA2AA(string mRna)
        {
            mRna.ToLower();
            char[] mRna_Array = mRna.ToCharArray();
            string kodon = "";
            string AA = "";
            for (int i = 0; i < mRna_Array.Length; i = i + 3)
            {
                kodon = "";
                for (int j = i; j < mRna_Array.Length && j < i + 3; j++)
                {
                    kodon += mRna_Array[j].ToString();
                }
                AA += geneticCode(kodon);
            }
            return AA;
        }
        public List<string> mRNA2PROTEIN(string mRna, RichTextBox rTB)
        {
            List<startLength> proteinsForColor = new List<startLength>();
            List<string> proteinsForAASeq = new List<string>();
            startLength protein;
            mRna.ToLower();
            char[] mRna_Array = mRna.ToCharArray();
            string kodon = "";
            string AASeq = "";
            int sayac = 0;

            for (int i = 0; i <= mRna_Array.Length - 2; i++)
            {
                if (mRna_Array[i] == 'a' && mRna_Array[i + 1] == 'u' && mRna_Array[i + 2] == 'g')
                {
                    protein = new startLength();
                    protein.start = i;
                    AASeq = "M";
                    sayac = 1;

                    for (int j = i + 3; j < mRna_Array.Length; j = j + 3)
                    {
                        kodon = "";
                        for (int k = 0; k < 3; k++)
                        {
                            if (j + k < mRna_Array.Length)
                            {
                                kodon += mRna_Array[j + k].ToString();
                            }
                        }

                        kodon = geneticCode(kodon);
                        if (kodon == "*")
                        {
                            AASeq += "*";
                            i = j + 3;
                            sayac++;
                            protein.length = sayac;
                            proteinsForColor.Add(protein);
                            proteinsForAASeq.Add(AASeq);
                            break;
                        }
                        else
                        {
                            AASeq += kodon;
                            sayac++;
                        }
                    }
                }

            }
            foreach (var x in proteinsForColor)
            {
                AppendText(rTB, Color.Red, x);
            }
            return proteinsForAASeq;
        }
        private string geneticCode(string kodon)
        {
            switch (kodon)
            {
                case "uuu":
                case "uuc":
                    return "F";
                case "uua":
                case "uug":
                case "cuu":
                case "cuc":
                case "cua":
                case "cug":
                    return "L";
                case "auu":
                case "auc":
                case "aua":
                    return "I";
                case "aug":
                    return "M";
                case "guu":
                case "guc":
                case "gua":
                case "gug":
                    return "V";
                case "ucu":
                case "ucc":
                case "uca":
                case "ucg":
                case "agu":
                case "agc":
                    return "S";
                case "ccu":
                case "ccc":
                case "cca":
                case "ccg":
                    return "P";
                case "acu":
                case "acc":
                case "aca":
                case "acg":
                    return "T";
                case "gcu":
                case "gcc":
                case "gca":
                case "gcg":
                    return "A";
                case "uau":
                case "uac":
                    return "Y";
                case "cau":
                case "cac":
                    return "H";
                case "caa":
                case "cag":
                    return "Q";
                case "aau":
                case "aac":
                    return "N";
                case "aaa":
                case "aag":
                    return "K";
                case "gau":
                case "gac":
                    return "D";
                case "gaa":
                case "gag":
                    return "E";
                case "ugu":
                case "ugc":
                    return "C";
                case "ugg":
                    return "W";
                case "cgu":
                case "cgc":
                case "cga":
                case "cgg":
                case "aga":
                case "agg":
                    return "R";
                case "ggu":
                case "ggc":
                case "gga":
                case "ggg":
                    return "G";
                case "uaa":
                case "uag":
                case "uga":
                    return "*";
                default:
                    return "X";
            }
        }
        private string reverseGeneticCode(string AA)
        {
            switch (AA)
            {
                case "F":
                    return "ttc";
                case "L":
                    return "ctg";
                case "I":
                    return "atc";
                case "M":
                    return "atg";
                case "V":
                    return "gtg";
                case "S":
                    return "agc";
                case "P":
                    return "ccc";
                case "T":
                    return "acc";
                case "A":
                    return "gcc";
                case "Y":
                    return "tac";
                case "H":
                    return "cac";
                case "Q":
                    return "cag";
                case "N":
                    return "aac";
                case "K":
                    return "aag";
                case "D":
                    return "gac";
                case "E":
                    return "gag";
                case "C":
                    return "tgc";
                case "W":
                    return "tgg";
                case "R":
                    return "agg";
                case "G":
                    return "ggc";
                case "*":
                    return "tga";
                default:
                    return "nnn";

            }
        }
        public string AA2cDNA(string AA)
        {
            AA = AA.ToUpper();
            char[] AA_Array = AA.ToCharArray();
            string cDna = "";
            for (int i = 0; i < AA_Array.Length; i++)
            {
                cDna += reverseGeneticCode(AA_Array[i].ToString());
            }
            return cDna;
        }
        private void AppendText(RichTextBox box, Color color, startLength sl)
        {
            int start = sl.start;

            // Textbox may transform chars, so (end-start) != text.Length

            box.Select(start, sl.length * 3);
            {


                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }
        public string textEdit(string text)
        {
            return text.Replace(" ", string.Empty).Replace("\n", string.Empty);         
        }
    }
}
