using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;

namespace OS2_projekt
{
    public partial class Form1 : Form
    {
        public RSACryptoServiceProvider csp;

        public Aes aes;
        public byte[] aesKey;
        public byte[] aesIV;

        public RSAParameters PublicRSA;
        public RSAParameters PrivateRSA;

        public string UnosniPath;

        public bool DataLoaded;
        public bool GeneratedSim;
        public bool GeneratedAsim;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            if (DataLoaded) {
                var sha256 = SHA256.Create();
                byte[] bytes = sha256.ComputeHash(File.ReadAllBytes(UnosniPath));

                var sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                saveFile(sb.ToString(), "Hash.txt");
            }
            else
            {
                MessageBox.Show("Datoteka nije ucitana");
            }
            
            
        }

        private void btnGenerirajAsimetricne_Click(object sender, EventArgs e)
        {
            csp = new RSACryptoServiceProvider(2048);
            RSAParameters privateKey = csp.ExportParameters(true);
            RSAParameters publicKey = csp.ExportParameters(false);

            PrivateRSA = privateKey;
            PublicRSA = publicKey;

            ExportRSAPrivateKey();
            ExportRSAPublicKey();

            GeneratedAsim = true;
        }

        private void btnSimetricnoKriptiranje_Click(object sender, EventArgs e)
        {
            if (DataLoaded) {
                if (GeneratedSim) {
                    Aes aesEncrypt = Aes.Create();
                    aesEncrypt.Key = aesKey;
                    aesEncrypt.IV = aesIV;
                    byte[] output;

                    ICryptoTransform encryptor = aesEncrypt.CreateEncryptor(aesKey, aesIV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //swEncrypt.Write(txtUlaz.Text);
                                swEncrypt.Write(File.ReadAllText(UnosniPath));
                            }
                            output = msEncrypt.ToArray();
                        }
                    }
                    saveFile(output);
                }
                else
                {
                    MessageBox.Show("Simetricni kljuc nije generiran");
                }
            }
            else
            {
                MessageBox.Show("Datoteka nije ucitana");
            }
            
        }

        private void btnGenerirajSimetricne_Click(object sender, EventArgs e)
        {
            aes = Aes.Create();
            aesKey = aes.Key;
            aesIV = aes.IV;

            saveFile(Convert.ToBase64String(aesKey), "tajni_kljuc.txt");
            saveFile(aes.IV, "aes_IV.txt");
            //File.WriteAllBytes("C:\\Users\\PC\\Desktop\\OS2\\tajni_kljuc.txt", aes.Key);
            //File.WriteAllBytes("C:\\Users\\PC\\Desktop\\OS2\\IV.txt", aes.IV);
            GeneratedSim = true;
            txtTajniKljuc.Text = Convert.ToBase64String(aesKey);
        }

        private void btnSimetricnoDesifriranje_Click(object sender, EventArgs e)
        {
            if (DataLoaded)
            {
                if (GeneratedSim)
                {
                    string outText = null;

                    using (Aes desifrirajAES = Aes.Create())
                    {
                        desifrirajAES.Key = aesKey;
                        desifrirajAES.IV = aesIV;

                        byte[] inText = File.ReadAllBytes(UnosniPath);

                        ICryptoTransform decryptor = desifrirajAES.CreateDecryptor(desifrirajAES.Key, desifrirajAES.IV);


                        using (MemoryStream msDecrypt = new MemoryStream(inText))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                {

                                    outText = srDecrypt.ReadToEnd();
                                }
                            }
                        }
                    }
                    saveFile(outText);
                }
                else
                {
                    MessageBox.Show("Simetricni kljuc nije generiran");
                }
            }
            else
            {
                MessageBox.Show("Datoteka nije ucitana");
            }

        }

        private void btnDatotekaUnos_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UnosniPath = dialog.FileName; 
            }
            labDatoteka.Text = "Odabrana Datoteka: " + UnosniPath;
            DataLoaded = true;
        }

        private void saveFile(byte[] data, string name = "Primjer.txt") {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = name;
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, data);
            }
            MessageBox.Show("Datoteka spemljena!");
        }

        private void saveFile(string data, string name = "Primjer.txt")
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = name;
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName,data);
            }
            MessageBox.Show("Datoteka spemljena!");
        }

        private void btnAsimetricnoKriptiranje_Click(object sender, EventArgs e)
        {
            if (DataLoaded) {
                if (GeneratedAsim) {
                    byte[] data = File.ReadAllBytes(UnosniPath);
                    data = csp.Encrypt(data, false);
                    saveFile(data);
                }
                else
                {
                    MessageBox.Show("Asimetricni kljuc nije generiran");
                }
            }
            else
            {
                MessageBox.Show("Datoteka nije ucitana");
            }
        }

        private void btnAsimetricnoDesifriranje_Click(object sender, EventArgs e)
        {
            if (DataLoaded)
            {
                if (GeneratedAsim)
                {
                    byte[] data = File.ReadAllBytes(UnosniPath);
                    data = csp.Decrypt(data, false);
                    saveFile(data);
                }
                else
                {
                    MessageBox.Show("Asimetricni kljuc nije generiran");
                }
            }
            else
            {
                MessageBox.Show("Datoteka nije ucitana");
            }
        }

        private void ExportRSAPrivateKey()
        {
            StringWriter outputStream = new StringWriter();
            using (var stream = new MemoryStream())
            {

                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); 
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); 
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.Modulus);
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.Exponent);
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.D);
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.P);
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.Q);
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.DP);
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.DQ);
                    EncodeIntegerBigEndian(innerWriter, PrivateRSA.InverseQ);
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();

                outputStream.Write("-----BEGIN RSA PRIVATE KEY-----\n");

                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.Write(base64, i, Math.Min(64, base64.Length - i));
                    outputStream.Write("\n");
                }
                outputStream.Write("-----END RSA PRIVATE KEY-----");
            }
            txtPrivatniKljuc.Text = outputStream.ToString();
            saveFile(outputStream.ToString(),"privatni_kljuc.txt");

        }
        private void ExportRSAPublicKey()
        {
            StringWriter outputStream = new StringWriter();
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30);
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    innerWriter.Write((byte)0x30);
                    EncodeLength(innerWriter, 13);
                    innerWriter.Write((byte)0x06); 
                    var rsaEncryptionOid = new byte[] { 0x2a, 0x86, 0x48, 0x86, 0xf7, 0x0d, 0x01, 0x01, 0x01 };
                    EncodeLength(innerWriter, rsaEncryptionOid.Length);
                    innerWriter.Write(rsaEncryptionOid);
                    innerWriter.Write((byte)0x05); 
                    EncodeLength(innerWriter, 0);
                    innerWriter.Write((byte)0x03); 
                    using (var bitStringStream = new MemoryStream())
                    {
                        var bitStringWriter = new BinaryWriter(bitStringStream);
                        bitStringWriter.Write((byte)0x00); 
                        bitStringWriter.Write((byte)0x30);
                        using (var paramsStream = new MemoryStream())
                        {
                            var paramsWriter = new BinaryWriter(paramsStream);
                            EncodeIntegerBigEndian(paramsWriter, PublicRSA.Modulus);
                            EncodeIntegerBigEndian(paramsWriter, PublicRSA.Exponent);
                            var paramsLength = (int)paramsStream.Length;
                            EncodeLength(bitStringWriter, paramsLength);
                            bitStringWriter.Write(paramsStream.GetBuffer(), 0, paramsLength);
                        }
                        var bitStringLength = (int)bitStringStream.Length;
                        EncodeLength(innerWriter, bitStringLength);
                        innerWriter.Write(bitStringStream.GetBuffer(), 0, bitStringLength);
                    }
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();

                outputStream.Write("-----BEGIN PUBLIC KEY-----\n");
                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.Write(base64, i, Math.Min(64, base64.Length - i));
                    outputStream.Write("\n");
                }
                outputStream.Write("-----END PUBLIC KEY-----");
            }
            txtJavniKljuc.Text = outputStream.ToString();
            saveFile(outputStream.ToString(),"javni_kljuc.txt");
        }

        private static void EncodeIntegerBigEndian(BinaryWriter stream, byte[] value, bool forceUnsigned = true)
        {
            stream.Write((byte)0x02);
            var prefixZeros = 0;
            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] != 0) break;
                prefixZeros++;
            }
            if (value.Length - prefixZeros == 0)
            {
                EncodeLength(stream, 1);
                stream.Write((byte)0);
            }
            else
            {
                if (forceUnsigned && value[prefixZeros] > 0x7f)
                {
                    EncodeLength(stream, value.Length - prefixZeros + 1);
                    stream.Write((byte)0);
                }
                else
                {
                    EncodeLength(stream, value.Length - prefixZeros);
                }
                for (var i = prefixZeros; i < value.Length; i++)
                {
                    stream.Write(value[i]);
                }
            }
        }

        private static void EncodeLength(BinaryWriter stream, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "Length must be non-negative");
            if (length < 0x80)
            {
                stream.Write((byte)length);
            }
            else
            {
                var temp = length;
                var bytesRequired = 0;
                while (temp > 0)
                {
                    temp >>= 8;
                    bytesRequired++;
                }
                stream.Write((byte)(bytesRequired | 0x80));
                for (var i = bytesRequired - 1; i >= 0; i--)
                {
                    stream.Write((byte)(length >> (8 * i) & 0xff));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataLoaded = false;
            GeneratedAsim = false;
            GeneratedSim = false;
        }



        private void btnProvjeriPotpis_Click(object sender, EventArgs e)
        {
            if (DataLoaded)
            {
                if (GeneratedAsim)
                {
                    byte[] data = File.ReadAllBytes(UnosniPath);
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.ImportParameters(PrivateRSA);

                    MessageBox.Show("Odaberite potpis");

                    string path="";
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Text files | *.txt";
                    dialog.Multiselect = false;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        path = dialog.FileName;
                    }

                    byte[] potpis = File.ReadAllBytes(path);

                    if (rsa.VerifyData(data,SHA256.Create(),potpis))
                    {
                        MessageBox.Show("Potpis je ispravan!");
                    }
                    else
                    {
                        MessageBox.Show("Potpis nije ispravan!");
                    }

                }
                else
                {
                    MessageBox.Show("Nisu generirani kljucevi");
                }
            }
            else
            {
                MessageBox.Show("Datoteka nije ucitana");
            }


        }

        private void btnDigitalniPotpis_Click(object sender, EventArgs e)
        {
            if (DataLoaded) {
                if (GeneratedAsim)
                {
                    byte[] data = File.ReadAllBytes(UnosniPath);
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.ImportParameters(PrivateRSA);
                    saveFile(rsa.SignData(data, SHA256.Create()));
                }
                else
                {
                    MessageBox.Show("Nisu generirani kljucevi");
                }
            }
            else
            {
                MessageBox.Show("Datoteka nije ucitana");
            }
            

        }
    }
}
