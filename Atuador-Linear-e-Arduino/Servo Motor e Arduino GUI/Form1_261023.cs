using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Xml.Linq;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Ports;
using System.IO;

namespace Servo_Motor_e_Arduino_GUI
{

    public partial class Form1 : Form
    {
        private delegate void d1(string indata);
        private static int counter;
        int erro = 0;
        Decimal calibra;
        string m1 = "0";  // posição
        string m2 = "0";  // velocidade
        string m3 = "0";  // direção
        int motor = 1; // Armazena qual motor está sendo utilizado
        string m10; // Envia comando para mover o motor com ou sem aceleração
        string m11 = "X"; // Envia a informação para mover o motor com ou sem aceleração durante a calibração o default é com aceleração
        double constanteCalibracao2 = 0.0002222;
        double constanteCalibracao1 = 0.0002222;  //A constante de calibração default dos motores que representa a velocidade de aceleração de 2500pulsos/s
        bool salvar = false;
        String caminho;


        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
            InitializeComponent();

            // Subscribe to the TextChanged event of textBox1
            textBox4.TextChanged += TextBox4_TextChanged;


        }


        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            // Update the text of textBox2 when textBox1 changes
            textBox11.Text = textBox4.Text;
        }

        private void onButton_Click_1(object sender, EventArgs e)
        {
            // Send command to the arduino to rotate the motor with acceleration
            serialPort2.Write("G#");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Send command to the arduino to turn off the enable function of the driver deenergizing the motor
            serialPort2.Write("a#");
        }

        private void PulseQntd_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Send pulse qntd to driver
                if (textBox1.Text != "") // tratamento de erro
                {
                    double pulsos_truncado = Math.Truncate(float.Parse(textBox1.Text)); //tranformando string em float para truncar o numero
                    textBox1.Text = pulsos_truncado.ToString();
                }

                if (textBox8.Text == "")//se a caixa da distância está vazia 
                {
                    float x = float.Parse(textBox1.Text);
                    double distancia = constanteCalibracao1 * x;
                    textBox8.Text = distancia.ToString();
                }
                if (textBox1.Text == "")//se a caixa dos pulsos está vazia 
                {
                    float x = float.Parse(textBox8.Text);
                    double pulsos = Math.Truncate(x / constanteCalibracao1);
                    textBox1.Text = pulsos.ToString();
                    textBox8.Text = "";
                    textBox8.Text = (pulsos * constanteCalibracao1).ToString();

                }

                m1 = "P" + textBox1.Text + "#";
            }
            catch
            {
                textBox4.AppendText("O tipo de texto que você colocou na caixa de distância não é válido. Tente Novamente!\r\n");

            }
        }

        private void Velocity_Click_1(object sender, EventArgs e)
        {
            // Send velocity qntd to driver
            try
            {
                
                if (textBox15.Text == "")//se a caixa da mm/s está vazia 
                {
                    float pulsos = float.Parse(textBox2.Text.Replace(".", ","));
                    double velocidade = constanteCalibracao1 * pulsos; //velocidade em pulsos por segundo
                    textBox15.Text = velocidade.ToString();
                }
                if (textBox2.Text == "")//se a caixa dos pulsos está vazia 
                {
                    float velocidade = float.Parse(textBox15.Text.Replace(".", ","));
                    double pulsos = velocidade / constanteCalibracao1;
                    textBox2.Text = pulsos.ToString();
                }
                m2 = "V" + textBox2.Text + "#";
            }
            catch 
            {
                 textBox4.AppendText("O tipo de texto que você colocou na caixa de velocidade não é válido. Tente Novamente!\r\n");

            }
        }

        private void Direction_Click_1(object sender, EventArgs e)
        {
            // Send Send direction(CW or CCW) to driver  
            m3 = "C#";
        }

        private void Direction2_Click_1(object sender, EventArgs e)
        {
            // Send direction(CW or CCW) to driver
            m3 = "B#";
        }

        private void StopButton_Click_1(object sender, EventArgs e)
        {
            // Send pulse qntd to driver
            string m4 = "n#";
            serialPort2.Write(m4);
        }



        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = serialPort2.ReadLine();
            d1 writeit = new d1(Write2Form);
            Invoke(writeit, indata);

        }

        public void Write2Form(String indata)
        {
            // This function handles data sent from the arduino

            char g = indata[0];
            String texto = Convert.ToString(indata).Substring(1).Replace("#", "");

            switch (g)
            {

                case 'l':
                    textBox10.Text = "";
                    if (salvar & saveFileDialog1.FileName != "")
                    {
                        File.AppendAllText(saveFileDialog1.FileName + ".txt", texto + Environment.NewLine);
                    }
                    textBox10.AppendText(texto + "mm");
                    break;

                case 'd':
                    textBox8.Text = "";
                    textBox8.AppendText("A constante de calibração para essa velocidade é: ");
                    break;

                //Algumas mensagens com caracteres especiais
                case 'j':
                    textBox4.AppendText("Calibração iniciada!\r\n");
                    break;
                case 'c':
                    textBox4.AppendText("Direcão motor 1: Para cima\r\n");
                    break;
                case 'C':
                    textBox4.AppendText("Direcão motor 2: Para cima\r\n");
                    break;

                case 'b':
                    textBox4.AppendText("Direcão motor 1: Para baixo\r\n");
                    break;
                case 'B':
                    textBox4.AppendText("Direcão motor 2: Para baixo\r\n");
                    break;

                case 'a':
                    textBox4.AppendText("O motor 1 está se movendo com aceleração!\r\n");
                    break;
                case 'A':
                    textBox4.AppendText("O motor 2 está se movendo com aceleração!" + "\r\n");
                    break;

                case 'Q':
                    textBox4.AppendText("Valor de velocidade inválido! Insira um valor entre 200 e 8000 pulsos/segundo" + "\r\n");
                    break;

                case 'T':
                    textBox4.AppendText("Mude a direção do deslocamento para movimenta-lo." + "\r\n" + "Aperte o botão para ativar o sensor indutivo novamente!" + "\r\n");
                    break;

                case 'U':
                    textBox4.AppendText("Primeiro motor sendo operado!" + "\r\n");
                    break;
                case 'u':
                    textBox4.AppendText("Segundo motor sendo operado!" + "\r\n");
                    break;



                case '/':
                    textBox4.AppendText(texto + "\r\n");
                break;

                case 'w':
                    if(motor == 1)
                    {
                        textBox11.AppendText("A constante de calibração do motor 1 é:" + texto + "\r\n");
                    }
                    else
                    {
                        textBox11.AppendText("A constante de calibração do motor 2 é:" + texto + "\r\n");
                    }
                    
                    break;

                case 'X':
                    calibra = Convert.ToDecimal(texto)/60000;
                    String Calibra = Convert.ToString(calibra);
                    textBox4.AppendText(Calibra + "\r\n");
                    break;

                default:
                    textBox4.AppendText(texto + "\r\n");
                    break;


            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void En_Button_Click(object sender, EventArgs e)
        {
            // Send command to the arduino to turn on the enable function of the driver energizing the motor
            string m4 = "A#";
            serialPort2.Write(m4);
        }

        private void Enviar_Click_1(object sender, EventArgs e)
        {
            //Envia os parâmetros do motor para o arduino
            if (m1 != "0" & m2 != "0" & m3 != "0")
            {
                serialPort2.Write(m3);
                Thread.Sleep(1000);
                serialPort2.Write(m1);
                Thread.Sleep(1000);
                serialPort2.Write(m2);
                Thread.Sleep(1000);
            }
            else
            {
                textBox4.AppendText("Algum valor está faltando. Tente novamente! " + "\r\n");

            }



        }

        private void SemAcelerar_Click_1(object sender, EventArgs e)
        {
            // Send command to the arduino to rotate the motor with acceleration
            serialPort2.Write("H");
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModoMovimentacao_Click(object sender, EventArgs e)
        {
            groupBox4.Hide();
            groupBox2.Show();
        }

        private void ModoCalibracao_Click(object sender, EventArgs e)
        {
            groupBox4.Show();
            groupBox2.Hide();
        }

        private void A_laser_Click(object sender, EventArgs e)
        {
            try
            {
                // Send velocity qntd to driver
                m2 = "J" + textBox6.Text.Replace(",", ".") + "#";
                serialPort2.Write(m2);
            }
            catch
            {
                textBox4.AppendText("O tipo de texto que você colocou na caixa do laser não é válido. Tente Novamente!\r\n");

            }
        }
        private void Aceleracao_calibracao_Click(object sender, EventArgs e)
        {
            m11 = "X" + "#";
        }

        private void Sem_Aceleracao_calibracao_Click(object sender, EventArgs e)
        {
            m11 = "x" + "#";
        }

        private void calibrar_Click(object sender, EventArgs e)
        {
            if (m2 != "0" & m3 != "0")
            {
                serialPort2.Write("A#");
                Thread.Sleep(1000);
                serialPort2.Write(m3);
                Thread.Sleep(1000);
                serialPort2.Write("P" + 60000);
                Thread.Sleep(1000);
                serialPort2.Write(m2);
                Thread.Sleep(1000);
                serialPort2.Write(m11);
                Thread.Sleep(1000);


                serialPort2.Write("I");
            }
            else
            {
                textBox4.AppendText("Algum valor está faltando. Tente novamente! " + "\r\n");

            }

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string [] ports = SerialPort.GetPortNames();
            portComboBox.Items.AddRange(ports);
        }   

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Motor 1")
            {
                button7.Text = "Motor 2";
                serialPort2.Write("M#");
                motor = 2;


            }
            else if (button7.Text == "Motor 2")
            {
                button7.Text = "Motor 1";
                serialPort2.Write("R#");
                motor = 1;
 
            }
        }

        private void button6_Click(object sender, EventArgs e) 
        {
            //Ativa o sensor indutivo
            serialPort2.Write("S");
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Send calibration constant to arduino
                if (motor == 1)
                {
                    constanteCalibracao1 = double.Parse(textBox12.Text, CultureInfo.InvariantCulture);
                }
                if (motor == 2)
                {
                    constanteCalibracao2 = double.Parse(textBox12.Text, CultureInfo.InvariantCulture);
                }
                serialPort2.Write("U" + textBox12.Text + "#");
            }
            catch
            {
                textBox4.AppendText("O tipo de texto que você colocou na caixa de constante não é válido. Tente Novamente!\r\n");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // define a velocidade do motor na calibração
            try
            {
                m2 = "V" + textBox7.Text + "#";
            }
            catch
            {
                textBox4.AppendText("O tipo de texto que você colocou na caixa de velocidade não é válido. Tente Novamente!\r\n");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            serialPort2.Write("N#");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Send Send direction(CW or CCW) to driver  
            m3 = "C#";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Send Send direction(CW or CCW) to driver  
            m3 = "B#";
        }

        private void textoPosicao_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                serialPort2.PortName = portComboBox.Text;
                serialPort2.BaudRate = 9600;
                serialPort2.Open();
                button11.Hide();
                button12.Show();
            }
            catch (Exception err)
            {
                textBox4.AppendText("Erro! Tente novamente!" + "\r\n");
                string[] ports = SerialPort.GetPortNames();
                portComboBox.Items.Clear();
                portComboBox.Items.AddRange(ports);
                
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort2.IsOpen)
                {
                    serialPort2.Close();
                }
                button12.Hide();
                button11.Show();
            }
            catch
            {
                textBox4.AppendText("Erro! Tente novamente!" + "\r\n");
            }

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void portComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            salvar = true;
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
            button13.Hide();
            button14.Show();
        }


        private void button14_Click(object sender, EventArgs e)
        {
            salvar = false;
            button14.Hide();
            button13.Show();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
