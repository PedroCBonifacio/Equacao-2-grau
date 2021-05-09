using System;
using System.Windows.Forms;

namespace Eq_2_grau
{
    public partial class frmSegundoGrau : Form
    {
        public frmSegundoGrau()
        {
            InitializeComponent();
        }
        public double numeroA, numeroB, numeroC; //Criando variável local
        public int verificacao_Textbox() //Criando uma função
        {
            int verTextbox = 0;
            if (!double.TryParse(txtA.Text, out numeroA)) //Verificando se as textboxes são números
            {
                verTextbox = verTextbox + 1;
            }
            if (!double.TryParse(txtB.Text, out numeroB))
            {
                verTextbox = verTextbox + 1;
            }
            if (!double.TryParse(txtC.Text, out numeroC))
            {
                verTextbox = verTextbox + 1;
            }
            return verTextbox;
        }
        private void btnCalcular_Click(object sender, EventArgs e) //Codigo (Evento) após usuario clickar em button Calcular
        {
            lblMensagem.Visible = true; //Tornando a label Mensagem visível para o usuário
            Bhaskara bhaskara = new Bhaskara(); //Chamando a classe Bhaskara

            if (verificacao_Textbox() == 1) //Caso UMA textbox esteja irregular execute o código abaixo
            {
                if (!double.TryParse(txtA.Text, out numeroA))
                { 
                    lblMensagem.Text = "Esta é uma equação do primeiro grau";
                }
                
                else //Caso nenhuma textbox não esteja irregular execute o código abaixo 
                {
                    try {
                        bhaskara.A = Convert.ToDouble(txtA.Text);
                        bhaskara.B = txtB.Text == "" ? 0 : Convert.ToDouble(txtB.Text); //Se B ou C estiverem vazio, bhaskara.B(C) vão receber 0
                        bhaskara.C = txtC.Text == "" ? 0 : Convert.ToDouble(txtC.Text);

                        if (bhaskara.Delta() >= 0) //Verificando se delta é positivo
                        {   //Fazendo o calculo com o B ou C podendo ser 0  
                            txtDelta.Text = Convert.ToString(bhaskara.Delta()); 
                            txtX1.Text = Convert.ToString(bhaskara.X1());       //Transformando os eventos de bhaskara em txt
                            txtX2.Text = Convert.ToString(bhaskara.X2());       
                            lblMensagem.Text = "Raízes Caulculadas.";
                        }
                        else
                        {
                            lblMensagem.Text = "Não foi possível calcular as raízes pois o delta é negativo.";
                        }
                    } catch // O catch somente será executado caso o try de errado
                    {
                        if (!double.TryParse(txtB.Text, out numeroB))
                            {
                                lblMensagem.Text = "B não é um número";
                            }
                        else
                        {
                            lblMensagem.Text = "C não é um número";
                        }
                    }
                } 
            }
            else if (verificacao_Textbox() == 2) // Caso DUAS textboxes estejam irregulares execute o código abaixo
            {
                try {
                    lblMensagem.Text = "Os campos";
                    if (txtA.Text == "")
                    {
                        lblMensagem.Text += " A";
                    }
                    else if (!double.TryParse(txtA.Text, out numeroA))
                    {
                        lblMensagem.Text += $" {txtA.Text}";
                    }
                    if (txtB.Text == "")
                    {
                        lblMensagem.Text += " B";
                    }
                    else if (!double.TryParse(txtB.Text, out numeroB))
                    {
                        lblMensagem.Text += $" {txtB.Text}";
                    }
                    if (txtC.Text == "")
                    {
                        lblMensagem.Text += " C";
                    }
                    else if (!double.TryParse(txtC.Text, out numeroC))
                    {
                        lblMensagem.Text += $" {txtC.Text}";
                    }
                } finally //O finally sempre será executado independente do resultado do try 
                {
                    lblMensagem.Text += " ou estão vazios, ou não são números";
                }
            }
            else if (verificacao_Textbox() == 3) //Caso TRES (TODAS) textboxes estejam irregulares execute o código abaixo
            {
                if (txtA.Text == "" && txtB.Text == "" && txtC.Text == "")
                {
                    lblMensagem.Text = "Todos os campos estão vazios";
                }
                else
                {
                    try
                    {
                        lblMensagem.Text = "Os campos";
                        if (txtA.Text == "")
                        {
                            lblMensagem.Text += " A";
                        }
                        else if (!double.TryParse(txtA.Text, out numeroA))
                        {
                            lblMensagem.Text += $" {txtA.Text}";
                        }
                        if (txtB.Text == "")
                        {
                            lblMensagem.Text += " B";
                        }
                        else if (!double.TryParse(txtB.Text, out numeroB))
                        {
                            lblMensagem.Text += $" {txtB.Text}";
                        }
                        if (txtC.Text == "")
                        {
                            lblMensagem.Text += " C";
                        }
                        else if (!double.TryParse(txtC.Text, out numeroC))
                        {
                            lblMensagem.Text += $" {txtC.Text}";
                        }
                    }
                    finally //O finally sempre será executado independente do resultado do try 
                    {
                        lblMensagem.Text += " ou estão vazios, ou não são números";
                    }

                }
            }
            else if (!txtA.Text.StartsWith("0"))
            {
                bhaskara.A = Convert.ToDouble(txtA.Text);
                bhaskara.B = Convert.ToDouble(txtB.Text);
                bhaskara.C = Convert.ToDouble(txtC.Text);

                if (bhaskara.Delta() >= 0)
                {   //Fazendo o cálculo com a equação completa
                    txtDelta.Text = Convert.ToString(bhaskara.Delta());
                    txtX1.Text = Convert.ToString(bhaskara.X1());
                    txtX2.Text = Convert.ToString(bhaskara.X2());
                    lblMensagem.Text = "Raízes Caulculadas.";
                }
                else
                {
                    lblMensagem.Text = "Não foi possível calcular as raízes pois o delta é negativo.";
                }
            }
            else
            {
                lblMensagem.Text = "Isso não é uma equaçaõ de segundo grau";
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtDelta.Clear();             //Apagando tudo
            txtX1.Clear();
            txtX2.Clear();
            lblMensagem.Visible = false; //Label Mensagem se tornado invisível
            txtA.Focus();                //Textbox A, sendo focada
        } 
    }
    }

