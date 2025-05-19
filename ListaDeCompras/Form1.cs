using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeCompras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string produto = txbAdicionar.Text;
            // Evitar mensagens repetidas e vazias (coloquei so para não esquecer 👍
            if (txbAdicionar.Text == "")
            {
                MessageBox.Show("Escreva o seu produto no campo", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbAdicionar.Focus();
            }
            else if (lsbResultado.Items.Contains(produto))
            {
                MessageBox.Show("Produto ja está adicionado a lista", "OPS!", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                lsbResultado.Items.Add(txbAdicionar.Text);
                txbAdicionar.Clear();

            }
        }
        // Botão de Limpar()
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lsbResultado.Items.Clear();
            txbAdicionar.Clear();
        }

        // Habilitar e desabilitar botão de deletar
        private void lsbResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbResultado.SelectedIndex == -1)
            {
                btnRemover.Enabled = false;
            }
            else
            {
                btnRemover.Enabled = true;
                
            }

        }
        // Botão de limpar um item da lista selecionado 
        private void btnRemover_Click(object sender, EventArgs e)
        {
            lsbResultado.Items.RemoveAt(0);
        }

        // Habilitar botão de adicionar quando tiver maior ou igual à 3
        private void txbAdicionar_TextChanged(object sender, EventArgs e)
        {
            if (txbAdicionar.Text.Length >= 3) 
            {
                btnAdicionar.Enabled = true;
                btnLimpar.Enabled = true;
            }
            else
            {
                btnAdicionar.Enabled = false;
                btnLimpar.Enabled = false;
            }
        }
    }
}

