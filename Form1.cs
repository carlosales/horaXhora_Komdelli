using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace hora_Komdelli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //corte planejado
            textBox22.Enabled = false;
            textBox21.Enabled = false;
            textBox20.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox17.Enabled = false;
            textBox16.Enabled = false;
            textBox15.Enabled = false;
            textBox14.Enabled = false;
            textBox13.Enabled = false;
            textBox12.Enabled = false;
            //o.p planejado
            textBox44.Enabled = false;
            textBox43.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox40.Enabled = false;
            textBox39.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox35.Enabled = false;
            textBox34.Enabled = false;
        }

        private void Abrir_plano_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            openFileDialog1.CheckFileExists = true;
            var abrirarquivo = openFileDialog1.FileName;
            //MessageBox.Show(abrirarquivo);

            var linha1 = 19;
            var linha2 = 20;
            var linha3 = 21;
            var linha4 = 22;
            var linha5 = 23;
            var linha6 = 24;
            var linha7 = 26;
            var linha8 = 27;
            var linha9 = 28;
            var linha10 = 29;
            var linha11 = 30;

            #region   excell
            try
            {
                var excell = new XLWorkbook(abrirarquivo);

                var sheets = excell.Worksheet(6);

                textBox22.Text = sheets.Cell("j" + linha1.ToString()).Value.ToString();
                textBox21.Text = sheets.Cell("j" + linha2.ToString()).Value.ToString();
                textBox20.Text = sheets.Cell("j" + linha3.ToString()).Value.ToString();
                textBox19.Text = sheets.Cell("j" + linha4.ToString()).Value.ToString();
                textBox18.Text = sheets.Cell("j" + linha5.ToString()).Value.ToString();
                textBox17.Text = sheets.Cell("j" + linha6.ToString()).Value.ToString();
                textBox16.Text = sheets.Cell("j" + linha7.ToString()).Value.ToString();
                textBox15.Text = sheets.Cell("j" + linha8.ToString()).Value.ToString();
                textBox14.Text = sheets.Cell("j" + linha9.ToString()).Value.ToString();
                textBox13.Text = sheets.Cell("j" + linha10.ToString()).Value.ToString();
                textBox12.Text = sheets.Cell("j" + linha11.ToString()).Value.ToString();

                textBox44.Text = sheets.Cell("I" + linha1.ToString()).Value.ToString();
                textBox43.Text = sheets.Cell("I" + linha2.ToString()).Value.ToString();
                textBox42.Text = sheets.Cell("I" + linha3.ToString()).Value.ToString();
                textBox41.Text = sheets.Cell("I" + linha4.ToString()).Value.ToString();
                textBox40.Text = sheets.Cell("I" + linha5.ToString()).Value.ToString();
                textBox39.Text = sheets.Cell("I" + linha6.ToString()).Value.ToString();
                textBox38.Text = sheets.Cell("I" + linha7.ToString()).Value.ToString();
                textBox37.Text = sheets.Cell("I" + linha8.ToString()).Value.ToString();
                textBox36.Text = sheets.Cell("I" + linha9.ToString()).Value.ToString();
                textBox35.Text = sheets.Cell("I" + linha10.ToString()).Value.ToString();
                textBox34.Text = sheets.Cell("I" + linha11.ToString()).Value.ToString();

                //textBox22.Text = sheets.Cell("L").GetString();
                //var result = new String[] { textBox12.Text +textBox13.Text +textBox14.Text +textBox15.Text + textBox16.Text +textBox17.Text +textBox18.Text +textBox19.Text +textBox20.Text +textBox21.Text +textBox22.Text };
                //MessageBox.Show(result.ToString());
            }
            catch (Exception E)
            {
                MessageBox.Show("erro ao carrega os dados" + E);
            }
            finally
            {

                //Application.Exit();
            }


        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            #region conexão,salvando banco de dados

            var Db = new Conexao();
            {
               // var teste = new Corte_executado()
               Db.corte_Executados.AddAsync(new Corte_executado
                {
                    primeiro = textBox1.Text,
                    segundo = textBox2.Text,
                    terceiro = textBox3.Text,
                    quarto = textBox4.Text,
                    quinto = textBox5.Text,
                    sexto = textBox6.Text,
                    setimo = textBox7.Text,
                    oitavo = textBox8.Text,
                    nono = textBox9.Text,
                    decimo = textBox10.Text,
                    decimo_primeiro = textBox11.Text
                });

                Db.corte_Planejados.AddAsync(new Corte_planejado
                {
                    primeiro = textBox22.Text,
                    segundo = textBox21.Text,
                    terceiro = textBox20.Text,
                    quarto = textBox19.Text,
                    quinto = textBox18.Text,
                    sexto = textBox17.Text,
                    setimo = textBox16.Text,
                    oitavo = textBox15.Text,
                    nono = textBox14.Text,
                    decimo = textBox13.Text,
                    decimo_primeiro = textBox12.Text
                });
                Db.op_Executados.AddAsync(new Op_executado
                {
                    primeiro = textBox33.Text,
                    segundo = textBox32.Text,
                    terceiro = textBox31.Text,
                    quarto = textBox30.Text,
                    quinto = textBox29.Text,
                    sexto = textBox28.Text,
                    setimo = textBox27.Text,
                    oitavo = textBox26.Text,
                    nono = textBox25.Text,
                    decimo = textBox24.Text,
                    decimo_primeiro = textBox23.Text
                });

                Db.op_Planejados.AddAsync(new Op_planejado
                {
                    primeiro = textBox44.Text,
                    segundo = textBox43.Text,
                    terceiro = textBox42.Text,
                    quarto = textBox41.Text,
                    quinto = textBox40.Text,
                    sexto = textBox39.Text,
                    setimo = textBox38.Text,
                    oitavo = textBox37.Text,
                    nono = textBox36.Text,
                    decimo = textBox35.Text,
                    decimo_primeiro = textBox34.Text
                });
               
                try
                {
                    Db.SaveChangesAsync();
                    MessageBox.Show("salvo com sucesso");
                }
                catch (Exception E)
                {
                    MessageBox.Show("problema ao salvar"+ E);
                }
            }
           

            #endregion


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var conex = new Conexao();
         {
             conex.corte_Executados.First<Corte_executado>();
            conex.corte_Executados.Find(corte_executado);
            conex.SaveChanges();
        }



    }
    }

}


