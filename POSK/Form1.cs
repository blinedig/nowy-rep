﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POSK
{
    public partial class Form1 : Form
    {
        byte ah = 0, al = 0, bh = 0, bl = 0, ch = 0, cl = 0, dh = 0, dl = 0;
        int n = 0;
        //int m = 0;
        int b=0;
        bool mov, add, sub, push, pop,int33, int34, int20, int21;
        string text, zmien;
        const int S = 1024;
        public int wskaznik = S - 1; //wskaznik stosu
        public int[] tablicaS;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        int SP; //do zapisywania na stos
        int POOP; //pomocnik do popa
        string verify = "";



        public Form1()
        {
            InitializeComponent();

            adres.Enabled = false;
            wartosc.Enabled = false;
            rejestr.Enabled = false;
            adresowanie.Enabled = false;
            button1.Enabled = false;
            PMNZST.Enabled = false;
            AH.Enabled = false;
            AL.Enabled = false;
            BH.Enabled = false;
            BL.Enabled = false;
            CH.Enabled = false;
            CL.Enabled = false;
            DH.Enabled = false;
            DL.Enabled = false;
            tablicaS = new int[S];
        }

        private void wartosc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;
        }
        public void stos_TextChanged(object sender, EventArgs e)
        { 
            stos.Text = wskaznik.ToString();
        }

        private void rozkaz_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rozkaz.SelectedIndex == 0)
            {
                textBox2.Text = textBox2.Text + "MOV ";
                PMNZST.Text = PMNZST.Text + "MOV ";
            }
            if (rozkaz.SelectedIndex == 1)
            {
                textBox2.Text = textBox2.Text + "ADD ";
                PMNZST.Text = PMNZST.Text + "ADD ";
            }
            if (rozkaz.SelectedIndex == 2)
            {
                textBox2.Text = textBox2.Text + "SUB ";
                PMNZST.Text = PMNZST.Text + "SUB ";
            }
            if (rozkaz.SelectedIndex == 3)
            {
                textBox2.Text = textBox2.Text + "PUSH ";
                PMNZST.Text = PMNZST.Text + "PUSH ";
            }
            if (rozkaz.SelectedIndex == 4)
            {
                textBox2.Text = textBox2.Text + "POP ";
                PMNZST.Text = PMNZST.Text + "POP ";
            }
            rejestr.Enabled = true;
            rozkaz.Enabled = false;
            button4.Enabled = true;
            if (rozkaz.SelectedIndex == 5)
            {
                textBox2.Text = textBox2.Text + "INT33";
                PMNZST.Text = PMNZST.Text + "INT33";
                button4.Enabled = false;
                rejestr.Enabled = false;
            }
            if (rozkaz.SelectedIndex == 6)
            {
                textBox2.Text = textBox2.Text + "INT34";
                PMNZST.Text = PMNZST.Text + "INT34";
                button4.Enabled = false;
                rejestr.Enabled = false;
            }
            if (rozkaz.SelectedIndex == 7)
            {
                textBox2.Text = textBox2.Text + "INT20";
                PMNZST.Text = PMNZST.Text + "INT20";
                button4.Enabled = false;
                rejestr.Enabled = false;

            }
            if (rozkaz.SelectedIndex == 8)
            {
                textBox2.Text = textBox2.Text + "INT21";
                PMNZST.Text = PMNZST.Text + "INT21";
                button4.Enabled = false;
                rejestr.Enabled = false;

            }

        }

        private void rejestr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rozkaz.SelectedIndex == 3 | rozkaz.SelectedIndex == 4)  // jeszcze nie działa jak powinno
            {
                
                
                if (rejestr.SelectedIndex == 0)
                {
                    textBox2.Text = textBox2.Text + "AH " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "AH " + "\r\n";
                }
                if (rejestr.SelectedIndex == 1)
                {
                    textBox2.Text = textBox2.Text + "AL " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "AL " + "\r\n";
                }
                if (rejestr.SelectedIndex == 2)
                {
                    textBox2.Text = textBox2.Text + "BH " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "BH " + "\r\n";
                }
                if (rejestr.SelectedIndex == 3)
                {
                    textBox2.Text = textBox2.Text + "BL " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "BL " + "\r\n";
                }
                if (rejestr.SelectedIndex == 4)
                {
                    textBox2.Text = textBox2.Text + "CH " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "CH " + "\r\n";
                }
                if (rejestr.SelectedIndex == 5)
                {
                    textBox2.Text = textBox2.Text + "CL " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "CL " + "\r\n";
                }
                if (rejestr.SelectedIndex == 6)
                {
                    textBox2.Text = textBox2.Text + "DH " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "DH " + "\r\n";
                }
                if (rejestr.SelectedIndex == 7)
                {
                    textBox2.Text = textBox2.Text + "DL " + "\r\n";
                    PMNZST.Text = PMNZST.Text + "DL " + "\r\n";
                }
                rozkaz.Enabled = true;
            }
            else
            {
                if (rejestr.SelectedIndex == 0)
                {
                    textBox2.Text = textBox2.Text + "AH ";
                    PMNZST.Text = PMNZST.Text + "AH ";
                }
                if (rejestr.SelectedIndex == 1)
                {
                    textBox2.Text = textBox2.Text + "AL ";
                    PMNZST.Text = PMNZST.Text + "AL ";
                }
                if (rejestr.SelectedIndex == 2)
                {
                    textBox2.Text = textBox2.Text + "BH ";
                    PMNZST.Text = PMNZST.Text + "BH ";
                }
                if (rejestr.SelectedIndex == 3)
                {
                    textBox2.Text = textBox2.Text + "BL ";
                    PMNZST.Text = PMNZST.Text + "BL ";
                }
                if (rejestr.SelectedIndex == 4)
                {
                    textBox2.Text = textBox2.Text + "CH ";
                    PMNZST.Text = PMNZST.Text + "CH ";
                }
                if (rejestr.SelectedIndex == 5)
                {
                    textBox2.Text = textBox2.Text + "CL ";
                    PMNZST.Text = PMNZST.Text + "CL ";
                }
                if (rejestr.SelectedIndex == 6)
                {
                    textBox2.Text = textBox2.Text + "DH ";
                    PMNZST.Text = PMNZST.Text + "DH ";
                }
                if (rejestr.SelectedIndex == 7)
                {
                    textBox2.Text = textBox2.Text + "DL ";
                    PMNZST.Text = PMNZST.Text + "DL ";
                }
                adresowanie.Enabled = true;
                rejestr.Enabled = false;
            }
            //rozkaz.Enabled = f;
        }

        private void adresowanie_SelectedIndexChanged(object sender, EventArgs e)
        {

                if (adresowanie.SelectedIndex == 0)
                {
                    adres.Enabled = true;
                    wartosc.Enabled = false;
                }
                if (adresowanie.SelectedIndex == 1)
                {
                    adres.Enabled = false;
                    wartosc.Enabled = true;
                    button1.Enabled = true;
                }
                adresowanie.Enabled = false;
            
        }

        private void adres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adres.SelectedIndex == 0)
            {
                textBox2.Text = textBox2.Text + "AH" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(ah) + "\r\n";
            }
            if (adres.SelectedIndex == 1)
            {
                textBox2.Text = textBox2.Text + "AL" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(al) + "\r\n";
            }
            if (adres.SelectedIndex == 2)
            {
                textBox2.Text = textBox2.Text + "BH" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(bh) + "\r\n";
            }
            if (adres.SelectedIndex == 3)
            {
                textBox2.Text = textBox2.Text + "BL" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(bl) + "\r\n";
            }
            if (adres.SelectedIndex == 4)
            {
                textBox2.Text = textBox2.Text + "CH" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(ch) + "\r\n";
            }
            if (adres.SelectedIndex == 5)
            {
                textBox2.Text = textBox2.Text + "CL" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(cl) + "\r\n";
            }
            if (adres.SelectedIndex == 6)
            {
                textBox2.Text = textBox2.Text + "DH" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(dh) + "\r\n";
            }
            if (adres.SelectedIndex == 7)
            {
                textBox2.Text = textBox2.Text + "DL" + "\r\n";
                PMNZST.Text = PMNZST.Text + Convert.ToString(dl) + "\r\n";
            }
            adres.Enabled = false;
            rozkaz.Enabled = true;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(wartosc.Text) >= 0 && Convert.ToInt32(wartosc.Text) <= 255)
            {
                textBox2.Text = textBox2.Text + wartosc.Text + "\r\n";
                PMNZST.Text = PMNZST.Text + wartosc.Text + "\r\n";
            }
        
                else
                {
                    textBox2.Text = textBox2.Text + "0\r\n";
                    PMNZST.Text = PMNZST.Text + "0\r\n";
                }
            
            button1.Enabled = false;
            wartosc.Enabled = false;
            rozkaz.Enabled = true;
            wartosc.Clear();
        }

       /* private int konwert(string konwerter)
        {
            if (konwerter == " AH" || konwerter == "AH")
            {
                return ah;
            }
            else if (konwerter == " AL" || konwerter == "AL")
            {
                return al;
            }
            else if (konwerter == " BH" || konwerter == "BH")
            {
                return bh;
            }
            else if (konwerter == " BL" || konwerter == "BL")
            {
                return bl;
            }
            else if (konwerter == " CH" || konwerter == "CH")
            {
                return ch;
            }
            else if (konwerter == " CL" || konwerter == "CL")
            {
                return cl ;
            }
            else if (konwerter == " DH" || konwerter == "DH")
            {
                return dh;
            }
            else if (konwerter == " DL" || konwerter == "DL")
            {
                return dl;
            }
            return Convert.ToByte(konwerter);
        }*/

        private void praca_Click(object sender, EventArgs e)
        {
            
            button4.Enabled = false;
            for (n = 0; n <= textBox2.Lines.Length; n++)
            {
                if ((textBox2.Lines.Length > 0 && n < textBox2.Lines.Length))
                {
                    mov = textBox2.Lines[n].Contains("MOV");
                    add = textBox2.Lines[n].Contains("ADD");
                    sub = textBox2.Lines[n].Contains("SUB");
                    push = textBox2.Lines[n].Contains("PUSH");
                    pop = textBox2.Lines[n].Contains("POP");
                    int33 = textBox2.Lines[n].Contains("INT33");
                    int34 = textBox2.Lines[n].Contains("INT34");
                    int20 = textBox2.Lines[n].Contains("INT20");
                    int21 = textBox2.Lines[n].Contains("INT21");


                    if (mov)
                    {
                        text = textBox2.Lines[n].Substring(4, 2);
                        zmien = PMNZST.Lines[n].Substring(7);

                        if (text == "AH")
                        {
                            ah = Convert.ToByte(zmien);
                        }
                        if (text == "AL")
                        {
                            al = Convert.ToByte(zmien);
                        }
                        if (text == "BH")
                        {
                            bh = Convert.ToByte(zmien);
                        }
                        if (text == "BL")
                        {
                            bl = Convert.ToByte(zmien);
                        }
                        if (text == "CH")
                        {
                            ch = Convert.ToByte(zmien);
                        }
                        if (text == "CL")
                        {
                            cl = Convert.ToByte(zmien);
                        }
                        if (text == "DH")
                        {
                            dh = Convert.ToByte(zmien);
                        }
                        if (text == "DL")
                        {
                            dl = Convert.ToByte(zmien);
                        }
                   }
                    if (add)
                {
                    
                    text = textBox2.Lines[n].Substring(4, 2);
                    zmien = PMNZST.Lines[n].Substring(7);

                    if (text == "AH")
                    {
                        ah += Convert.ToByte(zmien);
                    }

                    if (text == "AL")
                    {
                        al += Convert.ToByte(zmien);
                    }
                    if (text == "BH")
                    { 
                       bh += Convert.ToByte(zmien);
                    }
                    if (text == "BL")
                    {
                        bl += Convert.ToByte(zmien);
                    }
                    if (text == "CH")
                    {
                        ch += Convert.ToByte(zmien);
                    }
                    if (text == "CL")
                    {
                        cl += Convert.ToByte(zmien);
                    }
                    if (text == "DH")
                    {
                        dh += Convert.ToByte(zmien);
                    }
                    if (text == "DL")
                    {
                        dl += Convert.ToByte(zmien);
                    }


                }
                    if (sub)
                {
                    text = textBox2.Lines[n].Substring(4, 2);
                    zmien = PMNZST.Lines[n].Substring(7);

                    if (text == "AH")
                    {
                        ah -= Convert.ToByte(zmien);
                 
                    }
                    if (text == "AL")
                    {
                        al -= Convert.ToByte(zmien);
                    }
                    if (text == "BH")
                    {
                        bh -= Convert.ToByte(zmien);
                    }
                    if (text == "BL")
                    {
                        bl -= Convert.ToByte(zmien);
                    }
                    if (text == "CH")
                    {
                        ch -= Convert.ToByte(zmien);
                    }
                    if (text == "CL")
                    {
                        cl -= Convert.ToByte(zmien);
                    }
                    if (text == "DH")
                    {
                        dh -= Convert.ToByte(zmien);
                    }
                    if (text == "DL")
                    {
                        dl -= Convert.ToByte(zmien);
                    }
                }

                    if (push)
                    {
                        text = textBox2.Lines[n].Substring(4, 2);
                        
                        if (text == "AH")
                        {
                            SP = int.Parse(AH.Text); //to podobno zmienia stringa którym są rejestry w inta którym jest sp
                        }
                        if (text == "AL")
                        {
                            SP = int.Parse(AL.Text);
                        }
                        if (text == "BH")
                        {
                            SP = int.Parse(BH.Text);
                        }
                        if (text == "BL")
                        {
                            SP = int.Parse(BL.Text);
                        }
                        if (text == "CH")
                        {
                            SP = int.Parse(CH.Text);
                        }
                        if (text == "CL")
                        {
                            SP = int.Parse(CL.Text);
                        }
                        if (text == "DH")
                        {
                            SP = int.Parse(DH.Text);
                        }
                        if (text == "DL")
                        {
                            SP = int.Parse(DL.Text);
                        }
                        tablicaS[wskaznik] = SP; //powinno wpisac wartosc sp na stos
                        wskaznik--;
                    }
                    if (pop)
                    {
                        text = textBox2.Lines[n].Substring(4, 2);
                       
                       
                            if (text == "AH")
                            {
                                POOP = int.Parse(AH.Text); //to podobno zmienia stringa którym są rejestry w inta którym jest sp
                            }
                            if (text == "AL")
                            {
                                POOP = int.Parse(AL.Text);
                            }
                            if (text == "BH")
                            {
                                POOP = int.Parse(BH.Text);
                            }
                            if (text == "BL")
                            {
                                POOP = int.Parse(BL.Text);
                            }
                            if (text == "CH")
                            {
                                POOP = int.Parse(CH.Text);
                            }
                            if (text == "CL")
                            {
                                POOP = int.Parse(CL.Text);
                            }
                            if (text == "DH")
                            {
                                POOP = int.Parse(DH.Text);
                            }
                            if (text == "DL")
                            {
                                POOP = int.Parse(DL.Text);
                            }
                           
                            // tablicaS[wskaznik] = POOP; //powinno wpisac wartosc sp na stos
                            wskaznik++;
                        if (wskaznik > 1023)
                        {
                            MessageBox.Show("Alarma! Przekroczyłeś wartość stosu! Wykonaj inną funkcję!");
                        }

                    }
                    AH.Text = Convert.ToString(ah, 2).PadLeft(8, '0'); BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0'); CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0'); DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0'); AL.Text = Convert.ToString(al, 2).PadLeft(8, '0'); BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0'); CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0'); DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');

                    if (int20)
                    {
                        Environment.Exit(0);

                    }
                    if (int33)
                    {
                        Cursor.Position = new Point(ch, dh);
                        // label1.Text = Cursor.Position.ToString();  //250 dla pokazania
                        // button4.Enabled = true;
                        rozkaz.Enabled = true;
                        textBox2.Clear();
                        PMNZST.Clear();
                    }
                    if (int34)
                    {

                        //label2.Text = Cursor.Position.X.ToString();
                       // label3.Text = (Cursor.Position.Y.ToString());
                        /*AH.Text = "0";
                        BH.Text = "0";
                        AL.Text = "0";
                          BL.Text = "0";
                          CL.Text = "0";
                          DL.Text = "0";*/
                        CH.Text = (Cursor.Position.X.ToString());
                        DH.Text = (Cursor.Position.Y.ToString());
                        textBox2.Clear();
                        PMNZST.Clear();
                        rozkaz.Enabled = true;
                    }
                    if (int21)
                    {

                        if (Convert.ToInt32(AH.Text) == 1)
                        {

                            Environment.Exit(0);
                        }
                        // data
                        if (Convert.ToInt32(AH.Text) == 10)// 2
                        {

                            CH.Text = DateTime.Now.Year.ToString();
                            DH.Text = DateTime.Now.Month.ToString();
                            DL.Text = DateTime.Now.Day.ToString();
                            rozkaz.Enabled = true;
                            // label1.Text = Convert.ToInt32(AL.Text).ToString();

                        }
                        if (Convert.ToInt32(AH.Text) == 11)// 3
                        {
                            Environment.Exit(Convert.ToInt32(AL.Text));

                            rozkaz.Enabled = true;


                        }
                        //czas
                        if (Convert.ToInt32(AH.Text) == 100)// 4
                        {
                            CH.Text = DateTime.Now.Hour.ToString();
                            CL.Text = DateTime.Now.Minute.ToString();
                            DH.Text = DateTime.Now.Second.ToString();
                            DL.Text = DateTime.Now.Millisecond.ToString();

                            rozkaz.Enabled = true;

                        }

                        //zwraca wersje dos
                        if (Convert.ToInt32(AH.Text) == 101)// 5
                        {
                            //ASCII TO HEX
                            string original = textBox1.Text;

                            ASCIIEncoding ascii = new ASCIIEncoding();

                            Byte[] bytes = ascii.GetBytes(original);
                            foreach (var value in bytes) ;

                            String decoded = ascii.GetString(bytes);
                            string StringByte = BitConverter.ToString(bytes);

                            rozkaz.Enabled = true;

                            string bin = "";

                            string[] strarray = StringByte.Split('-'); //dzielimy na mniejsze stringi
                            int Len = strarray.Length;
                            int j = 0;
                            for (int i = 0; i < Len; i++)
                            {

                                string binarystring = String.Join(String.Empty, strarray[i].Select(
                             c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));   // konwersja kazdego stringa na binarne
                                bin = bin.Insert(j, binarystring);  // dodawanie przeksztalconych stringow do nowego stringa (na odwrot)
                                j = j + 8;

                                AH.Text = binarystring;
                                rozkaz.Enabled = true;


                            }
                        }
                        //ustawienie zmiennej systemowej verify na stan AL
                        if (Convert.ToInt32(AH.Text) == 110)// 6
                        {

                            verify = AL.Text;
                            // label1.Text = verify;
                            rozkaz.Enabled = true;


                        }
                        //zwrocenie do rejestru AL wartosci zmiennej systemowej verify
                        if (Convert.ToInt32(AH.Text) == 111)// 7
                        {
                            AL.Text = verify;
                            rozkaz.Enabled = true;


                        }

                    }
                }
                stos.Text = wskaznik.ToString();
                AH.Text= Convert.ToString(ah, 2).PadLeft(8, '0'); BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0'); CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0'); DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0'); AL.Text = Convert.ToString(al, 2).PadLeft(8, '0'); BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0'); CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0'); DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');

            }
            
            textBox2.Clear();
            PMNZST.Clear();
            button4.Enabled = true; 
        }

        private void krokowa_Click(object sender, EventArgs e)
        {

            //button3.Enabled = false;   //zakomenuj jak cos
            
                if (textBox2.Lines.Length > 0 &&  b < textBox2.Lines.Length)
                {
                    mov = textBox2.Lines[b].Contains("MOV");
                    add = textBox2.Lines[b].Contains("ADD");
                    sub = textBox2.Lines[b].Contains("SUB");
                    push = textBox2.Lines[b].Contains("PUSH");
                    pop = textBox2.Lines[b].Contains("POP");

                    if (mov)
                    {
                        text = textBox2.Lines[b].Substring(4, 2);
                        zmien = PMNZST.Lines[b].Substring(7);


                        if (text == "AH")
                        {
                            ah = Convert.ToByte(zmien);
                        }
                        if (text == "AL")
                        {
                            al = Convert.ToByte(zmien);
                        }
                        if (text == "BH")
                        {
                            bh = Convert.ToByte(zmien);
                        }
                        if (text == "BL")
                        {
                            bl = Convert.ToByte(zmien);
                        }
                        if (text == "CH")
                        {
                            ch = Convert.ToByte(zmien);
                        }
                        if (text == "CL")
                        {
                            cl = Convert.ToByte(zmien);
                        }
                        if (text == "DH")
                        {
                            dh = Convert.ToByte(zmien);
                        }
                        if (text == "DL")
                        {
                            dl = Convert.ToByte(zmien);
                        }
                        AH.Text = Convert.ToString(ah, 2).PadLeft(8, '0'); BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0'); CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0'); DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0'); AL.Text = Convert.ToString(al, 2).PadLeft(8, '0'); BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0'); CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0'); DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');
                        stos.Text = wskaznik.ToString();
                    }
                    if (add)
                    {
                        text = textBox2.Lines[b].Substring(4, 2);
                        zmien = PMNZST.Lines[b].Substring(7);

                        if (text == "AH")
                        {
                            ah += Convert.ToByte(zmien);
                        }
                        if (text == "AL")
                        {
                            al += Convert.ToByte(zmien);
                        }
                        if (text == "BH")
                        {
                            bh += Convert.ToByte(zmien);
                        }
                        if (text == "BL")
                        {
                            bl += Convert.ToByte(zmien);
                        }
                        if (text == "CH")
                        {
                            ch += Convert.ToByte(zmien);
                        }
                        if (text == "CL")
                        {
                            cl += Convert.ToByte(zmien);
                        }
                        if (text == "DH")
                        {
                            dh += Convert.ToByte(zmien);
                        }
                        if (text == "DL")
                        {
                            dl += Convert.ToByte(zmien);
                        }
                        AH.Text = Convert.ToString(ah, 2).PadLeft(8, '0'); BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0'); CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0'); DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0'); AL.Text = Convert.ToString(al, 2).PadLeft(8, '0'); BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0'); CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0'); DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');
                        stos.Text = wskaznik.ToString();
                    }
                    if (sub)
                    {
                        text = textBox2.Lines[b].Substring(4, 2);
                        zmien = PMNZST.Lines[b].Substring(7);


                        if (text == "AH")
                        {
                            ah -= Convert.ToByte(zmien);
                        }
                        if (text == "AL")
                        {
                            al -= Convert.ToByte(zmien);
                        }
                        if (text == "BH")
                        {
                            bh -= Convert.ToByte(zmien);
                        }
                        if (text == "BL")
                        {
                            bl -= Convert.ToByte(zmien);
                        }
                        if (text == "CH")
                        {
                            ch -= Convert.ToByte(zmien);
                        }
                        if (text == "CL")
                        {
                            cl -= Convert.ToByte(zmien);
                        }
                        if (text == "DH")
                        {
                            dh -= Convert.ToByte(zmien);
                        }
                        if (text == "DL")
                        {
                            dl -= Convert.ToByte(zmien);
                        }
                        AH.Text = Convert.ToString(ah, 2).PadLeft(8, '0'); BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0'); CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0'); DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0'); AL.Text = Convert.ToString(al, 2).PadLeft(8, '0'); BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0'); CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0'); DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');
                        stos.Text = wskaznik.ToString();
                    }
                    if (push)
                    {

                        text = textBox2.Lines[b].Substring(4, 2);

                        if (text == "AH")
                        {
                            SP = int.Parse(AH.Text); //to podobno zmienia stringa którym są rejestry w inta którym jest sp
                        }
                        if (text == "AL")
                        {
                            SP = int.Parse(AL.Text);
                        }
                        if (text == "BH")
                        {
                            SP = int.Parse(BH.Text);
                        }
                        if (text == "BL")
                        {
                            SP = int.Parse(BL.Text);
                        }
                        if (text == "CH")
                        {
                            SP = int.Parse(CH.Text);
                        }
                        if (text == "CL")
                        {
                            SP = int.Parse(CL.Text);
                        }
                        if (text == "DH")
                        {
                            SP = int.Parse(DH.Text);
                        }
                        if (text == "DL")
                        {
                            SP = int.Parse(DL.Text);
                        }
                       // AH.Text = Convert.ToString(ah, 2).PadLeft(8, '0'); BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0'); CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0'); DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0'); AL.Text = Convert.ToString(al, 2).PadLeft(8, '0'); BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0'); CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0'); DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');
                        tablicaS[wskaznik] = SP; //powinno wpisac wartosc sp na stos
                        wskaznik--;

                    
                }
                
                    if (pop)
                    {
                        text = textBox2.Lines[b].Substring(4, 2);

                        if (text == "AH")
                        {
                            POOP = int.Parse(AH.Text); //to podobno zmienia stringa którym są rejestry w inta którym jest sp
                        }
                        if (text == "AL")
                        {
                            POOP = int.Parse(AL.Text);
                        }
                        if (text == "BH")
                        {
                            POOP = int.Parse(BH.Text);
                        }
                        if (text == "BL")
                        {
                            POOP = int.Parse(BL.Text);
                        }
                        if (text == "CH")
                        {
                            POOP = int.Parse(CH.Text);
                        }
                        if (text == "CL")
                        {
                            POOP = int.Parse(CL.Text);
                        }
                        if (text == "DH")
                        {
                            POOP = int.Parse(DH.Text);
                        }
                        if (text == "DL")
                        {
                            POOP = int.Parse(DL.Text);
                        }
                        //tablicaS[wskaznik] = POOP; //powinno wpisac wartosc sp na stos
                        // AH.Text = Convert.ToString(ah, 2).PadLeft(8, '0'); BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0'); CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0'); DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0'); AL.Text = Convert.ToString(al, 2).PadLeft(8, '0'); BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0'); CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0'); DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');
                        wskaznik++;
                        if (wskaznik > 1023)
                        {
                            MessageBox.Show("Alarma! Przekroczyłeś wartość stosu! Wykonaj inną funkcję!");
                        }
                    }
                if (b >= textBox2.Lines.Length)
                {
                    //button4.Enabled = false; //zakomenuj jak cos
                    //button3.Enabled = true; //zakomenuj jak cos

                    b = 0;
                    //textBox2.Clear();
                    //PMNZST.Clear();
                }
                b++;
            }
                //label1.Text = textBox2.Lines.Length.ToString();


            
        }

        private void reset_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = "";
            wskaznik = S-1;
            textBox2.Clear();
            stos.Clear();
            rozkaz.Enabled = true;
            adres.Enabled = false;
            wartosc.Enabled = false;
            rejestr.Enabled = false;
            adresowanie.Enabled = false;
            button1.Enabled = false;
            PMNZST.Enabled = false;
            PMNZST.Clear();
            button3.Enabled = true;
            button4.Enabled = true;
            n = 0;
            ah = 0;
            al = 0;
            bh = 0;
            bl = 0;
            ch = 0;
            cl = 0;
            dh = 0;
            dl = 0;
            AH.Text = Convert.ToString(ah, 2).PadLeft(8, '0');BH.Text = Convert.ToString(bh, 2).PadLeft(8, '0');CH.Text = Convert.ToString(ch, 2).PadLeft(8, '0');DH.Text = Convert.ToString(dh, 2).PadLeft(8, '0');AL.Text = Convert.ToString(al, 2).PadLeft(8, '0');BL.Text = Convert.ToString(bl, 2).PadLeft(8, '0');CL.Text = Convert.ToString(cl, 2).PadLeft(8, '0');DL.Text = Convert.ToString(dl, 2).PadLeft(8, '0');


        }

        private void zapis_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText(@"C:\Users\anka\Desktop\POSK\plik.txt"))
            {
                for (n = 0; n < textBox2.Lines.Length; n++)
                {
                    sw.WriteLine(textBox2.Lines[n]);
                }
            }
        }

        private void odczyt_Click(object sender, EventArgs e)
        {
            StreamReader s = new StreamReader(@"C:\Users\anka\Desktop\POSK\plik.txt");
            PMNZST.Text = PMNZST.Text + s.ReadToEnd();
            textBox2.Text = PMNZST.Text;
        }


        
    }
                
}